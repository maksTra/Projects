using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using NUnit.Framework;

namespace SerializationDemonstration
{
    public class Demonstration
    {
        public void Demonstrate()
        {
           var books = Serializer.Deserialize(ConfigurationManager.AppSettings["pathToXML"]);
           Serializer.Serialize(ConfigurationManager.AppSettings["result"], books);
        }
    }
    
    [TestFixture]
    class TestDemo
    {
        [Test]
        public static void TestMethod()
        {
            new Demonstration().Demonstrate();
        }
    }
    



}

