using System;
using System.IO;
using ActiveMenuParser.Utility;

namespace ActiveMenuParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePathArg = args[0];
            var activePathArg = args[1];

            var menu = XmlParser.DeserializeMenuFile(filePathArg);
            MenuFormatter.AssignActiveMenuItems(ref menu, ref activePathArg);
            MenuFormatter.PrintMenuToConsole(ref menu);
        }
    }
}
