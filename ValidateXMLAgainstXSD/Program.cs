using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ValidateXMLAgainstXSD
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", @"C:\Users\dell\source\repos\LinqToXMLDemo\ValidateXMLAgainstXSD\Student.xsd");

            XDocument xmlDocument = XDocument.Load(@"C:\Users\dell\source\repos\LinqToXMLDemo\ValidateXMLAgainstXSD\Data.xml");

            bool validationErrors = false;

            xmlDocument.Validate(schema, (s, e) =>
            {
                Console.WriteLine(e.Message);
                validationErrors = true;
            });

            if (validationErrors)
                Console.WriteLine("Validation Failed");
            else
                Console.WriteLine("Validation Succeeded");
        }
    }
}
