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
            Console.WriteLine("Enter the type of equation: 1 for linear, 2 for quadratic. Enter 3 for multiplying matricies from file");
            Logger.Log.Info("Application was started");

            string TypeOfEquation = Console.ReadLine();
            
            if (TypeOfEquation == "1")
            {
               TalkWithUserSolvingLinear();
            } else
            if (TypeOfEquation == "2")
            {
                TalkWithUserSolvingQuadratic();
            }
            else if (TypeOfEquation == "3")
            {
               TalkWithUserSolvingMatricies();
            }
            else
            {
                Console.WriteLine("Wrong type of equation");
            }
            Console.ReadKey();
        }

        //Общение с пользователем, решая линейное уравнение
        public static void TalkWithUserSolvingLinear()
        {
            //решаем линейное уравнение
            double doubleA;
            double doubleB;
            double x;

            Console.WriteLine("Enter arguments of linear equation ax + b = 0.");

            ReadDataForLinearEquation(out doubleA, out doubleB);
            EquationManager.SolveEquation(doubleA, doubleB, out x);

            Logger.Log.Info($"({doubleA})*x + ({doubleB}) = 0; x = {x};");
            Console.WriteLine($"x = {x: 0.00}");
        }

        //Общение с пользователем, решая квадратное уравнение
        public static void TalkWithUserSolvingQuadratic()
        {
            //решаем квадратное уравнение
            double doubleA;
            double doubleB;
            double doubleC;
            double x1;
            double x2;

            Console.WriteLine("Enter arguments of quadratic equation ax^2 + bx + c = 0.");
            ReadDataForQuadraticEquation(out doubleA, out doubleB, out doubleC);

            try
            {
                EquationManager.SolveEquation(doubleA, doubleB, doubleC, out x1, out x2);
                Console.WriteLine($"x1 = {x1:0.00} x2 = {x2:0.00}");
                Logger.Log.Info($"({doubleA})*x^2 + ({doubleB})*x + ({doubleC}) = 0; x1 = {x1}, x2 = {x2};");
            }
            catch (WrongDiscriminantException e)
            {
                Console.WriteLine("D < 0. No solutions for this equation");
                Logger.Log.Info($"({doubleA})*x^2 + ({doubleB})*x + ({doubleC}) = 0; D<0, no solutions");
            }
            catch (WrongArgumentAException e)
            {
                Console.WriteLine("Argument a cannot be zero.");
                Logger.Log.Info($"({doubleA})*x^2 + ({doubleB})*x + ({doubleC}) = 0; Argument a cannot be zero");
            }
        }

        //Общение с пользователем, решая матрицы
        public static void TalkWithUserSolvingMatricies()
        {
            //перемножаем матрицы
            try
            {
                Console.WriteLine(EquationManager.ShowResultMatrixToConsole());
            }
            catch (MatriciesWithWrongDimensionsException e)
            {
                Console.WriteLine("Matricies with these dimensions couldn't be multiplyed. Check file with matricies");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("File has wrong data(incorrect dimensions or incorrect number of arguments). Check it!");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Matrix has wrong data. Non-numerical data couldn't be a part of matrix.");
            }
        }

        //читает данные из консоли, пока не будут введены корректные данные.(для линейного уравнения)
        public static void ReadDataForLinearEquation(out double doubleA, out double doubleB)
        {
            while (true)
            {
                
                Console.WriteLine("Enter a:");
                string a = Console.ReadLine();
                if (!double.TryParse(a, out doubleA))
                {
                    Logger.Log.Warn($"Argument a = ({a}) is not correct");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Enter b:");
                string b = Console.ReadLine();
                if (!double.TryParse(b, out doubleB))
                {
                    Logger.Log.Warn($"Argument b = ({b}) is not correct");
                    continue;
                }
                break;
            }
        }

        //читает данные из консоли, пока не будут введены корректные данные.(для квадратного уравнения)
        public static void ReadDataForQuadraticEquation(out double doubleA, out double doubleB, out double doubleC)
            {
            ReadDataForLinearEquation(out doubleA, out doubleB);
            while (true)
            {
                Console.WriteLine("Enter c:");
                string c = Console.ReadLine();
                if (!double.TryParse(c, out doubleC))
                {
                    Logger.Log.Warn($"Argument c = ({c}) is not correct");
                    continue;
                }
                break;
            }
        }
   }
}

