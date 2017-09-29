using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Lesson4.Task1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLHandler.GetFromXML();
            Console.ReadKey();
        }
    }
}
