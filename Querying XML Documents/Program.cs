using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Querying_XML_Documents
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> names = from student in XDocument.Load(@"C:\Users\dell\source\repos\LinqToXMLDemo\Querying XML Documents\Data.xml")
                                                                 .Descendants("Student")
                                        where (int)student.Element("TotalMarks") > 800
                                        orderby (int)student.Element("TotalMarks") descending
                                        select student.Element("Name").Value;

            //IEnumerable<string> names = from student in XDocument
            //                                                                          .Load(@"C:\Demo\Demo\Data.xml")
            //                                                                          .Element("Students")
            //                                                                          .Elements("Student")
            //                            where (int)student.Element("TotalMarks") > 800
            //                            orderby (int)student.Element("TotalMarks") descending
            //                            select student.Element("Name").Value;

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
