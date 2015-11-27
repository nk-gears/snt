using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dme.B2B
{
    public class DeliveryService : IDeliveryService, IDisposable
    {
        Dme.Core.DmeEntities _Context = null;
        public DeliveryService()
        {
            _Context = new Core.DmeEntities();
            Delivery.DataContractMapperCfg.Initialize();
        }
        public Delivery.Файл ДоставкаДокумент(Delivery.Документ документ)
        {
            Dme.Core.ДоставкаФайл target = CreateДоставкаФайл(null);
            CopyДокумент(target, документ);
            return CopyДоставкаФайл(SaveДоставкаФайл(target));
        }

        public Delivery.Файл ДоставкаФайл(Delivery.Файл файл)
        {
            Dme.Core.ДоставкаФайл target = CreateДоставкаФайл(файл);
            foreach (var o in файл.Документ)
                CopyДокумент(target, o);
            return CopyДоставкаФайл(SaveДоставкаФайл(target));
        }
        private void CopyДокумент(Dme.Core.ДоставкаФайл файл, Delivery.Документ s)
        {
            var t = new Core.ДоставкаДокумент();
            Mapper.Map<Delivery.Документ, Core.ДоставкаДокумент>(s, t);
            файл.ДоставкаДокумент.Add(t);
        }
        private Delivery.Файл CopyДоставкаФайл(Dme.Core.ДоставкаФайл source)
        {
            Delivery.Файл result = new Delivery.Файл();
            Mapper.Map<Core.ДоставкаФайл, Delivery.Файл>(source, result);
            return result;
        }

        private Dme.Core.ДоставкаФайл CreateДоставкаФайл(Delivery.Файл файл)
        {
            var result = new Dme.Core.ДоставкаФайл();
            result.C_WfState = 0;
            result.C_CreatedDT = DateTime.Now;
            result.C_CreatedUser = Helper.GetUserName();
            result.C_WfLastUpdateDT = result.C_CreatedDT;
            result.C_WfLastUpdateUser = Helper.GetUserName();
            result.ВерсПрог = Helper.GetAppVersion();
            result.ВерсФорм = "1.0";
            result.ИдФайл = файл == null ? Guid.NewGuid().ToString() : файл.ИдФайл;
            result.ИдФорм = "Доставка";
            return result;
        }

        private Dme.Core.ДоставкаФайл SaveДоставкаФайл(Dme.Core.ДоставкаФайл файл)
        {
            _Context.ДоставкаФайл.Add(файл);
            _Context.SaveChanges();
            _Context.Database.ExecuteSqlCommand(
                "EXEC [dbo].[OnCreatedДоставкаФайл] @Файл_Id",
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
        // ~DeliveryService() {
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
