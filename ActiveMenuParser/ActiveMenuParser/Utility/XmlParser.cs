using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace ActiveMenuParser.Utility
{
    public static class XmlParser
    {
        public static Menu DeserializeMenuFile(string menuFilePath)
        {
            var serializer = new XmlSerializer(typeof(Menu));
            using (XmlReader reader = XmlReader.Create(menuFilePath))
            {
                var menu = (Menu)serializer.Deserialize(reader);
                return menu;
            }
        }
    }
}
