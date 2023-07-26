using System.Data.SqlTypes;
using System.Xml.Linq;

XElement doc = XElement.Load(XElement.Load("Students.xml").ToString());

var cs202Courses = from student in doc.Descendants("Student")
                   from course in student.Descendants("Course")
                   where (string)course.Attribute("ID") == "CS202"
                   select new
                   {
                       StudentID = (string)student.Attribute("ID"),
                       CourseID = (string)course.Attribute("ID"),
                       Grade = (double)course.Element("Grade")
                   };

foreach (var course in cs202Courses)
{
    Console.WriteLine($"Student ID: {course.StudentID}, Course ID: {course.CourseID}, Grade: {course.Grade}");
}

Console.WriteLine(new string('-', 80));

var cs202Students = from student in doc.Descendants("Student")
                    where student.Descendants("Course").Any(c => (string)c.Attribute("ID") == "CS202")
                    select new
                    {
                        ID = (string)student.Attribute("ID"),
                        FirstName = (string)student.Element("FirstName"),
                        LastName = (string)student.Element("LastName"),
                        DateOfBirth = (DateTime)student.Element("DateOfBirth"),
                        Semester = (int)student.Element("Semester"),
                        Major = (string)student.Element("Major"),
                        Courses = student.Element("Courses").Elements("Course")
                            .Select(course => new
                            {
                                ID = (string)course.Attribute("ID"),
                                Grade = (double)course.Element("Grade")
                            }).ToList()
                    };


foreach (var student in cs202Students)
{
    Console.WriteLine($"ID: {student.ID}, FirstName: {student.FirstName}, LastName: {student.LastName}, DateOfBirth: {student.DateOfBirth}, Semester: {student.Semester}, Major: {student.Major}");
    foreach (var course in student.Courses)
    {
        Console.WriteLine($"Course ID: {course.ID}, Grade: {course.Grade}");
    }
}