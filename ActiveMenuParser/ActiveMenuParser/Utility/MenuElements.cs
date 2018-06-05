using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace ActiveMenuParser.Utility
{
    [XmlRoot(ElementName = "menu")]
    public class Menu
    {
        public Menu()
        {
            _items = new List<Item>();
        }
        [XmlElement(ElementName = "item")]
        public List<Item> _items { get; set; }
    }

    public class Item
    {
        public bool _isActive;

        [XmlElement(ElementName = "displayName")]
        public string _displayName;

        [XmlElement(ElementName = "path")]
        public Path _path;

        [XmlElement(ElementName = "subMenu")]
        public SubMenu _subMenu { get; set; }
    }

    public class SubMenu
    {
        public SubMenu()
        {
            _items = new List<Item>();
        }

        [XmlElement(ElementName = "item")]
        public List<Item> _items { get; set; }
    }

    public class Path
    {
        [XmlAttribute]
        public string value;
    }
}
