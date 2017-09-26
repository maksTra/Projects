using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson3.Task2_Methods_;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FiboAndFactor.FindFibo(200));
            Console.WriteLine(FiboAndFactor.FindFactorial(10));
            Console.ReadKey();
        }
    }
}
