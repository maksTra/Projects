using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationDemonstration
{
    [XmlRoot(ElementName = "catalog", Namespace = "http://library.by/catalog")]
    public class BookList
    {
        public BookList()
        {
            Books = new List<Book>();
        }

        

        [XmlElement("book")]
        public List<Book> Books { get; set; }
    }
}
