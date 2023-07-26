using System.Data.SqlTypes;
using System.Xml.Linq;

XDocument doc = XDocument.Parse(XElement.Load("Students.xml").ToString());

doc.Root.Add(
    new XElement("Student",
        new XAttribute("ID", "444"),
        new XElement("FirstName", "Tom"),
        new XElement("LastName", "Smith"),
        new XElement("DateOfBirth", "2002-4-14"),
        new XElement("Semester", "3"),
        new XElement("Major", "Mechanical Engineering"),
        new XElement("Courses",
            new XElement("Course",
                new XAttribute("ID", "ME101"),
                new XElement("Grade", "7.9")
            ),
            new XElement("Course",
                new XAttribute("ID", "ME202"),
                new XElement("Grade", "8.4")
            )
        )
    )
);

doc.Save("output.xml");

Console.WriteLine(File.ReadAllText("output.xml"));

Console.ReadKey();