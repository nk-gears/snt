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
        }
        public Inbound.Файл ЗаказНаРазмещениеДокумент(Inbound.Документ документ)
        {
            try
            {
                var result = new Inbound.Файл();
                result.Документ = new ДокументКоллекция();
                ProcessInbound(документ);
                result.Документ.Add(документ);
                Dme.Core.Helper.Entities.SaveChanges(_Context);
                return result;
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                for (Exception err = e; err != null; err = err.InnerException)
                {
                    sb
                        .Append(err.Message)
                        .AppendLine(err.StackTrace)
                        .AppendLine("===========================")
                        .AppendLine();
                }
                throw new Exception(sb.ToString());
            }
        }

        public Inbound.Файл ЗаказНаРазмещениеФайл(Inbound.Файл файл)
        {
            try
            { 
                foreach (Inbound.Документ s in файл.Документ)
                    ProcessInbound(s);
                Dme.Core.Helper.Entities.SaveChanges(_Context);
                return файл;
            }
            catch (Exception e)
            {
                StringBuilder sb = new StringBuilder();
                for (Exception err = e; err != null; err = err.InnerException)
                {
                    sb.AppendLine(err.Message);
                    sb.AppendLine(err.StackTrace);
                    sb.AppendLine("===========================");
                    sb.AppendLine();
                }
                throw new Exception(sb.ToString());
            }
        }


        public void ProcessInbound(Inbound.Документ s)
        {
            var userID = Helper.GetUserName();
            var userB2B = _Context.B2BUser.First(r => r.B2BUserID == userID);
            // Заказ
            var o = new Dme.Core.Order();
            o.UserID = userID;
            o.DT = DateTime.Now;
            o.CustOrderID = s.Номер;
            o.CustOrderDT = s.Дата;
            string orderTypeName = GetParameter(s, "Тип") ?? "Поставка";
            o.OrderType = _Context.OrderType.Where(ot=>ot.Name==orderTypeName && ot.Sign=="+").FirstOrDefault();
            if (o.OrderType == null)
                throw new Exception("Неизвестный тип документа");
            o.CustomerID = userB2B.CustomerID;
            var t = s.ТаблДок.First();
            // Отправитель
            o.Supplier = GetSupplier(s.Отправитель.First().СвЮЛ.First());
            // Строки
            int rowNo = 1;
            foreach (var r in t.СтрТабл)
            {
                var i = new Core.OrderDocRow();
                i.Partm = GetPartm(r);
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
        /// <summary>
        /// Возвращает товар из справочника. Если такого нет, то создает новую запись
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private Dme.Core.Partm GetPartm(Inbound.СтрТабл r)
        {
            Dme.Core.Partm p;
            int partID = 0;
            string id1 = r.Код;
            if (id1 == null || id1 == string.Empty)
            {
                var y = r.Характеристика.Where(x => x.Имя == "КодСантэнс").FirstOrDefault();
                if (y == null)
                    throw new Exception("Поле \"Код\" должно быть заполнено");
                else
                    partID = Int32.Parse(y.Значение);
            }
            if (partID > 0)
            {
                p = _Context.Partm.FirstOrDefault(i => i.PartID == partID);
                if (p == null)
                    throw new Exception(String.Format("Поле \"КодСантэнс\" содержит недопустимое значение {0}", partID));
            }
            else
            {
                p = _Context.Partm.FirstOrDefault(i => i.id1 == id1);
                if (p == null)
                {
                    p = new Core.Partm();
                    p.PartID = GetPartmNewID();
                    p.partdsc = r.Название;
                    p.partdsc2 = r.Производитель;
                    p.id1 = id1;
                    p.tempcl = r.ТемпРежим ?? "general";
                    p.glass = r.Стекло ?? false;
                    p.specaccount = r.Пку ?? false;
                    p.hazcl = r.КлассОпасн ?? "general";
                    p.minorder = r.МинЗаказ ?? 1;
                    p.mulorder = r.КратнЗаказ ?? 1;
                    _Context.Partm.Add(p);
                    _Context.SaveChanges();
                }
            }
            return p;
        }
        string GetParameter(Inbound.Документ s, string name, bool throwException = false)
        {
            var par = s.Параметр==null ? null : s.Параметр.FirstOrDefault(p => p.Имя == name);
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
        /// <summary>
        /// Генерирует код для новой записи в справочнике товаров
        /// </summary>
        /// <returns></returns>
        private int GetPartmNewID()
        {
            int maxID = _Context.Partm.Max(i => i.PartID);
            if (maxID < 100000)
                maxID = 100000;
            return maxID + 1;
        }
        /// <summary>
        /// Возвращает запись поставщика из справочника. Если такой нет, то создает новую
        /// </summary>
        /// <param name="suppl"></param>
        /// <returns></returns>
        private Core.Customer GetSupplier(Inbound.СвЮЛ suppl)
        {
            Core.Customer cust = _Context.Customer.Where(c=>c.INN == suppl.ИНН).FirstOrDefault();
            if (cust == null)
            {
                cust = new Core.Customer();
                cust.INN = suppl.ИНН;
                cust.KPP = suppl.КПП;
                cust.OKDP = suppl.ОКДП;
                cust.OKPO = suppl.ОКПО;
                cust.Name = suppl.Название;
                _Context.Customer.Add(cust);
                _Context.SaveChanges();
            }
            return cust;
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
