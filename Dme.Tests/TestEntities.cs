using System;
using System.Data;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using Dme.Core;
using System.Diagnostics;

namespace Dme.Tests
{
    [TestClass]
    public class TestEntities
    {
        [TestMethod]
        [TestCategory("Inbound")]
        [Description("Тестирует доступ к основным таблицам документов приемки")]
        public void Доступ_к_базовым_таблицам()
        {
            using (var context = new Dme.Core.DmeEntities())
            {
                context.АктПриемкиАдрес.Find(new object[] { 0 });
                context.АктПриемкиАдрИно.Find(new object[] { 0 });
                context.АктПриемкиАдрРФ.Find(new object[] { 0 });
                context.АктПриемкиБанкРекв.Find(new object[] { 0 });
                context.АктПриемкиБухгалтер.Find(new object[] { 0 });
                context.АктПриемкиВалюта.Find(new object[] { 0 });
                context.АктПриемкиГрузоотправитель.Find(new object[] { 0 });
                context.АктПриемкиГрузополучатель.Find(new object[] { 0 });
                context.АктПриемкиДокумент.Find(new object[] { 0 });
                context.АктПриемкиКонтакт.Find(new object[] { 0 });
                context.АктПриемкиНДС.Find(new object[] { 0 });
                context.АктПриемкиОснование.Find(new object[] { 0 });
                context.АктПриемкиПараметр.Find(new object[] { 0 });
                context.АктПриемкиПоДокументам.Find(new object[] { 0 });
                context.АктПриемкиПодразделение.Find(new object[] { 0 });
                context.АктПриемкиПокупатель.Find(new object[] { 0 });
                context.АктПриемкиПоставщик.Find(new object[] { 0 });
                context.АктПриемкиПоФакту.Find(new object[] { 0 });
                context.АктПриемкиПредставители.Find(new object[] { 0 });
                context.АктПриемкиРуководитель.Find(new object[] { 0 });
                context.АктПриемкиСвФЛ.Find(new object[] { 0 });
                context.АктПриемкиСвЮЛ.Find(new object[] { 0 });
                context.АктПриемкиСписокАдрес.Find(new object[] { 0 });
                context.АктПриемкиСписокОснование.Find(new object[] { 0 });
                context.АктПриемкиСписокПараметр.Find(new object[] { 0 });
                context.АктПриемкиСписокСтрОтклонения.Find(new object[] { 0 });
                context.АктПриемкиСписокХарактеристика.Find(new object[] { 0 });
                context.АктПриемкиСтороны.Find(new object[] { 0 });
                context.АктПриемкиСтрОтклонения.Find(new object[] { 0 });
                context.АктПриемкиФайл.Find(new object[] { 0 });
                context.АктПриемкиХарактеристика.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеАдрес.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеАдрИно.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеАдрРФ.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеБанкРекв.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеДокумент.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеИтогТабл.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеКонтакт.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеНДС.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеОснование.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеОтправитель.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеПараметр.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеПодразделение.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеПолучатель.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеПредставитель.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеРазмерКоробки.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеРазмерМалСтандарт.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеРазмерУпаковки.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеСвФЛ.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеСвЮЛ.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеСтрТабл.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеТаблДок.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеФайл.Find(new object[] { 0 });
                context.ЗаказНаРазмещениеХарактеристика.Find(new object[] { 0 });
                context.Мх1Адрес.Find(new object[] { 0 });
                context.Мх1АдрИно.Find(new object[] { 0 });
                context.Мх1АдрРФ.Find(new object[] { 0 });
                context.Мх1БанкРекв.Find(new object[] { 0 });
                context.Мх1Документ.Find(new object[] { 0 });
                context.Мх1ИтогТабл.Find(new object[] { 0 });
                context.Мх1Контакт.Find(new object[] { 0 });
                context.Мх1НДС.Find(new object[] { 0 });
                context.Мх1Основание.Find(new object[] { 0 });
                context.Мх1Отправитель.Find(new object[] { 0 });
                context.Мх1Параметр.Find(new object[] { 0 });
                context.Мх1Подразделение.Find(new object[] { 0 });
                context.Мх1Получатель.Find(new object[] { 0 });
                context.Мх1Представитель.Find(new object[] { 0 });
                context.Мх1СвФЛ.Find(new object[] { 0 });
                context.Мх1СвЮЛ.Find(new object[] { 0 });
                context.Мх1СтрТабл.Find(new object[] { 0 });
                context.Мх1ТаблДок.Find(new object[] { 0 });
                context.Мх1Файл.Find(new object[] { 0 });
                context.Мх1Характеристика.Find(new object[] { 0 });
            }
        }

        [TestMethod]
        [TestCategory("Inbound")]
        [Description("Тестирует создание заказа на размещение")]
        public void Создать_ЗаказНаРазмещение()
        {
            using (var context = new Dme.Core.DmeEntities())
            {
                var file = Mocks.CreateЗаказНаРазмещениеФайл();
                context.ЗаказНаРазмещениеФайл.Add(file);
                context.SaveChanges();
            }
        }
    }
}
