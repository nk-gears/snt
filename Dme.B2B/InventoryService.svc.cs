using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dme.B2B
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InventoryService.svc or InventoryService.svc.cs at the Solution Explorer and start debugging.
    public class InventoryService : IInventoryService
    {
        Dme.Core.DmeEntities _Context = null;
        public InventoryService()
        {
            _Context = new Core.DmeEntities();
        }
        
        public Inventory.ЗапасКоллекция ПолучитьТекущий()
        {
            var qinv = _Context.Database.SqlQuery<Inventory.Запас>(@"EXEC [dbo].[Запас_ПолучитьТекущий];", new object[] { });
            Inventory.ЗапасКоллекция result = new Inventory.ЗапасКоллекция();
            foreach (var i in qinv)
                result.Add(i);
            return result;
        }
    }
}
