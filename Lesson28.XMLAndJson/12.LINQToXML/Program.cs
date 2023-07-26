using System.Xml.Linq;

XDocument studentsXML = XDocument.Parse(XElement.Load("Students.xml").ToString());

var students = studentsXML.Descendants("Student").Select(s => new
{
    ID = (string)s.Attribute("ID"),
    FirstName = (string)s.Element("FirstName"),
    LastName = (string)s.Element("LastName"),
    DateOfBirth = DateTime.Parse((string)s.Element("DateOfBirth")),
    Semester = int.Parse((string)s.Element("Semester")),
    Major = (string)s.Element("Major"),
    Courses = s.Element("Courses").Elements("Course").Select(c => new
    {
        ID = (string)c.Attribute("ID"),
        Grade = decimal.Parse((string)c.Element("Grade"))
    }).ToList()
}).ToList();

// Example 1: Find all students with a specific major
// This will find all students that are majoring in Computer Science:
Console.WriteLine("Example 1");
var computerScienceStudents = studentsXML.Descendants("Student").Where(s => (string)s.Element("Major") == "Computer Science");
Console.WriteLine("Computer Science Students:");
foreach (var student in computerScienceStudents)
{
    Console.WriteLine(student);
}
Console.WriteLine(new string('-', 80));

// Example 2: Find the student with the highest grade in a specific course
// This will find the student with the highest grade in course "CS202":
Console.WriteLine("Example 2");
var highestGradeInCS202 = studentsXML.Descendants("Student")
    .SelectMany(s => s.Descendants("Course")
        .Where(c => (string)c.Attribute("ID") == "CS202")
        .Select(c => new { Student = s, Grade = decimal.Parse((string)c.Element("Grade")) }))
    .OrderByDescending(sg => sg.Grade)
    .FirstOrDefault();

if (highestGradeInCS202 != null)
{
    Console.WriteLine($"\nStudent with highest grade in CS202: {highestGradeInCS202.Student}, Grade: {highestGradeInCS202.Grade}");
}
Console.WriteLine(new string('-', 80));

// Example 3: Find the average grade of a specific course
// This will calculate the average grade of course "CS103":
Console.WriteLine("Example 3");
var averageGradeInCS103 = studentsXML.Descendants("Student")
    .SelectMany(s => s.Descendants("Course")
        .Where(c => (string)c.Attribute("ID") == "CS103")
        .Select(c => decimal.Parse((string)c.Element("Grade"))))
    .Average();

Console.WriteLine($"\nAverage grade in CS103: {averageGradeInCS103}");
Console.WriteLine(new string('-', 80));

// Example 4: Find all courses taken by a specific student
// This will find all courses taken by the student with ID "111":
Console.WriteLine("Example 4");
var coursesTakenByStudent111 = studentsXML.Descendants("Student")
    .Where(s => (string)s.Attribute("ID") == "111")
    .SelectMany(s => s.Descendants("Course"))
    .ToList();

Console.WriteLine("\nCourses taken by student with ID 111:");
foreach (var course in coursesTakenByStudent111)
{
    Console.WriteLine(course);
}
Console.WriteLine(new string('-', 80));

// Example 5: Compute and Print Average Grades for Each Student
Console.WriteLine("Example 5");
var studentsWithAvgGrades = studentsXML.Descendants("Student")
    .Select(s => new
    {
        Name = (string)s.Element("FirstName") + " " + (string)s.Element("LastName"),
        AverageGrade = s.Descendants("Course").Average(c => decimal.Parse((string)c.Element("Grade")))
    });

foreach (var student in studentsWithAvgGrades)
{
    Console.WriteLine($"{student.Name}: {student.AverageGrade}");
}
Console.WriteLine(new string('-', 80));

// Example 6: Get Students Sorted by Their Highest Grade in Any Course
Console.WriteLine("Example 6");
var studentsSortedByHighestGrade = studentsXML.Descendants("Student")
    .Select(s => new
    {
        Name = (string)s.Element("FirstName") + " " + (string)s.Element("LastName"),
        HighestGrade = s.Descendants("Course").Max(c => decimal.Parse((string)c.Element("Grade")))
    })
    .OrderByDescending(s => s.HighestGrade);

foreach (var student in studentsSortedByHighestGrade)
{
    Console.WriteLine($"{student.Name}: {student.HighestGrade}");
}
Console.WriteLine(new string('-', 80));

// Example 7: Find the Most Popular Course
Console.WriteLine("Example 7");
var mostPopularCourse = studentsXML.Descendants("Course")
    .GroupBy(c => (string)c.Attribute("ID"))
    .OrderByDescending(g => g.Count())
    .First().Key;

Console.WriteLine($"Most popular course: {mostPopularCourse}");
Console.WriteLine(new string('-', 80));

// Example 8: Group Students by Major
Console.WriteLine("Example 8");
var studentsGroupedByMajor = studentsXML.Descendants("Student")
    .GroupBy(s => (string)s.Element("Major"))
    .Select(g => new
    {
        Major = g.Key,
        Students = g.Select(s => (string)s.Element("FirstName") + " " + (string)s.Element("LastName")).ToList()
    });

foreach (var group in studentsGroupedByMajor)
{
    Console.WriteLine($"{group.Major}:");
    foreach (var student in group.Students)
    {
        Console.WriteLine($"\t{student}");
    }
}
Console.WriteLine(new string('-', 80));


public class Course
{
    public string ID { get; set; }
    public decimal Grade { get; set; }

    public override string ToString()
    {
        return $"ID: {ID}, Grade: {Grade}";
    }
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

    public override string ToString()
    {
        return $"ID: {ID}, Name: {FirstName} {LastName}, Major: {Major}";
    }
}