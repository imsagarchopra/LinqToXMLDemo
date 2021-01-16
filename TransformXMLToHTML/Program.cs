using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TransformXMLToHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDocument = XDocument.Load(@"C:\Users\dell\source\repos\LinqToXMLDemo\TransformXMLToHTML\Data.xml");

            XDocument result = new XDocument
                (new XElement("table", new XAttribute("border", 1),
                        new XElement("thead",
                            new XElement("tr",
                                new XElement("th", "Country"),
                                new XElement("th", "Name"),
                                new XElement("th", "Gender"),
                                new XElement("th", "TotalMarks"))),
                        new XElement("tbody",
                            from student in xmlDocument.Descendants("Student")
                            select new XElement("tr",
                                        new XElement("td", student.Attribute("Country").Value),
                                        new XElement("td", student.Element("Name").Value),
                                        new XElement("td", student.Element("Gender").Value),
                                        new XElement("td", student.Element("TotalMarks").Value)))));

            result.Save(@"C:\Users\dell\source\repos\LinqToXMLDemo\TransformXMLToHTML\Result.html");
        }
    }
}
