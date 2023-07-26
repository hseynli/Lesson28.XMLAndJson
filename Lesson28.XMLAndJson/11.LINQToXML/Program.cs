using System.Data.SqlTypes;
using System.Xml.Linq;

// Load the XML document
XDocument studentsXML = XDocument.Parse(XElement.Load("Students.xml").ToString());

// Find the Student element with ID "111"
XElement student111 = studentsXML.Descendants("Student")
                                 .Single(student => student.Attribute("ID").Value == "111");

// Remove the student from the XML
student111.Remove();

// Print the updated XML to the console
Console.WriteLine(studentsXML.ToString());

Console.WriteLine(new string('-', 80)); //-----------------------------------------------------------------

studentsXML = XDocument.Parse(XElement.Load("Students.xml").ToString());

// Find the Student element with DateOfBirth "2001-2-22"
IEnumerable<XElement> studentsToRemove = studentsXML.Descendants("Student")
                                 .Where(student => student.Element("DateOfBirth").Value == "2001-2-22");

// Remove the student(s) from the XML
foreach (var student in studentsToRemove.ToList())
{
    student.Remove();
}

// Print the updated XML to the console
Console.WriteLine(studentsXML.ToString());