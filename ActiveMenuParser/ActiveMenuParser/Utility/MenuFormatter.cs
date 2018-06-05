using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveMenuParser.Utility
{
    public static class MenuFormatter
    {
        public static void AssignActiveMenuItems(ref Menu menu, ref string activePath)
        {
            foreach(var item in menu._items)
            {
                if (item._path.value == activePath || AssignActiveItems(item, ref activePath))
                {
                    item._isActive = true;
                    return;
                }
            }
        }

        public static bool AssignActiveItems(Item item, ref string activePath)
        {
            if (item._subMenu != null)
            {
                foreach (var subItem in item._subMenu._items)
                {
                    if (subItem._path.value == activePath || AssignActiveItems(subItem, ref activePath))
                    {
                        subItem._isActive = true;
                        return true;
                    }
                }
            }
            return false;
        }

        public static void PrintMenuToConsole(ref Menu menu)
        {
            foreach(var item in menu._items)
            {
                var depth = 0;
                PrintItemsToConsole(item, ref depth);
            }
        }

        public static void PrintItemsToConsole(Item item, ref int depth)
        {
            var builder = new StringBuilder();
            for (var i = 0; i != depth; ++i)
            {
                builder.Append("\t");
            }
            if (item._isActive) builder.AppendFormat("{0}, {1} {2}", item._displayName, item._path.value, "ACTIVE");
            else builder.AppendFormat("{0}, {1}", item._displayName, item._path.value);
            Console.WriteLine(builder);
            if (item._subMenu != null)
            {
                depth += 1;
                foreach (var subItem in item._subMenu._items)
                {
                    PrintItemsToConsole(subItem, ref depth);
                }
            }
        }
    }
}
