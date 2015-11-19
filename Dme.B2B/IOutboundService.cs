using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Dme.B2B
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOutboundService
    {

        [OperationContract]
        Outbound.Файл ЗаказНаОтгрузкуФайл(Outbound.Файл файл);

        [OperationContract]
        Outbound.Файл ЗаказНаОтгрузкуДокумент(Outbound.Документ документ);
    }

}
