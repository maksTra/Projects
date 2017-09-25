using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class EquationManager
    {
        public static void SolveEquation(double a, double b, double c, out double x1, out double x2)
        {
            if (a == 0)
            {
                throw new WrongArgumentAException();
            }

            double d = b * b - 4 * a * c;
            if (d < 0)
            {
                throw new WrongDiscriminantException();
            }
            if (d == 0)
            {
                x1 = -b / (2 * a);
                x2 = x1;
            }
            else
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
            }
        }

        public static void SolveEquation(double a, double b, out double x)
        {
            x = -b / a;
        }
    }
}
