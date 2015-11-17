using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dme.Svc
{
    public class FileWatcher : IMicroService
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(FileWatcher));
        FileSystemWatcher _InFolderWatcher;
        Queue<string> _InFilesQueue = new Queue<string>();
        Task _TaskProcessFiles;
        CancellationToken _CancellationToken;
        Action<string> _FileAction;

        string _FilePattern;
        string _InFolder;
        string _TmpFolder;
        string _ArchiveFolder;
        string _ErrorFolder;
        public FileWatcher(
            string filePattern,
            string inFolder,
            string tmpFolder,
            string archiveFolder,
            string errorFolder,
            CancellationToken cancellationToken,
            Action<string> fileAction
        )
        {
            _CancellationToken = cancellationToken;
            _FilePattern = filePattern;
            _InFolder = inFolder;
            _ArchiveFolder = archiveFolder;
            _ErrorFolder = errorFolder;
            _TmpFolder = tmpFolder;
            _FileAction = fileAction;
        }

        public Task Run()
        {
            log.Info("Recovering files in temp folder");
            foreach (var fileName in Directory.GetFiles(_InFolder, _FilePattern))
                File.Move(fileName, Path.Combine(_TmpFolder, Path.GetFileName(fileName)));
            foreach (var fileName in Directory.GetFiles(_TmpFolder, _FilePattern))
                _InFilesQueue.Enqueue(fileName);

            log.Info("Creating input folder watcher");
            _InFolderWatcher = new FileSystemWatcher(
                _InFolder,
                _FilePattern);
            _InFolderWatcher.NotifyFilter = NotifyFilters.FileName;
            _InFolderWatcher.Created += InputFolderWatcher_FileCreated;
            _InFolderWatcher.EnableRaisingEvents = true;
            log.Info("Creating input file queue processor");
            _TaskProcessFiles = new Task(() => ProcessInputFilesQueue());
            _TaskProcessFiles.Start();
            return _TaskProcessFiles;
        }

        /// <summary>
        /// Помещает новый файл в очередь на обработку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void InputFolderWatcher_FileCreated(object sender, FileSystemEventArgs e)
        {
            if (!_CancellationToken.IsCancellationRequested)
            {
                string tmpPath = Path.Combine(_TmpFolder, e.Name);
                try
                {
                    File.Move(e.FullPath, tmpPath);
                    lock (_InFilesQueue)
                        _InFilesQueue.Enqueue(tmpPath);
                }
                catch (Exception err)
                {
                    log.Error(String.Format("Failed to copy file {0} into {1}", e.FullPath, tmpPath), err);
                }
            }
        }
        /// <summary>
        /// Обрабатывает очередь файлов
        /// </summary>
        void ProcessInputFilesQueue()
        {
            while (true)
            {
                if (_CancellationToken.IsCancellationRequested)
                    return;
                int i = 0;
                while (i == 0)
                {
                    if (_CancellationToken.IsCancellationRequested)
                        return;
                    lock (_InFilesQueue)
                        i = _InFilesQueue.Count;
                    if (i == 0)
                        Thread.Sleep(500);
                }
                string path = _InFilesQueue.Dequeue();
                string fileName = System.IO.Path.GetFileName(path);
                string archPath = Path.Combine(_ArchiveFolder,fileName);
                string errPath = Path.Combine(_ErrorFolder, fileName);
                try
                {
                    _FileAction(path);
                    try
                    {
                        if (File.Exists(archPath))
                            File.Delete(archPath);
                        File.Move(path, archPath);
                    }
                    catch (Exception err2)
                    {
                        log.Error(String.Format("Failed to copy file {0} into {1}", path, archPath), err2);
                    }
                }
                catch (Exception err)
                {
                    log.Error(String.Format("Failed to process file {0}", fileName), err);
                    try
                    {
                        if (File.Exists(errPath))
                            File.Delete(errPath);
                        File.Move(path, errPath);
                    }
                    catch (Exception err2)
                    {
                        log.Error(String.Format("Failed to copy file {0} into {1}", path, errPath), err2);
                    }
                }
            }
        }
    }
}
