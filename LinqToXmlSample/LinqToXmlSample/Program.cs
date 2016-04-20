using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlSample
{
    class Racer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => LastName;
    }

    class Program
    {
        static void Main(string[] args)
        {
            XElement racers = XElement.Load("http://www.cninnovation.com/downloads/Racers.xml");
            // Console.WriteLine(racers);

            var q = from r in racers.Elements("Racer")
                    where r.Element("Country").Value == "Brazil"
                    orderby int.Parse(r.Element("Wins").Value) descending
                    select new XElement("MyRacer",
                        new XAttribute(
                            "Name",
                            r.Element("Firstname").Value + " " + r.Element("Lastname").Value),
                        new XElement("Country", r.Element("Country").Value));
                    //select new 
                    //{
                    //    FirstName = r.Element("Firstname").Value,
                    //    LastName = r.Element("Lastname").Value
                    //};

            foreach (var r in q)
            {
                Console.WriteLine(r);
            }
        }
    }
}
