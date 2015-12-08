using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dme.B2B.Inbound;
using System.Reflection;
using AutoMapper;
using System.Data.SqlClient;
using System.Data.Entity.Validation;

namespace Dme.B2B
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InboundService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InboundService.svc or InboundService.svc.cs at the Solution Explorer and start debugging.
    public class InboundService : IInboundService, IDisposable
    {
        Dme.Core.DmeEntities _Context = null;
        public InboundService()
        {
            _Context = new Core.DmeEntities();
            Inbound.DataContractMapperCfg.Initialize();
        }
        public Inbound.Файл ЗаказНаРазмещениеДокумент(Inbound.Документ документ)
        {
            try
            {
                Dme.Core.ЗаказНаРазмещениеФайл target = CreateЗаказНаРазмещениеФайл(null);
                CopyДокумент(target, документ);
                return CopyЗаказНаРазмещениеФайл(SaveЗаказНаРазмещениеФайл(target));
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(e.Message);
                sb.AppendLine(e.StackTrace);
                throw new Exception(sb.ToString());
            }
        }

        public Inbound.Файл ЗаказНаРазмещениеФайл(Inbound.Файл файл)
        {
            try
            {
                Dme.Core.ЗаказНаРазмещениеФайл target = CreateЗаказНаРазмещениеФайл(файл);
                foreach (var o in файл.Документ)
                    CopyДокумент(target, o);
                return CopyЗаказНаРазмещениеФайл(SaveЗаказНаРазмещениеФайл(target));
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(e.Message);
                sb.AppendLine(e.StackTrace);
                throw new Exception(sb.ToString());
            }
        }
        private void CopyДокумент(Dme.Core.ЗаказНаРазмещениеФайл файл, Inbound.Документ s)
        {
            var t = new Core.ЗаказНаРазмещениеДокумент();
            Mapper.Map<Inbound.Документ, Core.ЗаказНаРазмещениеДокумент>(s, t);
            файл.ЗаказНаРазмещениеДокумент.Add(t);
        }
        private Inbound.Файл CopyЗаказНаРазмещениеФайл(Dme.Core.ЗаказНаРазмещениеФайл source)
        {
            Inbound.Файл result = new Inbound.Файл();
            Mapper.Map<Core.ЗаказНаРазмещениеФайл, Inbound.Файл>(source, result);
            return result;
        }

        private Dme.Core.ЗаказНаРазмещениеФайл CreateЗаказНаРазмещениеФайл(Inbound.Файл файл)
        {
            var result = new Dme.Core.ЗаказНаРазмещениеФайл();
            result.C_WfState = 0;
            result.C_CreatedDT = DateTime.Now;
            result.C_CreatedUser = Helper.GetUserName();
            result.C_WfLastUpdateDT = result.C_CreatedDT;
            result.C_WfLastUpdateUser = Helper.GetUserName();
            result.ВерсПрог = Helper.GetAppVersion();
            result.ВерсияФормата = "1.0";
            result.Имя = файл == null ? Guid.NewGuid().ToString() : файл.Имя;
            result.Формат = "ЗаказНаРазмещение";
            return result;
        }

        private Dme.Core.ЗаказНаРазмещениеФайл SaveЗаказНаРазмещениеФайл(Dme.Core.ЗаказНаРазмещениеФайл файл)
        {
            _Context.ЗаказНаРазмещениеФайл.Add(файл);
            Dme.Core.Helper.Entities.SaveChanges(_Context);
            _Context.Database.ExecuteSqlCommand(
                "EXEC [dbo].[ЗаказНаРазмещениеФайл_Создан] @Файл_Id",
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
        // ~InboundService() {
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
