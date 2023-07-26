using System.Xml.Linq;

XElement studentsXML = XElement.Load("Students.xml");


var students = from student in studentsXML.Descendants("Student")
               select new Student
               {
                   ID = student.Attribute("ID").Value,
                   FirstName = student.Element("FirstName").Value,
                   LastName = student.Element("LastName").Value,
                   DateOfBirth = DateTime.Parse(student.Element("DateOfBirth").Value),
                   Semester = int.Parse(student.Element("Semester").Value),
                   Major = student.Element("Major").Value,
                   Courses = (from course in student.Element("Courses").Elements("Course")
                              select new Course
                              {
                                  ID = course.Attribute("ID").Value,
                                  Grade = double.Parse(course.Element("Grade").Value)
                              }).ToList()
               };


foreach (var student in students)
{
    Console.WriteLine($"ID: {student.ID}, Name: {student.FirstName} {student.LastName}, Date of Birth: {student.DateOfBirth}, Semester: {student.Semester}, Major: {student.Major}");

    Console.WriteLine("Courses:");
    foreach (var course in student.Courses)
    {
        Console.WriteLine($"  Course ID: {course.ID}, Grade: {course.Grade}");
    }

    Console.WriteLine();
}

public class Course
{
    public string ID { get; set; }
    public double Grade { get; set; }
}

public class Student
{
    public string ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Semester { get; set; }
    public string Major { get; set; }
    public List<Course> Courses { get; set; }
}