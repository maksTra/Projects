using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Task2
{
    public class LinesManager
    {
        //список, который хранит целочисленные значения
        public List<int> ListOfIntegers { get; private set; }
        //список, который хранит вещественные значения
        public List<double> ListOfDoubles { get; private set; }
        //список, который хранит не-числа
        public List<string> ListOfStrings { get; private set; }

        public LinesManager()
        {
            ListOfIntegers = new List<int>();
            ListOfDoubles = new List<double>();
            ListOfStrings = new List<string>();
        }

        //Метод определяет, к какой категории относится строка
        public virtual void DefineLine(string currentLine)
        {
            int currentInt;
            double currentDouble;

            if (int.TryParse(currentLine, out currentInt))
            {
                ListOfIntegers.Add(currentInt);
                currentDouble = (double)currentInt;
                ListOfDoubles.Add(currentDouble);
            }
            else
            if (double.TryParse(currentLine, out currentDouble))
            {
                ListOfDoubles.Add(currentDouble);
            }
            else
            {
                ListOfStrings.Add(currentLine);
            }
        }

        //Метод сортирует значения списка стрингов по длине, при равной длине - по коду символов
        public void OrderListOfStringsByLengthThenBySymbols()
        {
            ListOfStrings = new List<string>(ListOfStrings.OrderBy(x => x.Length).ThenBy(x => x));
        }

        //Метод возвращает среднее значение списка double
        public double GetAverageOfDoubles()
        {
            double sum = GetSumOfDoubles();
            double average = sum / ListOfDoubles.Count;
            return average;
        }

        //Метод возвращает среднее значение списка int
        public double GetAverageOfIntegers()
        {
            double sum = GetSumOfIntegers();
            double average = sum / ListOfIntegers.Count;
            return average;
        }

        //Метод возвращает сумму всех значений списка double
        public double GetSumOfDoubles()
        {
            double sum = 0;
            foreach (double d in ListOfDoubles)
            {
                sum += d;
            }
            return sum;
        }

        //Метод возвращает среднее значение списка int
        public double GetSumOfIntegers()
        {
            double sum = 0;
            foreach (double d in ListOfIntegers)
            {
                sum += d;
            }
            return sum;
        }
    }
}
