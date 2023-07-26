// Load the XML document
using System.Xml.Linq;

XDocument studentsXML = XDocument.Parse(XElement.Load("Students.xml").ToString());

// Find the first Student element
XElement firstStudent = studentsXML.Descendants("Student").First();

// Add a new Student before the first Student
firstStudent.AddBeforeSelf(
    new XElement("Student",
        new XAttribute("ID", "555"),
        new XElement("FirstName", "Alice"),
        new XElement("LastName", "Johnson"),
        new XElement("DateOfBirth", "2003-5-15"),
        new XElement("Semester", "4"),
        new XElement("Major", "Civil Engineering"),
        new XElement("Courses",
            new XElement("Course",
                new XAttribute("ID", "CE105"),
                new XElement("Grade", "7.8")
            ),
            new XElement("Course",
                new XAttribute("ID", "CE206"),
                new XElement("Grade", "8.5")
            )
        )
    )
);

// Find the last Student element
XElement lastStudent = studentsXML.Descendants("Student").Last();

// Add a new Student after the last Student
lastStudent.AddAfterSelf(
    new XElement("Student",
        new XAttribute("ID", "666"),
        new XElement("FirstName", "Bob"),
        new XElement("LastName", "Anderson"),
        new XElement("DateOfBirth", "2002-6-16"),
        new XElement("Semester", "3"),
        new XElement("Major", "Mathematics"),
        new XElement("Courses",
            new XElement("Course",
                new XAttribute("ID", "MA110"),
                new XElement("Grade", "9.1")
            ),
            new XElement("Course",
                new XAttribute("ID", "MA221"),
                new XElement("Grade", "8.9")
            )
        )
    )
);

Console.WriteLine(studentsXML.ToString());