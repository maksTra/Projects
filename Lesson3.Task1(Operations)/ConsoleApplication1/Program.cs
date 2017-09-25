using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitLogger();

            Console.WriteLine("Enter the type of equation: 1 for linear, 2 for quadratic:");
            Logger.Log.Info("Message2");

            string TypeOfEquation = Console.ReadLine();

            if (TypeOfEquation == "1")
            {
                double doubleA;
                double doubleB;

                double x;

                Console.WriteLine("Enter arguments of linear equation ax + b = 0.\n" +
                                  "Enter a:");
                string a = Console.ReadLine();
                
                if (!double.TryParse(a, out doubleA))
                {
                    Console.WriteLine("Argument a is not correct");
                    Environment.Exit(0);
                }
                Console.WriteLine("Enter b:");
                string b = Console.ReadLine();
                if (!double.TryParse(b, out doubleB))
                {
                    Console.WriteLine("Argument b is not correct");
                    Environment.Exit(0);
                }
                EquationManager.SolveEquation(doubleA, doubleB, out x);
                Console.WriteLine(x);
            } else
            if (TypeOfEquation == "2")
            {
                double doubleA;
                double doubleB;
                double doubleC;

                double x1;
                double x2;

                Console.WriteLine("Enter arguments of quadratic equation ax^2 + bx + c = 0.\n" +
                  "Enter a:");
                string a = Console.ReadLine();
                if (!double.TryParse(a, out doubleA))
                {
                    Console.WriteLine("Argument a is not correct");
                    Environment.Exit(0);
                }
                Console.WriteLine("Enter b:");
                string b = Console.ReadLine();
                if (!double.TryParse(b, out doubleB))
                {
                    Console.WriteLine("Argument b is not correct");
                    Environment.Exit(0);
                }
                Console.WriteLine("Enter c:");
                string c = Console.ReadLine();
                if (!double.TryParse(c, out doubleC))
                {
                    Console.WriteLine("Argument c is not correct");
                    Environment.Exit(0);
                }
                try
                {
                    EquationManager.SolveEquation(doubleA, doubleB, doubleC, out x1, out x2);
                    Console.WriteLine($"{x1} {x2}");
                }
                catch (WrongDiscriminantException e)
                {
                    Console.WriteLine("D < 0. No solutions for this equation");
                }
                catch (WrongArgumentAException e)
                {
                    Console.WriteLine("Argument a cannot be zero.");
                }
            }
            else
            {
                Console.WriteLine("Wrong type of equation");
            }

            Console.ReadKey();
        }

        
    }
}

