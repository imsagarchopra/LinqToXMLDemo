using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TransformXMLToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string delimiter = ",";

            XDocument.Load(@"C:\Users\dell\source\repos\LinqToXMLDemo\TransformXMLToCSV\Data.xml").Descendants("Student").ToList().ForEach(
                element => sb.Append(element.Attribute("Country").Value + delimiter +
                                    element.Element("Name").Value + delimiter +
                                    element.Element("Gender").Value + delimiter +
                                    element.Element("TotalMarks").Value + "\r\n"
                ));

            StreamWriter file = new StreamWriter(@"C:\Users\dell\source\repos\LinqToXMLDemo\TransformXMLToCSV\Result.csv");
            file.WriteLine(sb.ToString());
            file.Close();

        }
    }
}
