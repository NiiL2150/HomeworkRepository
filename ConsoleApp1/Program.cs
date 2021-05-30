using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextWriter xmlWriter = null;
            try
            {
                Console.Write("fileName: ");
                string fileName = Console.ReadLine();
                Console.Write("title: ");
                string title = Console.ReadLine();
                Console.Write("author: ");
                string author = Console.ReadLine();
                Console.Write("description: ");
                string description = Console.ReadLine();
                Console.Write("shortcut: ");
                string shortcut = Console.ReadLine();
                Console.Write("command: ");
                string command = Console.ReadLine();

                xmlWriter = new XmlTextWriter($"{fileName}.snippet", Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("CodeSnippets");
                xmlWriter.WriteAttributeString("xmlns", "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet");

                xmlWriter.WriteStartElement("CodeSnippet");
                xmlWriter.WriteAttributeString("Format", "1.0.0");

                xmlWriter.WriteStartElement("Header");

                xmlWriter.WriteStartElement("Title");
                xmlWriter.WriteString(title);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Author");
                xmlWriter.WriteString(author);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Description");
                xmlWriter.WriteString(description);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Shortcut");
                xmlWriter.WriteString(shortcut);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Snippet");
                xmlWriter.WriteStartElement("Code");

                xmlWriter.WriteAttributeString("Language", "CSharp");
                xmlWriter.WriteString($"<![CDATA[{command}]]>");

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
                Console.WriteLine("XML Created");
            }
            catch(Exception e)
            {
                Console.WriteLine($"XML Error: {e.Message}");
            }
            finally
            {
                xmlWriter.Close();
            }
        }
    }
}
