using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Dme.Core.Xml
{
    public class OrderSerializer
    {

        public static XElement ToXElement(Order o)
        {
            if (o == null)
                return null;
            var oa = FastMember.ObjectAccessor.Create(o);
            return new XElement(
                "Order",
                ToXAttr(oa, "CustomerID"),
                ToXAttr(oa, "CustOrderDT"),
                ToXAttr(oa, "CustOrderID"),
                ToXAttr(oa, "DestID"),
                ToXAttr(oa, "DT"),
                ToXAttr(oa, "OrderID"),
                ToXAttr(oa, "OrderTypeID"),
                ToXAttr(oa, "ShipID"),
                ToXAttr(oa, "SupplID"),
                ToXAttr(oa, "UserID"),
                ToXAttr(oa, "WfState"),
                ToXAttr(oa, "WmsCloseDT"),
                ToXAttr(oa, "WmsOrderId"),
                ToXAttr(oa, "WmsOrderTy"),
                ToXAttr(oa, "WmsOrderVer"),
                ToXElement(o.OrderType),
                ToXElement(o.OrderNote),
                ToXElement(o.Customer, "Customer"),
                ToXElement(o.Supplier, "Supplier"),
                ToXElement(o.Dest, "Dest"),
                ToXElement(o.OrderDocRow),
                ToXElement(o.OrderFactRow)
            );
        }

        public static XElement ToXElement(Customer o, string name = null)
        {
            if (o == null)
                return null;
            var oa = FastMember.ObjectAccessor.Create(o);
            return new XElement(
                name ?? "Customer",
                ToXAttr(oa, "Addr"),
                ToXAttr(oa, "Bank"),
                ToXAttr(oa, "BIK"),
                ToXAttr(oa, "CorrAcc"),
                ToXAttr(oa, "CustomerID"),
                ToXAttr(oa, "DepID"),
                ToXAttr(oa, "DepName"),
                ToXAttr(oa, "Email"),
                ToXAttr(oa, "Enabled"),
                ToXAttr(oa, "Fax"),
                ToXAttr(oa, "INN"),
                ToXAttr(oa, "KPP"),
                ToXAttr(oa, "Name"),
                ToXAttr(oa, "Note"),
                ToXAttr(oa, "OKDP"),
                ToXAttr(oa, "OKPO"),
                ToXAttr(oa, "Phone"),
                ToXAttr(oa, "SettAcc"),
                ToXAttr(oa, "Web")
            );
        }
        public static XElement ToXElement(Dest o, string name = null)
        {
            if (o == null)
                return null;
            var oa = FastMember.ObjectAccessor.Create(o);
            return new XElement(
                name ?? "Dest",
                ToXAttr(oa, "Addr"),
                ToXAttr(oa, "DeliverySchW1From"),
                ToXAttr(oa, "DeliverySchW1To"),
                ToXAttr(oa, "DeliverySchW2From"),
                ToXAttr(oa, "DeliverySchW2To"),
                ToXAttr(oa, "DeliverySchW3From"),
                ToXAttr(oa, "DeliverySchW3To"),
                ToXAttr(oa, "DeliverySchW4From"),
                ToXAttr(oa, "DeliverySchW4To"),
                ToXAttr(oa, "DeliverySchW5From"),
                ToXAttr(oa, "DeliverySchW5To"),
                ToXAttr(oa, "DeliverySchW6From"),
                ToXAttr(oa, "DeliverySchW6To"),
                ToXAttr(oa, "DeliverySchW7From"),
                ToXAttr(oa, "DeliverySchW7To"),
                ToXAttr(oa, "DestID"),
                ToXAttr(oa, "Name"),
                ToXAttr(oa, "Note"),
                ToXAttr(oa, "Phone"),
                ToXAttr(oa, "WorkSchW1From"),
                ToXAttr(oa, "WorkSchW1To"),
                ToXAttr(oa, "WorkSchW2From"),
                ToXAttr(oa, "WorkSchW2To"),
                ToXAttr(oa, "WorkSchW3From"),
                ToXAttr(oa, "WorkSchW3To"),
                ToXAttr(oa, "WorkSchW4From"),
                ToXAttr(oa, "WorkSchW4To"),
                ToXAttr(oa, "WorkSchW5From"),
                ToXAttr(oa, "WorkSchW5To"),
                ToXAttr(oa, "WorkSchW6From"),
                ToXAttr(oa, "WorkSchW6To"),
                ToXAttr(oa, "WorkSchW7From"),
                ToXAttr(oa, "WorkSchW7To")
            );
        }

        public static XElement[] ToXElement(IEnumerable<OrderNote> o, string name = null)
        {
            if (o == null)
                return null;
            return o.Select( r=> ToXElement(r, name)).ToArray();
        }
        public static XElement ToXElement(OrderNote o, string name = null)
        {
            if (o == null)
                return null;
            var oa = FastMember.ObjectAccessor.Create(o);
            return new XElement(
                    name ?? "OrderNote",
                    ToXAttr(oa, "Note")
                    );
        }
        public static XElement ToXElement(Partm o, string name = null)
        {
            if (o == null)
                return null;
            var oa = FastMember.ObjectAccessor.Create(o);
            return new XElement(
                    name ?? "Partm",
                    ToXAttr(oa, "buwg"),
                    ToXAttr(oa, "eanid"),
                    ToXAttr(oa, "glass"),
                    ToXAttr(oa, "hazcl"),
                    ToXAttr(oa, "height"),
                    ToXAttr(oa, "heightppu"),
                    ToXAttr(oa, "heightspu"),
                    ToXAttr(oa, "id1"),
                    ToXAttr(oa, "id2"),
                    ToXAttr(oa, "length"),
                    ToXAttr(oa, "lengthppu"),
                    ToXAttr(oa, "lengthspu"),
                    ToXAttr(oa, "minorder"),
                    ToXAttr(oa, "mulorder"),
                    ToXAttr(oa, "partdsc"),
                    ToXAttr(oa, "partdsc2"),
                    ToXAttr(oa, "PartID"),
                    ToXAttr(oa, "ppuwg"),
                    ToXAttr(oa, "qpkg1"),
                    ToXAttr(oa, "qpkg2"),
                    ToXAttr(oa, "specaccount"),
                    ToXAttr(oa, "spuwg"),
                    ToXAttr(oa, "tempcl"),
                    ToXAttr(oa, "width"),
                    ToXAttr(oa, "widthppu"),
                    ToXAttr(oa, "widthspu")
                    );
        }

        public static XElement ToXElement(OrderDocRow o, string name = null)
        {
            if (o == null)
                return null;
            var oa = FastMember.ObjectAccessor.Create(o);
            return new XElement(
                    name ?? "OrderDocRow",
                    ToXAttr(oa, "BatchNo"),
                    ToXAttr(oa, "ExpireDT"),
                    ToXAttr(oa, "InvQual"),
                    ToXAttr(oa, "OrderDocRowID"),
                    ToXAttr(oa, "OrderID"),
                    ToXAttr(oa, "PartID"),
                    ToXAttr(oa, o.Price, "Price"),
                    ToXAttr(oa, "Qty"),
                    ToXAttr(oa, o.Price * o.Qty, "Amount"),
                    ToXAttr(oa, "RowNo"),
                    ToXAttr(oa, "SpecInvID"),
                    ToXElement(o.Partm)                    
                    );
        }
        public static XElement[] ToXElement(IEnumerable<OrderFactRow> o, string name = null)
        {
            if (o == null)
                return null;
            return o.Select(r => ToXElement(r)).ToArray();
        }
        public static XElement[] ToXElement(IEnumerable<OrderDocRow> o, string name = null)
        {
            if (o == null)
                return null;
            return o.Select(r => ToXElement(r)).ToArray();
        }
        public static XElement ToXElement(OrderFactRow o, string name = null)
        {
            if (o == null)
                return null;
            var oa = FastMember.ObjectAccessor.Create(o);
            return new XElement(
                    name ?? "OrderFactRow",
                    ToXAttr(oa, "BatchNo"),
                    ToXAttr(oa, "ExpireDT"),
                    ToXAttr(oa, "InvQual"),
                    ToXAttr(oa, "OrderFactRowID"),
                    ToXAttr(oa, "OrderID"),
                    ToXAttr(oa, "PartID"),
                    ToXAttr(oa, o.Price, "Price"),
                    ToXAttr(oa, "Qty"),
                    ToXAttr(oa, o.Price * o.Qty, "Amount"),
                    ToXAttr(oa, "RowNo"),
                    ToXAttr(oa, "ShipContNo"),
                    ToXAttr(oa, "Sign"),
                    ToXAttr(oa, "SpecInvID"),
                    ToXElement(o.Partm)
                    );
        }


        public static XElement ToXElement(OrderType o, string name = null)
        {
            if (o == null)
                return null;
            var oa = FastMember.ObjectAccessor.Create(o);
            return new XElement(
                name ?? "OrderType",
                ToXAttr(oa, "Name"),
                ToXAttr(oa, "OrderTypeID")
            );
        }

        private static XAttribute ToXAttr(FastMember.ObjectAccessor oa, string propName)
        {
            var obj = oa[propName];
            if (obj == null)
                return null;
            return new XAttribute(propName, obj.ToString());
        }
        private static XAttribute ToXAttr(FastMember.ObjectAccessor oa, decimal? value, string name)
        {
            if (value == null)
                return null;
            return new XAttribute(name, value.Value.ToString(CultureInfo.InvariantCulture));
        }
    }
}
