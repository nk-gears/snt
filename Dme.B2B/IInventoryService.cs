﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Dme.B2B
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInventoryService" in both code and config file together.
    [ServiceContract]
    public interface IInventoryService
    {
        [OperationContract]
        Inventory.ЗапасКоллекция ПолучитьТекущий();
    }
}
