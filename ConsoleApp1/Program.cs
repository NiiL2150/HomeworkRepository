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
                xmlWriter = new XmlTextWriter("Some.xml", Encoding.Unicode);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("users");
                
                xmlWriter.WriteStartElement("user");
                xmlWriter.WriteAttributeString("Type", "Human");
                xmlWriter.WriteStartElement("name");
                xmlWriter.WriteString("Dmitry");

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("user");
                xmlWriter.WriteAttributeString("Type", "Alien");
                xmlWriter.WriteStartElement("name");
                xmlWriter.WriteString("Nail");

                xmlWriter.WriteEndDocument();
                Console.WriteLine("XML Created");
            }
            catch(Exception e)
            {
                Console.WriteLine($"XML Error: {e.Message}");
            }
            finally
            {

            }
        }
    }
}
