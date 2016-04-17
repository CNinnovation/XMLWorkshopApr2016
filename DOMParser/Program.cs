using System;
using System.Xml;

namespace DOMParser
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../Planets.xml");
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

                if (node.HasChildNodes)
                {
                    ShowChildNodes(node);
                }
            }
            Console.WriteLine();
        }
    }
}
