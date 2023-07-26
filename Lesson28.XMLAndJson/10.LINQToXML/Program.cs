using System.Xml.Linq;

// Load the XML document
XDocument studentsXML = XDocument.Parse(XElement.Load("Students.xml").ToString());

// Find the Student element with ID "111"
XElement student111 = studentsXML.Descendants("Student")
                                 .Single(student => student.Attribute("ID").Value == "111");

// Update the student's major
student111.Element("Major").Value = "Software Engineering";

// Update the grade of course CS202
XElement courseCS202 = student111.Element("Courses")
                                 .Elements("Course")
                                 .Single(course => course.Attribute("ID").Value == "CS202");

courseCS202.Element("Grade").Value = "8.9";

// Print the updated XML to the console
Console.WriteLine(studentsXML.ToString());