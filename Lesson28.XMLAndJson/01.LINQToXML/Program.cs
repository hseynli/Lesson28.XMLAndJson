using System.Xml.Linq;

var studentsXML = XElement.Load("Students.xml");
var students =
    from student in studentsXML.Elements("Student")
    select student.Element("FirstName").Value + " " + student.Element("LastName").Value;

foreach (var student in students)
{
    Console.WriteLine(student);
}