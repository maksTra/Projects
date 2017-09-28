using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lesson3.Task3_LinQ_;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinQTask.FindFibo(200);


            Console.WriteLine("Fibonacci Sequense:");
            foreach (BigInteger b in LinQTask.FibonacciSequence)
            {
                Console.WriteLine(b);
                //Console.WriteLine(b +$" {b.IsPrimeNumber()}");
            }

           // Console.WriteLine("Count prime numbers:");
            // Console.WriteLine(LinQTask.CountPrimeNumbers());

            Console.WriteLine("\nCount self-dividing numbers:");
            Console.WriteLine(LinQTask.CountSelfDividingNumbers());

            List<BigInteger> a = LinQTask.FibonacciSequence.Where(i => i.IsDividingBySumOfOwnNumbers()).ToList();
            foreach (BigInteger bbb in a)
            {
                Console.WriteLine(bbb);
            }

            Console.WriteLine("\nList has number that can be divided by 5:");
            Console.WriteLine($"{LinQTask.CheckDividingBy5()}");

            Console.WriteLine("\nChecking sqRt for numbers that contains 2");
            foreach (BigInteger b in LinQTask.GetListOfSquareRootsOfNumbersThatContains2())
            {
                Console.WriteLine(b);
            }

            Console.WriteLine("\nOrdering by second number");
            foreach (BigInteger b in LinQTask.OrderByDescendingOfSecondNumber())
            {
                Console.WriteLine(b);
            }

            Console.WriteLine("\nTask with last two numbers");
            foreach (string b in LinQTask.SelectByLongCondition())
            {
                Console.WriteLine(b);
            }

            Console.WriteLine("\nMax sum of sqrts has:");
            Console.WriteLine(LinQTask.MaxSumOfSqrtOfNumbers());

            Console.WriteLine("\nAverage number of zeros");
            Console.WriteLine(LinQTask.AverageNumberOfZero());
            
            Console.ReadKey();
        }
    }
}
