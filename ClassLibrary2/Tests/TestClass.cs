using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary2;

namespace Tests
{   
    [TestClass]
    public class TestClass
    {
        private Calculator c;

        [TestInitialize]
        public void SetUp()
        {
            c = new Calculator();
        }

        [TestMethod]
        public void Test_Sum()
        {
            Assert.AreEqual(21, c.Sum(16,5),"Sum is not correct");
        }

        [TestMethod]
        public void Test_Diff()
        {
            Assert.AreEqual(11, c.Diff(16, 5), "Diff is not correct");
        }

        [TestMethod]
        public void Test_Mult()
        {
            Assert.AreEqual(80, c.Mult(16, 5), "Mult is not correct");
        }

        [TestMethod]
        public void Test_Div()
        {
            Assert.AreEqual(3.2, c.Div(16, 5), "Div is not correct");
        }
    }
}
