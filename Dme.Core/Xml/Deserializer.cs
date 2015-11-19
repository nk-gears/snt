using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Reflection;

namespace Dme.Core.Xml
{
    public class Deserializer
    {
        public event EventHandler<DeserializerFilterEventArgs> OnFilter;
        public event EventHandler<DeserializerRenameEventArgs> OnRename;

        Type _Type = null;

        public Deserializer()
        { 
        }
        public Deserializer(Type tp)
        {
            _Type = tp;
        }

        public object Execute(Stream input, Type tp = null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(input);
            return CreateObjectFromXmlElement(doc.DocumentElement, tp ?? _Type, "/");
        }

        private object CreateObjectFromXmlElement(XmlElement xmlElement, Type tp, string rootXPath)
        {
            object res = Activator.CreateInstance(tp);
            var tpa = FastMember.TypeAccessor.Create(tp);
            Dictionary<string, PropertyInfo> propMap = new Dictionary<string,PropertyInfo>();
            foreach(var prop in tp.GetProperties())
                propMap.Add(prop.Name, prop);

            foreach (XmlAttribute xmlAttr in xmlElement.Attributes)
            {
                string attrXPath = rootXPath + "/@" + xmlAttr.Name;
                string propName = DoRename(xmlAttr.Name, attrXPath, tp);
                if (!propMap.ContainsKey(propName))
                    continue;
                if (DoFilter(xmlAttr.Name, attrXPath, tp))
                    continue;
                tpa[res, propName] = Dme.Helper.Conversion.Convert(
                    xmlAttr.Value, 
                    propMap[propName].PropertyType, null);
            }

            foreach (XmlElement xmlSubElement in xmlElement.ChildNodes)
            {
                string subElementXPath = rootXPath + "/" + xmlSubElement.Name;
                string propName = DoRename(xmlSubElement.Name, subElementXPath, tp);
                if (!propMap.ContainsKey(propName))
                    continue;
                var prop = propMap[propName];
                Type propType = prop.PropertyType;
                var addMethod = propType.GetMethod("Add");
                if (addMethod == null)
                    continue;
                object propValue = tpa[res, propName];
                Type itemType = prop.PropertyType.GetGenericArguments().Single();
                object item = CreateObjectFromXmlElement(xmlSubElement, itemType, subElementXPath);
                addMethod.Invoke(propValue, new object[] { item });
            }

            return res;
        }

        private bool DoFilter(string name, string xpath, Type tp)
        {
            if (OnFilter != null)
            {
                DeserializerFilterEventArgs args = new DeserializerFilterEventArgs { 
                    XPath = xpath,
                    Name = name,
                    Type = tp,
                    Skip = false
                };
                OnFilter(this, args);
                return args.Skip;
            }
            else
                return false;
        }

        private string DoRename(string name, string xpath, Type tp)
        {
            if (OnRename != null)
            {
                DeserializerRenameEventArgs args = new DeserializerRenameEventArgs { 
                    XPath = xpath,
                    Name = name,
                    Type = tp
                };
                OnRename(this, args);
                return args.Name;
            }
            else
                return name;
        }
    }
}