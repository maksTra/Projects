using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;

namespace SerializationDemonstration
{
    public class Serializer
    {
        public static void Serialize(string path, BookList books)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(BookList));
                serializer.Serialize(stream, books);
            }
        }

        public static BookList Deserialize(string path)
        {
                using (XmlTextReader xreader = new XmlTextReader(new FileStream(path, FileMode.Open)))
                {
                    var serializer = new XmlSerializer(typeof(BookList));
                    return serializer.Deserialize(xreader) as BookList;
                }
        }
    }
}
