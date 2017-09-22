using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            Console.WriteLine("+");
            string input2 = Console.ReadLine();
            int converted1;
            int converted2;
            if (Int32.TryParse(input1, out converted1) && Int32.TryParse(input2, out converted2))
            {
                Console.WriteLine("= \n{0}", converted1 + converted2);
            }
            else
            {
                Console.WriteLine("Wrong arguments");
            }
            Console.ReadKey();
        }
    }
}
