using System.Xml.Linq;

var studentsXML = XElement.Load("Students.xml");
var students = studentsXML.Elements("Student")
    .Select(student => student.Element("FirstName").Value + " " + student.Element("LastName").Value);

foreach (var student in students)
{
    Console.WriteLine(student);
}