using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.Task2_Methods_
{
    public class SelfCounter
    {
        public static int NumberOfCreatedInstancesOfThisClass;

        public SelfCounter()
        {
            NumberOfCreatedInstancesOfThisClass++;
        }
    }
}
