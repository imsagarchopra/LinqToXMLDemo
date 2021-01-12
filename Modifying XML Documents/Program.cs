using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modifying_XML_Documents
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDocument = XDocument.Load(@"C:\Users\dell\source\repos\LinqToXMLDemo\Modifying XML Documents\Data.xml");

            #region Add new element
            xmlDocument.Element("Students").Add(
        new XElement("Student", new XAttribute("Id", 105),
            new XElement("Name", "Todd"),
            new XElement("Gender", "Male"),
            new XElement("TotalMarks", 980)
            ));
            #endregion

            #region Add new element at First position
            xmlDocument.Element("Students").AddFirst(
        new XElement("Student", new XAttribute("Id", 105),
            new XElement("Name", "Todd"),
            new XElement("Gender", "Male"),
            new XElement("TotalMarks", 980)
            ));
            #endregion

            #region Add element at a specific location
            //Use AddBeforeSelf() or AddAfterSelf()

            xmlDocument.Element("Students")
           .Elements("Student")
           .Where(x => x.Attribute("Id").Value == "103").FirstOrDefault()
           .AddBeforeSelf(
                new XElement("Student", new XAttribute("Id", 106),
                    new XElement("Name", "Todd"),
                    new XElement("Gender", "Male"),
                    new XElement("TotalMarks", 980)));
            #endregion

            #region Modify element value

            xmlDocument.Element("Students")
                        .Elements("Student")
                        .Where(x => x.Attribute("Id").Value == "106").FirstOrDefault()
                        .SetElementValue("TotalMarks", 999);

            //        xmlDocument.Element("Students")
            //.Elements("Student")
            //.Where(x => x.Attribute("Id").Value == "106")
            //.Select(x => x.Element("TotalMarks")).FirstOrDefault().SetValue(999);
            #endregion

            #region Updating XML Comment

            xmlDocument.Nodes().OfType<XComment>().FirstOrDefault().Value = "Updated Comment";
            #endregion

            #region Deleting XML Comment
            xmlDocument.Nodes().OfType<XComment>().Remove();
            #endregion

            #region Deleting XML Elements
            xmlDocument.Root.Elements().Where(x => x.Attribute("Id").Value == "106").Remove();

            xmlDocument.Root.Elements().Remove();
            #endregion
            xmlDocument.Save(@"C:\Users\dell\source\repos\LinqToXMLDemo\Modifying XML Documents\Data.xml");

            //To Disable formatting use this
            //xmlDocument.Save(@"C:\Users\dell\source\repos\LinqToXMLDemo\Modifying XML Documents\Data.xml", SaveOptions.DisableFormatting);

        }
    }
}
