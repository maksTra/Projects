using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace ClassLibrary2
{
    public class Calculator
    {
        public double Sum(double first, double second)
        {
            double output = first + second;
            return output;
        }

        public double Diff(double first, double second)
        {
            double output = first - second;
            return output;
        }

        public double Mult(double first, double second)
        {
            double output = first * second;
            return output;
        }

        public double Div(double first, double second)
        {
            double output = first / second;
            return output;
        }
    }
}
