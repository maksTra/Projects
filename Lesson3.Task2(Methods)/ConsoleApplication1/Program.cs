using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            Point p1 = new Point(3,5);
            Point p2 = new Point(4,5);
            Point p3 = new Point(3,5);
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.Equals(p3));
            Console.WriteLine(p1 == p3);

            SelfCounter sf1 = new SelfCounter();
            SelfCounter sf2 = new SelfCounter();
            SelfCounter sf3 = new SelfCounter();
            SelfCounter sf4 = new SelfCounter();
            SelfCounter sf5 = new SelfCounter();
            SelfCounter sf6 = new SelfCounter();

            Console.WriteLine(SelfCounter.NumberOfCreatedInstancesOfThisClass);

            Console.ReadKey();
        }
    }
}
