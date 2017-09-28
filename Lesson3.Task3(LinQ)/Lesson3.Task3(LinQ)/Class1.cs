using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.Task3_LinQ_
{
    public static class LinQTask
    {
        public static List<BigInteger> FibonacciSequence;
        private static List<BigInteger> prime = new List<BigInteger> { 2, 3, 5, 7, 11, 13 };

        public static BigInteger FindFibo(int n)
        {
            FibonacciSequence = new List<BigInteger>();

            BigInteger member1 = new BigInteger(0);
            BigInteger member2 = new BigInteger(1);

            FibonacciSequence.Add(member1);
            FibonacciSequence.Add(member2);

            BigInteger res = new BigInteger(0);

            for (int i = 2; i <= n; i++)
            {
                res = BigInteger.Add(member1, member2);
                FibonacciSequence.Add(res);
                member1 = member2;
                member2 = res;
            }
            return res;
        }

        //Вычислите, сколько чисел являются простыми (реализовать расширяющий метод для типа int для проверки на простоту);
        public static int CountPrimeNumbers()
        {
            
            return FibonacciSequence.Where(i => i.IsPrimeNumber()).ToList().Count;
        }

        //Вычислите, сколько чисел делятся на сумму своих цифр;
        public static int CountSelfDividingNumbers()
        {
            return FibonacciSequence.Where(i => i.IsDividingBySumOfOwnNumbers()).ToList().Count;
        }

        //Вычислите, есть ли числа, которые делятся на 5;
        public static bool CheckDividingBy5()
        {
            return FibonacciSequence.Any(x => x.IsDividingBy5());
        }

        //Вычислите квадратные корни (округленные до целого вниз) всех чисел, которые имеют в составе цифру 2;
        public static List<BigInteger> GetListOfSquareRootsOfNumbersThatContains2()
        {
            return FibonacciSequence.Where(i => i.Contains2()).Select(i => (BigInteger) (Math.Exp(BigInteger.Log(i) / 2))).ToList();
        }

        //Отсортируйте числа по убывания их второй цифры;
        public static List<BigInteger> OrderByDescendingOfSecondNumber()
        {
            return FibonacciSequence.Select(i => i.ToString()).
                Where(i => i.Length>1).
                OrderByDescending(i => i[1]).
                Select(i => BigInteger.Parse(i)).
                ToList();
        }

        //Выберите последние 2 цифры для всех чисел, которые делятся на 3 и среди ближайших соседей которых (5 в каждую сторону) есть хотя бы одно, которое делится на 5;
        public static List<string> SelectByLongCondition()
        {
            //FibonacciSequence = OrderByDescendingOfSecondNumber();
                
                return FibonacciSequence.Where(x => x.ToString().Length > 1).
                Where(x => x.IsDividingBy3()).
                Where(x => x.OneOfNeighboursDividesBy5()).
                Select(x => x.ToString().Substring(x.ToString().Length - 2)).
                ToList();

        }

        //Посчитайте число которое имеет наибольшую сумму квадратов цифр;
        public static BigInteger MaxSumOfSqrtOfNumbers()
        {
            return FibonacciSequence.OrderByDescending(x => x.ToString().Select(a => Math.Pow(Int32.Parse(a.ToString()),2)).Sum()).First();
        }

        //Посчитайте среднее количество нулей в числах;
        public static double AverageNumberOfZero()
        {
            return FibonacciSequence.Select(x => x.ToString().Length - x.ToString().Replace("0", "").Length).Average();
        }

        //Метод, расширяющий BigInteger, для проверки на простоту
        public static bool IsPrimeNumber(this BigInteger number)
        {
            bool isPrime = true;

            string s = number.ToString();
            //Если число(как минимум, двухзначное) заканчивается на 0,2,4,5,6,8, то оно точно не простое
            if((s.Length > 1 && (s.EndsWith("2") || s.EndsWith("4") || s.EndsWith("6") || s.EndsWith("8") || s.EndsWith("0") || s.EndsWith("5") || number.IsDividingBy3()))||(s.Length==1 && (s=="4" || s=="8")))
            {
                return false;
            }

            for (int divisor = 3; divisor <= (Math.Exp(BigInteger.Log(number) / 2)); divisor+=2)//(Math.Exp(BigInteger.Log(number) / 2)) - корень из бигинтежера
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        /*
        public static bool IsPrimeNumber(this BigInteger number)
        {
            bool result = false;

            if (number <= 3)
            {
                result = true;
            }
            else if (number % 2 != 0 && number % 3 != 0)
            {
                int k = 5;
                int step = 2;

                while (k * k <= number && number % k != 0)
                {
                    k = k + step;
                    step = 6 - step;
                }

                if (number == k || number % k != 0)
                    result = true;
            }
            return result;
        }*/

        //Метод, расширяющий BigInteger, проверяющий, делится ли число на сумму своих цифр без остатка
        public static bool IsDividingBySumOfOwnNumbers(this BigInteger number)
        {
            string s = number.ToString();
            //получаем сумму цифр, составляющих число
            int sum = s.ToCharArray().Select(x => Int32.Parse(x.ToString())).Sum();
           
            if (number != 0 && number % sum == 0)
            {
                return true;
            }
            return false;
        }


        //Метод, расширяющий BigInteger, проверяющий, делится ли число на 5
        public static bool IsDividingBy5(this BigInteger number)
        {
            string s = number.ToString();
            if (number != 0 && (s.EndsWith("0") || s.EndsWith("5")))
            {
                return true;
            }
            return false;
        }



        //Метод, расширяющий BigInteger, проверяющий, имеет ли число в своём составе цифру 2
        public static bool Contains2(this BigInteger number)
        {
            string s = number.ToString();
            if (s.Contains("2"))
            {
                return true;
            }
            return false;
        }

        //Метод, расширяющий BigInteger, проверяющий, делится ли число на 3
        public static bool IsDividingBy3(this BigInteger number)
        {
            string s = number.ToString();
            int sum = s.ToCharArray().Select(x => Int32.Parse(x.ToString())).Sum();
            if (sum % 3 == 0)
            {
                return true;
            }
            return false;
        }

        //Метод, расширяющий BigInteger, определяющий, делиться ли кто-то из соседей на 5
        public static bool OneOfNeighboursDividesBy5(this BigInteger number)
        {
            int position = FibonacciSequence.IndexOf(number);

            if (position >= 5 && position <= FibonacciSequence.Count - 5)
            {
                for (int i = position - 5; i < position + 5; i++)
                {
                    if (i == position) { continue;}
                    FibonacciSequence[i].IsDividingBy5();
                    return true;
                }
            }
            return false;
        }
    }
}
