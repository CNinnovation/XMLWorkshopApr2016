using System;
using System.Xml;

namespace Demo1
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Source\XMLWorkshopApr2016\Demo1\Demo1\Books.xml");

            ShowChildNodes(doc);
        }

        private static void ShowChildNodes(XmlNode doc)
        {
            Console.WriteLine(nameof(ShowChildNodes));
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
                    Console.WriteLine($"{element.Name}, inner text: {element.InnerText}, inner XML: {element.InnerXml}");
                }

                if (node.Attributes?.Count > 0)
                {
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        Console.WriteLine($"Attribute: {attribute.Name}: {attribute.Value}");
                    }
                }

                if (node.HasChildNodes)
                {
                    ShowChildNodes(node);
                }            
            }
            Console.WriteLine();
        }
    }
}
