using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateXmlUsingLinqToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement books =
                new XElement("Books",
                    new XElement("Book",
                        new XElement("Author", "Christian Nagel"),
                        new XElement("Publisher", "Wrox Press"),
                        new XAttribute("Title", "Professional C# 6")),
                    new XElement("Book",
                        new XElement("Author", "Karli Watson"),
                        new XElement("Publisher", "Wrox Press"),
                        new XAttribute("Title", "Beginning Visual C#")));

            Console.WriteLine(books);
        }
    }
}
