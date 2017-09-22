using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;


namespace ConsoleApplication2
{
    class Program
    {
        private static Program _program;

        static void Main(string[] args)
        {
            _program = new Program();

            string input1=null;
            string input2=null;
            double converted1 = 0;
            double converted2 = 0;

            try
            {
                _program.GetInputData(ref input1, ref input2);
                if (!_program.CheckData(input1, input2, ref converted1, ref converted2))
                {
                    Console.WriteLine("Wrong arguments");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.WriteLine(_program.GetResult(converted1, converted2));
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong configuration");
            }
            Console.ReadKey();
        }

        //Метод, считывающий данные в зависимости от источника
        public void GetInputData(ref string input1, ref string input2)
        {
            string wayOfReading = ConfigurationManager.AppSettings["way of reading"];

            if (wayOfReading == "resource")
            {
                //из файла с ресурсами
                input1 = Resource1.firstParam;
                input2 = Resource1.secondParam;
            }
            else
            if (wayOfReading == "console")
            {
                //из консоли
                input1 = Console.ReadLine();
                input2 = Console.ReadLine();
            }
            else
            {
                throw new Exception();
            }
        }
        
        //Метод, проверяющий, можно ли конверировать входные данные в double
        public bool CheckData(string input1, string input2, ref double converted1, ref double converted2)
        {
            return (Double.TryParse(input1, out converted1) && Double.TryParse(input2, out converted2));
        }

        //Метод возвращает строку с результатом в зависимости от выбранного действия в файле конфигураций
        public string GetResult(double converted1, double converted2)
        {
            string action = ConfigurationManager.AppSettings["action"];
            if (action == "only sum")
            {
                return _program.OnlySum(converted1, converted2);
            }
            if (action == "all actions")
            {
                return _program.AllActions(converted1, converted2);
            }
                throw new Exception();
        }

        //Метод возвращает строку с результатом сложения двух чисел
        public string OnlySum(double converted1, double converted2)
        {
            return $"sum result: {converted1 + converted2}";
        }

        //Метод возвращает строку с результатом сложения, вычитания, умножения, деления
        public string AllActions(double converted1, double converted2)
        {
            Calculator calculator = new Calculator();
            return $"sum result: {calculator.Sum(converted1, converted2)}\n" +
                   $"diff result:{calculator.Diff(converted1, converted2)}\n" +
                   $"mult result:{calculator.Mult(converted1, converted2)}\n" +
                   $"div result:{calculator.Div(converted1, converted2)}";
        }
    }
}
