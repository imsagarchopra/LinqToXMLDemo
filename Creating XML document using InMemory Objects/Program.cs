using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Creating_XML_document_using_InMemory_Objects
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("Creating an XML Tree using LINQ to XML"),

                new XElement("Students",

                    from student in Student.GetAllStudents()
                    select new XElement("Student", new XAttribute("Id", student.Id),
                                new XElement("Name", student.Name),
                                new XElement("Gender", student.Gender),
                                new XElement("TotalMarks", student.TotalMarks))
                            ));

            xmlDocument.Save(@"C:\Users\dell\source\repos\LinqToXMLDemo\Creating XML document using InMemory Objects\Data.xml");
        }
    }
}
