using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Task2
{
    class Program
    {
        public static LinesManager Manager;

        static void Main(string[] args)
        {
            Program program = new Program();
            Manager = new LinesManager();

            Console.WriteLine("Enter line(s). Write \"stop\" to stop input:");

            while (true)
            {
                string currentLine = Console.ReadLine();
                if (currentLine == "stop")
                {
                    break;
                }
                Manager.DefineLine(currentLine);
            }
            program.ShowListOfIntegers();
            program.ShowListOfDoubles();
            Manager.OrderListOfStringsByLengthThenBySymbols();
            program.ShowListOfStrings();
            Console.ReadKey();
        }

        //Метод выводит в консоль список целых чисел
        public void ShowListOfIntegers()
        {
            if (Manager.ListOfIntegers.Count != 0)
            {
                Console.WriteLine("\nInteger numbers:");
                foreach (int integerNumber in Manager.ListOfIntegers)
                {
                    Console.WriteLine("{0, 100}", integerNumber);
                }
                Console.WriteLine("Average:{0, 92:0.00}", Manager.GetAverageOfIntegers());
            }
        }

        //Метод выводит в консоль список вещественных чисел
        public void ShowListOfDoubles()
        {
            if (Manager.ListOfDoubles.Count != 0)
            {
                Console.WriteLine("\nDouble numbers:");
                foreach (double doubleNumber in Manager.ListOfDoubles)
                {
                    Console.WriteLine("{0, 100:0.00}", doubleNumber);
                }
                Console.WriteLine("Average:{0, 92:0.00}", Manager.GetAverageOfDoubles());
            }
        }

        //Метод выводит в консоль список строк
        public void ShowListOfStrings()
        {
            if (Manager.ListOfStrings.Count != 0)
            {
                Console.WriteLine("\nStrings:");
                foreach (string s in Manager.ListOfStrings)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
