using System.Xml.Linq;

XElement studentsXML = XElement.Load("Students.xml");

var students = from student in studentsXML.Descendants("Student")
               select new
               {
                   ID = student.Attribute("ID").Value,
                   FirstName = student.Element("FirstName").Value,
                   LastName = student.Element("LastName").Value,
                   DateOfBirth = DateTime.Parse(student.Element("DateOfBirth").Value),
                   Semester = int.Parse(student.Element("Semester").Value),
                   Major = student.Element("Major").Value,
                   Courses = student.Element("Courses").Elements("Course")
                              .Select(course => new
                              {
                                  ID = course.Attribute("ID").Value,
                                  Grade = double.Parse(course.Element("Grade").Value)
                              }).ToList()
               };

foreach (var student in students)
{
    Console.WriteLine("Student ID: " + student.ID);
    Console.WriteLine("Name: " + student.FirstName + " " + student.LastName);
    Console.WriteLine("Major: " + student.Major);
    foreach (var course in student.Courses)
    {
        Console.WriteLine("Course ID: " + course.ID);
        Console.WriteLine("Grade: " + course.Grade);
    }
    Console.WriteLine();
}

Console.WriteLine(new string('-', 80));


students = from student in studentsXML.Descendants("Student")
           select new
           {
               ID = student.Attribute("ID").Value,
               FirstName = student.Element("FirstName").Value,
               LastName = student.Element("LastName").Value,
               DateOfBirth = DateTime.Parse(student.Element("DateOfBirth").Value),
               Semester = int.Parse(student.Element("Semester").Value),
               Major = student.Element("Major").Value,
               Courses = (from course in student.Element("Courses").Elements("Course")
                          select new
                          {
                              ID = course.Attribute("ID").Value,
                              Grade = double.Parse(course.Element("Grade").Value)
                          }).ToList()
           };

foreach (var student in students)
{
    Console.WriteLine("Student ID: " + student.ID);
    Console.WriteLine("Name: " + student.FirstName + " " + student.LastName);
    Console.WriteLine("Major: " + student.Major);
    foreach (var course in student.Courses)
    {
        Console.WriteLine("Course ID: " + course.ID);
        Console.WriteLine("Grade: " + course.Grade);
    }
    Console.WriteLine();
}