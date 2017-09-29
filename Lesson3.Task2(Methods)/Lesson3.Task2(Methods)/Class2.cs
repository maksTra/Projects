using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.Task2_Methods_
{
    public class FiboAndFactor
    {
        public static List<BigInteger> FibonacciSequence;

        public static BigInteger FindFibo(int n)
        {
            BigInteger member1 = new BigInteger(0);
            BigInteger member2 = new BigInteger(1);

            //FibonacciSequence = new List<BigInteger>();
            //FibonacciSequence.Add(member1);
            //FibonacciSequence.Add(member2);

            BigInteger res = new BigInteger(0);

            for (int i = 2; i <= n; i++)
            {
                res = BigInteger.Add(member1, member2);
                //FibonacciSequence.Add(res);
                member1 = member2;
                member2 = res;
            }
            return res;
        }

        public static BigInteger FindFactorial(int n)
        {
            BigInteger current = new BigInteger(1);
            for (int i = 2; i <= n; ++i)
                current *= i;
            return current;
        }
    }
}
