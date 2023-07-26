// Load the XML document
using System.Xml.Linq;

XDocument studentsXML = XDocument.Parse(XElement.Load("Students.xml").ToString());

// Find the Student with ID 111
XElement student111 = studentsXML.Descendants("Student")
                                 .FirstOrDefault(s => s.Attribute("ID").Value == "111");

// Check if the student was found
if (student111 != null)
{
    // Add a new Student after Student 111
    student111.AddAfterSelf(
        new XElement("Student",
            new XAttribute("ID", "444"),
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
}

// Print the updated XML to the console
Console.WriteLine(studentsXML.ToString());