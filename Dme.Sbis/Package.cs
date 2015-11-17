using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Dme.Sbis
{
    public class Package
    {
        public string SenderINN { get; set; }
        public string SenderKPP { get; set; }
        public string RecipientINN { get; set; }
        public string RecipientKPP { get; set; }

        List<string> _Attachments = new List<string>();

        public List<string> Attachments
        {
            get { return _Attachments; }
        }

        public Package()
        { 
        }

        public Package (string senderINN,string senderKPP, string recipientINN, string recipientKPP)
        {
            SenderINN = senderINN;
            SenderKPP = senderKPP;
            RecipientINN = recipientINN;
            RecipientKPP = recipientKPP;
        }

        public void Save(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            var regNode = doc.CreateElement(@"Реестр");
            doc.AppendChild(regNode);
            var packNode = doc.CreateElement(@"Пакет");
            regNode.AppendChild(packNode);
            var recipNode = doc.CreateElement(@"Получатель");
            recipNode.SetAttribute("ИНН", RecipientINN);
            recipNode.SetAttribute("КПП", RecipientKPP);
            packNode.AppendChild(recipNode);
            var sendNode = doc.CreateElement(@"Отправитель");
            sendNode.SetAttribute("ИНН", SenderINN);
            sendNode.SetAttribute("КПП", SenderKPP);
            packNode.AppendChild(sendNode);
            foreach (var attachment in _Attachments)
            {
                var attNode = doc.CreateElement(@"Вложение");
                attNode.SetAttribute("ИмяФайла", attachment);
                packNode.AppendChild(attNode);
            }
            doc.Save(fileName);
        }
    }
}
