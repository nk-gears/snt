using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Dme.Core.Xml
{
    public class Serializer
    {
        HashSet<object> _SerializedObjects = new HashSet<object>();
        XmlWriterSettings _Settings;
        Type _Type;

        public event EventHandler<SerializerFilterEventArgs> OnFilter;
        public event EventHandler<SerializerRenameEventArgs> OnRename;

        public Serializer(Type type = null)
        {
            _Settings = new XmlWriterSettings();
            _Type = type;
        }

        public void Execute(object obj, Stream output, Type type = null)
        {
            _SerializedObjects.Clear();
            _Settings.Async = false;
            using (var writer = XmlWriter.Create(output, _Settings))
            {
                WriteObject(obj, writer, true, type, true);
                writer.Flush();
            }
        }

        public async Task ExecuteAsync(object obj, Stream output, Type type = null)
        {
            _SerializedObjects.Clear();
            _Settings.Async = true;
            using (var writer = XmlWriter.Create(output, _Settings))
            {
                WriteObject(obj, writer, true, type, true);
                await writer.FlushAsync();
            }
        }

        private void WriteObject(object obj, XmlWriter writer, bool rootElement = true, Type type = null, bool defSchemas = false)
        {
            var objType = type ?? (_Type ?? obj.GetType());
            if (_SerializedObjects.Contains(obj))
                return;
            _SerializedObjects.Add(obj);
            if (rootElement)
            {
                if (defSchemas)
                    writer.WriteStartElement(DoRenameObject(obj, objType), "http://purl.oclc.org/dsdl/schematron");
                else
                    writer.WriteStartElement(DoRenameObject(obj, objType));
            }
            try
            {
                List<PropertyInfo> complexTypes = new List<PropertyInfo>();
                foreach (var propInfo in objType.GetProperties())
                {
                    if (!propInfo.PropertyType.IsPublic)
                        continue;
                    if (propInfo.GetCustomAttributes(typeof(XmlIgnoreAttribute), false).Length > 0)
                        continue;
                    var propValue = propInfo.GetValue(obj, new object[] { });
                    if(DoFilter(propInfo, propValue))
                        continue;
                    if (propValue == null)
                        continue;
                    if (propValue is IConvertible)
                    {
                        if (propValue is double)
                            writer.WriteAttributeString(DoRenameProperty(obj, objType, propInfo, propValue),
                                ((double)propValue).ToString(CultureInfo.InvariantCulture));
                        else if (propValue is float)
                            writer.WriteAttributeString(DoRenameProperty(obj, objType, propInfo, propValue),
                                ((float)propValue).ToString(CultureInfo.InvariantCulture));
                        else if (propValue is decimal)
                            writer.WriteAttributeString(DoRenameProperty(obj, objType, propInfo, propValue),
                                ((decimal)propValue).ToString(CultureInfo.InvariantCulture));
                        else if (propValue is Boolean)
                            writer.WriteAttributeString(DoRenameProperty(obj, objType, propInfo, propValue), 
                                propValue.ToString().ToLower());
                        else if (propValue is DateTime)
                            writer.WriteAttributeString(DoRenameProperty(obj, objType, propInfo, propValue),
                                ((DateTime)propValue).ToString("yyyy-dd-MM"));
                        else
                            writer.WriteAttributeString(DoRenameProperty(obj, objType, propInfo, propValue), propValue.ToString());
                    }
                    else
                        complexTypes.Add(propInfo);
                }
                foreach (var prop in complexTypes)
                {
                    var val = prop.GetValue(obj, new object[] { });
                    if (val is IEnumerable)
                    {
                        Type itemType = prop.PropertyType.GetGenericArguments().Single();
                        foreach (var i in val as IEnumerable)
                            WriteObject(i, writer, type:itemType);
                    }
                }
            }
            finally
            {
                if (rootElement)
                    writer.WriteEndElement();
            }

        }

        private bool DoFilter(PropertyInfo propInfo, object propValue)
        {
            if (OnFilter != null)
            {
                SerializerFilterEventArgs args = new SerializerFilterEventArgs
                {
                    PropInfo = propInfo,
                    Value = propValue,
                    Skip = false
                };
                OnFilter(this, args);
                return args.Skip;
            }
            else
                return false;
        }

        private string DoRenameObject(object objValue, Type tp)
        {
            if (OnRename != null)
            {
                SerializerRenameEventArgs args = new SerializerRenameEventArgs
                {
                    Name = tp.Name,
                    ObjectValue = objValue,
                    PropertyValue = null,
                    Type = tp,
                    PropInfo = null
                };
                OnRename(this, args);
                return args.Name;
            }
            else
                return tp.Name;
        }

        private string DoRenameProperty(object objValue, Type objType, PropertyInfo propInfo, object propValue)
        {
            if (OnRename != null)
            {
                SerializerRenameEventArgs args = new SerializerRenameEventArgs
                {
                    Name = propInfo.Name,
                    ObjectValue = objValue,
                    PropertyValue = propValue,
                    Type = objType,
                    PropInfo = propInfo
                };
                OnRename(this, args);
                return args.Name;
            }
            else
                return propInfo.Name;
        }
    }
}
