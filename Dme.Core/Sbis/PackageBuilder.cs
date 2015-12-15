using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dme.Sbis
{
    public class PackageBuilder
    {
        const int MAX_RND = 99999;
        const int MAX_ID = 99999;

        Package package = new Package();
        string _Name;
        Random _Rnd = new Random();
        Package _Package;
        string _FolderName;
        int _Id = 0;
        int _FileNo = 1;

        public string SenderINN { get; set; }
        public string SenderKPP { get; set; }
        public string RecipientINN { get; set; }
        public string RecipientKPP { get; set; }

        public PackageBuilder(string folderName, int recipient)
        {
            _FolderName = folderName;
            using (var context = new Dme.Core.DmeEntities())
            {
                var r1 = (from r in context.Клиенты where r.Код == 1 select r).First(); // СНТ
                var r2 = (from r in context.Клиенты where r.Код == recipient select r).First(); 
                SenderINN = r1.ИНН;
                SenderKPP = r1.КПП;
                RecipientINN = r2.ИНН;
                RecipientKPP = r2.КПП;
            }
        }

        public void Begin()
        {
            _Name = String.Format("{0}_{1}_{2}", 
                DateTime.Now.ToString("ddMMyyyyHHmmssfffff"),
                _Rnd.Next(MAX_RND), NextId());
            _FileNo = 1;
            _Package = new Package(SenderINN, SenderKPP, RecipientINN, RecipientKPP);
        }

        public XmlWriter AddFile()
        {
            string fileName = _Name+"."+ NextFileNo().ToString() + ".xml";
            _Package.Attachments.Add(fileName);
            return XmlWriter.Create(System.IO.Path.Combine(_FolderName, fileName));
        }

        public void Flush()
        {
            _Package.Save(System.IO.Path.Combine(_FolderName, _Name+".sbis.xml"));
        }

        private int NextId()
        {
            _Id++;
            if (_Id > MAX_ID)
                _Id = 1;
            return _Id;
        }
        private int NextFileNo()
        {
            _FileNo++;
            return _FileNo;
        }
    }
}
