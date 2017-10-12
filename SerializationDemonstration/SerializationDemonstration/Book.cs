using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDemonstration
{
    public class Book
    {
        [XmlAttribute("id")]
        public string id;
        [XmlElement("isbn")]
        public string Isbn { get; set; }
        [XmlElement("author")]
        public string Author { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("genre")]
        public GenreEnum Genre;
        [XmlElement("publisher")]
        public string Publisher { get; set; }
        [XmlElement("publish_date")]
        public DateTime PublishDate { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("registration_date")]
        public DateTime RegistrationDate { get; set; }

        public enum GenreEnum 
        {
            [XmlEnum("Computer")]
            Computer,
            [XmlEnum("Fantasy")]
            Fantasy,
            [XmlEnum("Romance")]
            Romance,
            [XmlEnum("Horror")]
            Horror,
            [XmlEnum("Science Fiction")]
            ScienceFiction
        }

        /*public Book(string isbn, string author, string title, GenreEnum genre, string publisher, DateTime publishDate,
            string description, DateTime registrationDate)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            Genre = genre;
            Publisher = publisher;
            PublishDate = publishDate;
            Description = description;
            RegistrationDate = registrationDate;
        }*/

        internal Book()
        {
        }

        public override string ToString()
        {
            return $"Title: {Title},/n Author: {Author},/n Genre: {Genre}.";
        }
    }
}