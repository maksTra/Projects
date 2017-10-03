using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lesson4.Task1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MyTestClass
    {
        private XMLHandler xmlh;
        private XElement newNode;

        [TestInitialize]
        public void SetUp()
        {
            xmlh = new XMLHandler(ConfigurationManager.AppSettings["pathToXML"]);
        }
        
        private void addCustomer()
        {
            newNode = new XElement("customer",
               new XElement("id", "TESTNAME"),
               new XElement("name", "Test name"),
               new XElement("city", "Minsk"),
               new XElement("country", "Belarus"),
               new XElement("phone", "(017) 292-41-66"),
               new XElement("orders",
                   new XElement("order",
                       new XElement("id", "TestOrder1"),
                       new XElement("orderdate", "1997-08-31T00:00:00"),
                       new XElement("total", "200000.01")
                   ),
                   new XElement("order",
                       new XElement("id", "TestOrder2"),
                       new XElement("orderdate", "1995-07-31T00:00:00"),
                       new XElement("total", "205800.01")
                   )
               )
           );
            xmlh.custList.Add(newNode);
        }

        [TestCleanup]
        private void removeCustomer()
        {
            xmlh.custList.RemoveAt(xmlh.custList.Count - 1);
        }


        [TestMethod]
        public void Test_GetCustomersWithTotalMoreThan()
        {
            int count1 = xmlh.GetCustomersWithTotalMoreThan(100000).Count;
            addCustomer();
            int count2 = xmlh.GetCustomersWithTotalMoreThan(100000).Count;
            Assert.AreEqual(count1 + 1, count2);
        }

        [TestMethod]
        public void Test_GroupCustomersByCountry()
        {
            addCustomer();
            bool result = xmlh.GroupCustomersByCountry().ContainsKey("Belarus");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Test_GetCustomersWithOrderMoreThan()
        {
            int count1 = xmlh.GetCustomersWithOrderMoreThan(200000).Count;
            addCustomer();
            int count2 = xmlh.GetCustomersWithOrderMoreThan(200000).Count;
            Assert.AreEqual(count1 + 1, count2);
        }

        [TestMethod]
        public void Test_GetMonthAndYearOfFirstOrder()
        {
            addCustomer();
            bool result = xmlh.GetMonthAndYearOfFirstOrder().Contains("TESTNAME 1995-07-31T00:00:00");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Test_SortByYearMonthSumName()
        {
            addCustomer();
            XElement result = xmlh.SortByYearMonthSumName()[0];
            Assert.AreEqual(result, newNode);
        }

        [TestMethod]
        public void Test_GetClientsWithNullThings()
        {
            addCustomer();
            bool result = xmlh.GetClientsWithNullThings().Contains(newNode);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Test_GetAverageSumAndIntensity()
        {
            addCustomer();
            string a = xmlh.GetAverageSumAndIntensity()["Minsk"];
            string b = "202900.01 2.00";
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void Test_GetStatsByMonth()
        {
            int before = xmlh.GetStatsByMonth()["08"];
            addCustomer();
            int after = xmlh.GetStatsByMonth()["08"];
            Assert.AreEqual(before + 1, after);
        }

        [TestMethod]
        public void Test_GetStatsByYear()
        {
            int before = xmlh.GetStatsByYear()["1997"];
            addCustomer();
            int after = xmlh.GetStatsByYear()["1997"];
            Assert.AreEqual(before + 1, after);
        }

        [TestMethod]
        public void GetStatsByYearAndMonth()
        {
            int before = xmlh.GetStatsByYearAndMonth()["1997-08"];
            addCustomer();
            int after = xmlh.GetStatsByYearAndMonth()["1997-08"];
            Assert.AreEqual(before + 1, after);
        }
    }
}
 