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
using Dme.B2B.Outbound;
using System.Globalization;

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
        }
        public Outbound.Файл ЗаказНаОтгрузкуДокумент(Outbound.Документ документ)
        {
            var result = new Outbound.Файл();
            result.Документ = new ДокументКоллекция();
            ProcessOutbound(документ);
            result.Документ.Add(документ);
            Dme.Core.Helper.Entities.SaveChanges(_Context);
            return result;
        }

        public Outbound.Файл ЗаказНаОтгрузкуФайл(Outbound.Файл файл)
        {
            foreach (Outbound.Документ s in файл.Документ)
                ProcessOutbound(s);
            Dme.Core.Helper.Entities.SaveChanges(_Context);
            return файл;

        }

        public void ProcessOutbound(Outbound.Документ s)
        {
            var userID = Helper.GetUserName();
            var userB2B = _Context.B2BUser.First(r => r.B2BUserID == userID);
            // Заказ
            var o = new Dme.Core.Order();
            o.UserID = userID;
            o.DT = DateTime.Now;
            o.CustOrderID = s.Номер;
            o.CustOrderDT = s.Дата;
            string orderTypeName = GetParameter(s, "Тип") ?? "Отгрузка";
            o.OrderType = _Context.OrderType.Where(ot => ot.Name == orderTypeName && ot.Sign == "-").FirstOrDefault();
            if (o.OrderType == null)
                throw new Exception("Неизвестный тип документа");
            o.CustomerID = userB2B.CustomerID;
            var t = s.ТаблДок.First();
            // Отправитель
            o.Dest = new Core.Dest();
            o.Dest.Name = GetParameter(s, "ПолучательНаим", true); 
            o.Dest.Addr = GetParameter(s, "ПолучательАдрес", true); 
            o.Dest.Phone = GetParameter(s, "ПолучательТел");
            o.Dest.Note = GetParameter(s, "ПолучательПримечание");
            o.Dest.WorkSchW1From = TimeSpan.Parse(GetParameter(s, "НачалоРаботыПн") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW2From = TimeSpan.Parse(GetParameter(s, "НачалоРаботыВт") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW3From = TimeSpan.Parse(GetParameter(s, "НачалоРаботыСр") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW4From = TimeSpan.Parse(GetParameter(s, "НачалоРаботыЧт") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW5From = TimeSpan.Parse(GetParameter(s, "НачалоРаботыПт") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW6From = TimeSpan.Parse(GetParameter(s, "НачалоРаботыСб") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW7From = TimeSpan.Parse(GetParameter(s, "НачалоРаботыВс") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW1To = TimeSpan.Parse(GetParameter(s, "КонецРаботыПн") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW2To = TimeSpan.Parse(GetParameter(s, "КонецРаботыВт") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW3To = TimeSpan.Parse(GetParameter(s, "КонецРаботыСр") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW4To = TimeSpan.Parse(GetParameter(s, "КонецРаботыЧт") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW5To = TimeSpan.Parse(GetParameter(s, "КонецРаботыПт") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW6To = TimeSpan.Parse(GetParameter(s, "КонецРаботыСб") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.WorkSchW7To = TimeSpan.Parse(GetParameter(s, "КонецРаботыВс") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW1From = TimeSpan.Parse(GetParameter(s, "НачалоПриемкиПн") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW2From = TimeSpan.Parse(GetParameter(s, "НачалоПриемкиВт") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW3From = TimeSpan.Parse(GetParameter(s, "НачалоПриемкиСр") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW4From = TimeSpan.Parse(GetParameter(s, "НачалоПриемкиЧт") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW5From = TimeSpan.Parse(GetParameter(s, "НачалоПриемкиПт") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW6From = TimeSpan.Parse(GetParameter(s, "НачалоПриемкиСб") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW7From = TimeSpan.Parse(GetParameter(s, "НачалоПриемкиВс") ?? "00:00:00", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW1To = TimeSpan.Parse(GetParameter(s, "КонецПриемкиПн") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW2To = TimeSpan.Parse(GetParameter(s, "КонецПриемкиВт") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW3To = TimeSpan.Parse(GetParameter(s, "КонецПриемкиСр") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW4To = TimeSpan.Parse(GetParameter(s, "КонецПриемкиЧт") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW5To = TimeSpan.Parse(GetParameter(s, "КонецПриемкиПт") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW6To = TimeSpan.Parse(GetParameter(s, "КонецПриемкиСб") ?? "23:59:59", CultureInfo.InvariantCulture);
            o.Dest.DeliverySchW7To = TimeSpan.Parse(GetParameter(s, "КонецПриемкиВс") ?? "23:59:59", CultureInfo.InvariantCulture);
            _Context.Dest.Add(o.Dest);
            // Примечание
            string orderNote = GetParameter(s, "Примечание");
            if (orderNote != null)
                o.OrderNote.Add(new Core.OrderNote { Note = orderNote });
            // Строки
            int rowNo = 1;
            foreach (var r in t.СтрТабл)
            {
                var i = new Core.OrderDocRow();
                i.Partm = _Context.Partm.FirstOrDefault(p => p.id1 == r.Код);
                i.BatchNo = r.Серия;
                i.InvQual = r.Качество ?? "N";
                i.SpecInvID = r.Маркер;
                i.ExpireDT = r.СрокГодности;
                i.Qty = r.Кол_во;
                i.Price = r.Цена;
                i.RowNo = rowNo;
                o.OrderDocRow.Add(i);
                rowNo++;
            }
            // сохраняем изменения
            _Context.Order.Add(o);
        }

        string GetParameter(Outbound.Документ s, string name, bool throwException = false)
        {
            var par = s.Параметр == null ? null : s.Параметр.FirstOrDefault(p => p.Имя == name);
            if (par == null)
            {
                if (throwException)
                    throw new Exception(String.Format("Ожидается параметр документа \"{0}\"", name));
                else
                    return null;
            }
            string result = par.Значение;
            return result;
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
