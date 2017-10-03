using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson4.Task1
{
    public class XMLHandler
    {
        public XDocument Xdoc {get; set; }
        public List<XElement> custList { get; set; }

        public XMLHandler(string path)
        {
            this.Xdoc = XDocument.Load(path);
            //Получаем список Customer которые являются вложенными в тег customers
            custList = Xdoc.Elements().First().Elements().ToList();
        }

        public List<string> GetCustomersWithTotalMoreThan(int total)
        {
            //Выдайте список всех клиентов, чей суммарный оборот (сумма всех заказов) превосходит некоторую величину X. 
            //Продемонстрируйте выполнение запроса с различными X (подумайте, можно ли обойтись без копирования запроса несколько раз)
            
            List <string> customersWithTotalMoreThan =
                custList.Where(c => c.Element("orders").Elements().Sum(x => Double.Parse(x.Element("total").Value)) > total).
                    Select(z => z.Element("id").Value).ToList();
            
            return customersWithTotalMoreThan;
        }

        public Dictionary<string, List<XElement>> GroupCustomersByCountry()
        {
            //Сгруппировать клиентов по странам.

            var sortedDictionary = custList.GroupBy(x => x.Element("country").Value, u => u).ToDictionary(k => k.Key, v => v.ToList());
            
            return sortedDictionary;
        }

        public List<XElement> GetCustomersWithOrderMoreThan(int order)
        {
            //Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X
            

            var customersWithOrderMoreThan = custList.Where(c => c.Element("orders").Elements().
                    Any(x => Double.Parse(x.Element("total").Value) > order)).ToList();
            
            return customersWithOrderMoreThan;
        }

        public List<String> GetMonthAndYearOfFirstOrder()
        {
            //Выдайте список клиентов с указанием, начиная с какого месяца какого года они стали клиентами 
            //(принять за таковые месяц и год самого первого заказа)
          
            var whenCustomersBecameClients =
                custList.Select(l => l.Element("id").Value + " " + l.Element("orders")
                                         .Elements()
                                         .Min(x => x.Element("orderdate").Value)).ToList();
            
            return whenCustomersBecameClients;
        }

        public List<XElement> SortByYearMonthSumName()
        {
            //Сделайте предыдущее задание, но выдайте список отсортированным по году, месяцу, оборотам клиента 
            //(от максимального к минимальному) и имени клиента
           
            var sortedCustomers =
                custList.Where(a => a.Element("orders").Elements().Any()).OrderBy(
                        l => l.Element("orders").Elements().Min(x => x.Element("orderdate").Value.Substring(0, 7))).
                    ThenByDescending(
                        j => j.Element("orders").Elements().Sum(k => Double.Parse(k.Element("total").Value))).
                    ThenBy(n => n.Element("name").Value)
                    .ToList();
            
            return sortedCustomers;
        }

        public List<XElement> GetClientsWithNullThings()
        {
            //Укажите всех клиентов, у которых указан нецифровой код или не заполнен регион или в телефоне не указан код оператора 
            //(для простоты считаем, что это равнозначно «нет круглых скобочек в начале»).
            
            var listWithEmptyParams = custList.
                Where(x => x.Element("region") == null ||
                           !x.Element("phone").Value.StartsWith("(") ||
                            x.Element("postalcode").Value.Any(z => Char.IsLetter(z))).
                ToList();
            
            return listWithEmptyParams;
        }

        public Dictionary<string, string> GetAverageSumAndIntensity()
        {
            //Рассчитайте среднюю прибыльность каждого города (среднюю сумму заказа по всем клиентам из данного города) 
            //и среднюю интенсивность (среднее количество заказов, приходящееся на клиента из каждого города)
       var averageSums = custList.GroupBy(x => x.Element("city").Value, u => u)
                .ToDictionary(k => k.Key, v => $"{v.Average(l => l.Element("orders").Elements().Sum(x => double.Parse(x.Element("total").Value)) / l.Element("orders").Elements().Count()):0.00} {v.Average(l => l.Element("orders").Elements().Count()):0.00}");

            
            return averageSums;
        }

        public Dictionary<string,int> GetStatsByMonth()
        {
            //Сделайте среднегодовую статистику активности клиентов по месяцам (без учета года), 
            //статистику по годам, по годам и месяцам (т.е. когда один месяц в разные годы имеет своё значение).
            var statisticsByMonth =
                custList.Descendants("order")
                    .GroupBy(x => x.Element("orderdate").Value.Substring(5, 2), u => u)
                    .ToDictionary(k => k.Key, v => v.ToList().Count);

            return statisticsByMonth;
        }

        public Dictionary<string, int> GetStatsByYear()
        {
            var statisticsByYear =
                custList.Descendants("order")
                    .GroupBy(x => x.Element("orderdate").Value.Substring(0, 4), u => u)
                    .ToDictionary(k => k.Key, v => v.ToList().Count);

            return statisticsByYear;
        }

        public Dictionary<string, int> GetStatsByYearAndMonth()
        {
           var statisticsByYearAndMonth =
               custList.Descendants("order")
                   .GroupBy(x => x.Element("orderdate").Value.Substring(0, 7), u => u)
                   .ToDictionary(k => k.Key, v => v.ToList().Count);
           
            return statisticsByYearAndMonth;
        }
    }
}

