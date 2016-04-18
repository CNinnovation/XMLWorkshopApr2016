using System.Xml;

namespace CreateXmlUsingDOM
{
    class Program
    {
        static void Main()
        {
            XmlNode node;
            var doc = new XmlDocument();           

            // create a comment/pi and append
            node = doc.CreateComment("A book document");
            doc.AppendChild(node);

            node = doc.CreateProcessingInstruction("Book", "Process info");
            doc.AppendChild(node);



            // create the books element within the 'wrox:bookstore' namespace
            // node = doc.CreateElement("p", "Books", "wrox:bookstore");
            node = doc.CreateElement("Books");
            doc.AppendChild(node);

            // create the book element within books
            node = doc.CreateElement("Book");
            doc.DocumentElement.AppendChild(node);

            // create the author element and title elements
            node = doc.CreateElement("Author");
            node.InnerText = "Christian Nagel";
            doc.DocumentElement["Book"].AppendChild(node);

            node = doc.CreateElement("Title");
            node.InnerText = "Professional C# Web Services";
            doc.DocumentElement["Book"].AppendChild(node);

            node = doc.CreateElement("Price");
            node.InnerText = "59.90";
            doc.DocumentElement["Book"].AppendChild(node);

            // create 2nd book
            XmlNode bookNode;
            bookNode = doc.CreateElement("Book");
            doc.DocumentElement.AppendChild(bookNode);

            node = doc.CreateElement("Author");
            node.InnerText = "Christian Nagel";
            bookNode.AppendChild(node);

            node = doc.CreateElement("Title");
            node.InnerText = "Professional C#";
            bookNode.AppendChild(node);

            node = doc.CreateElement("Price");
            node.InnerText = "49.90";
            bookNode.AppendChild(node);

            // serialize the document
            doc.Save("Books.xml");
        }
    }
}
