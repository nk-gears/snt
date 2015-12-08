using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutoMapper;
using System.Data.SqlClient;

namespace Dme.B2B
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class OutboundService : IOutboundService, IDisposable
    {
        Dme.Core.DmeEntities _Context = null;
        public OutboundService()
        {
            _Context = new Core.DmeEntities();
            Outbound.DataContractMapperCfg.Initialize();
        }
        public Outbound.Файл ЗаказНаОтгрузкуДокумент(Outbound.Документ документ)
        {
            var target = CreateЗаказНаОтгрузкуФайл(null);
            CopyДокумент(target, документ);
            return CopyЗаказНаОтгрузкуФайл(SaveFileAndProcess(target));
        }

        public Outbound.Файл ЗаказНаОтгрузкуФайл(Outbound.Файл файл)
        {
            var target = CreateЗаказНаОтгрузкуФайл(файл);
            foreach (var o in файл.Документ)
                CopyДокумент(target, o);
            return CopyЗаказНаОтгрузкуФайл(SaveFileAndProcess(target));
        }

        private Dme.Core.ЗаказНаОтгрузкуФайл CreateЗаказНаОтгрузкуФайл(Outbound.Файл файл)
        {
            Dme.Core.ЗаказНаОтгрузкуФайл result = new Dme.Core.ЗаказНаОтгрузкуФайл();
            result.C_WfState = 0;
            result.C_CreatedDT = DateTime.Now;
            result.C_CreatedUser = Helper.GetUserName();
            result.C_WfLastUpdateDT = result.C_CreatedDT;
            result.C_WfLastUpdateUser = Helper.GetUserName();
            result.ВерсПрог = Helper.GetAppVersion();
            result.ВерсФорм = "1.0";
            result.ИдФайл = файл==null ? Guid.NewGuid().ToString() : файл.ИдФайл;
            result.Сформирован = result.C_CreatedDT.ToString("dd.MM.yyyy hh:mm:ss");
            result.ИдФорм = "ЗаказНаОтгрузку";

            return result;
        }
        private Outbound.Файл CopyЗаказНаОтгрузкуФайл(Dme.Core.ЗаказНаОтгрузкуФайл source)
        {
            Outbound.Файл result = new Outbound.Файл();
            Mapper.Map<Core.ЗаказНаОтгрузкуФайл, Outbound.Файл>(source, result);
            return result;
        }

        private void CopyДокумент(Dme.Core.ЗаказНаОтгрузкуФайл файл, Outbound.Документ s)
        {
            Core.ЗаказНаОтгрузкуДокумент t = new Core.ЗаказНаОтгрузкуДокумент();
            Mapper.Map<Outbound.Документ, Core.ЗаказНаОтгрузкуДокумент>(s, t);
            файл.ЗаказНаОтгрузкуДокумент.Add(t);
        }
        private Dme.Core.ЗаказНаОтгрузкуФайл SaveFileAndProcess(Dme.Core.ЗаказНаОтгрузкуФайл файл)
        {
            _Context.ЗаказНаОтгрузкуФайл.Add(файл);
            Dme.Core.Helper.Entities.SaveChanges(_Context);
            _Context.Database.ExecuteSqlCommand(
                "EXEC [dbo].[ЗаказНаОтгрузкуФайл_Создан] @Файл_Id", 
                new object[] { new SqlParameter("@Файл_Id", System.Data.SqlDbType.Int) { Value = файл.Файл_Id } });
            _Context.Entry(файл).Reload();
            return файл;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _Context.Dispose();
                    _Context = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~OutboundService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
