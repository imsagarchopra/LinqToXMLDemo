using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TransformXMLToAnotherXmlFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDocument = XDocument.Load(@"C:\Users\dell\source\repos\LinqToXMLDemo\TransformXMLToAnotherXmlFormat\Data.xml");

            XDocument result = new XDocument(
                new XElement("Students",
                    new XElement("USA",
                        from s in xmlDocument.Descendants("Student")
                        where s.Attribute("Country").Value == "USA"
                        select new XElement("Student",
                            new XElement("Name", s.Element("Name").Value),
                            new XElement("Gender", s.Element("Gender").Value),
                            new XElement("TotalMarks", s.Element("TotalMarks").Value))),
                     new XElement("India",
                        from s in xmlDocument.Descendants("Student")
                        where s.Attribute("Country").Value == "India"
                        select new XElement("Student",
                            new XElement("Name", s.Element("Name").Value),
                            new XElement("Gender", s.Element("Gender").Value),
                            new XElement("TotalMarks", s.Element("TotalMarks").Value)))));


            result.Save(@"C:\Users\dell\source\repos\LinqToXMLDemo\TransformXMLToAnotherXmlFormat\Result.xml");
        }
    }
}
