using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson4.Task1
{
    public class XMLHandler
    {
        public static void GetFromXML()
        {
            XDocument xdoc = XDocument.Load("D:/RD. HW - AT Lab#. 05 - Customers.xml");

            //Получаем список Customer которые являются вложенными в тег customers
            List<XElement> custList = xdoc.Elements().First().
                                           Elements().ToList();

            //var cust = custList.Single(c => c.Element("id").Value == "ALFKI"); 

            //Выдайте список всех клиентов, чей суммарный оборот (сумма всех заказов) превосходит некоторую величину X. 
            //Продемонстрируйте выполнение запроса с различными X (подумайте, можно ли обойтись без копирования запроса несколько раз)

            

            int y = 100000;

            List<string> customersWithTotalMoreThan100000 = custList.Where(c => c.Element("orders").Elements().
                Sum(x => Double.Parse(x.Element("total").Value)) > y).
                Select(z => z.Element("id").Value).ToList();

            foreach (string x in customersWithTotalMoreThan100000)
            {
                Console.WriteLine(x);
            }
            //Написать тест! который будет сравнивать id 


            //Сгруппировать клиентов по странам.
            Console.WriteLine("-------------------------------");

            var a = custList.GroupBy(x => x.Element("country").Value, u => u).ToDictionary(k => k.Key, v => v.ToList());

            foreach (var elem in a.Keys)
            {
                Console.WriteLine(elem);

                foreach (var hhh in a[elem])
                {
                    var xElement = hhh.Element("id");
                    if (xElement != null) Console.WriteLine(xElement.Value);
                }
            }

            //Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X
            Console.WriteLine("-------------------------------");


            double orderMoreThan10000 = 16000;

            var customersWithOrderMoreThan10000 = custList.Where(c => c.Element("orders").Elements().
                                                   Any(x => Double.Parse(x.Element("total").Value) > orderMoreThan10000)).
                                                   Select(z => z.Element("id").Value).ToList();

            foreach (string x in customersWithOrderMoreThan10000)
            {
                Console.WriteLine(x);
            }

            //Выдайте список клиентов с указанием, начиная с какого месяца какого года они стали клиентами 
            //(принять за таковые месяц и год самого первого заказа)
            Console.WriteLine("-------------------------------");

            var whenCustomersBecameClients =
                custList.Select(l => l.Element("id").Value + " " + l.Element("orders")
                            .Elements()
                            .Min(x => x.Element("orderdate").Value));

            foreach (string x in whenCustomersBecameClients)
            {
                Console.WriteLine(x);
            }


        }
    }

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            XMLHandler.GetFromXML();
        }
    }
}
