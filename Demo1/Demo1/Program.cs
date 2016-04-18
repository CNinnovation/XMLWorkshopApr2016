using System;
using System.Linq;
using System.Xml;

namespace Demo1
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Source\XMLWorkshopApr2016\Demo1\Demo1\Books.xml");
           

            ShowChildNodes(0, "root", doc);

            Console.ReadLine();
        }

        private static void ShowChildNodes(int indent, string title, XmlNode doc)
        {
           // Console.WriteLine($"{nameof(ShowChildNodes)} - {title}");
            foreach (XmlNode node in doc.ChildNodes)
            {
           
                XmlDeclaration declaration = node as XmlDeclaration;
                if (declaration != null)
                {
                    Console.WriteLine($"{declaration.Name}, value: {declaration.Value}, version: {declaration.Version}");
                }

                XmlElement element = node as XmlElement;
                if (element != null)
                {
                    // Console.WriteLine($"{element.Name}, inner text: {element.InnerText}, inner XML: {element.InnerXml}");
                    Console.WriteLine($"{string.Join(" ", Enumerable.Repeat(" ", indent))} {element.Name}, inner text: {element.InnerText}");
                }

                if (node.Attributes?.Count > 0)
                {
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        Console.WriteLine($"{string.Join(" ", Enumerable.Repeat(" ", indent))} Attribute: {attribute.Name}: {attribute.Value}");
                    }

                }
             //   Console.WriteLine();

                if (node.HasChildNodes)
                {
                    ShowChildNodes(indent + 1, $"parent: {node.Name}", node);
                }            
            }

        }
    }
}
