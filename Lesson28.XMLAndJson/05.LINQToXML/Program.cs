using System.Xml.Linq;

XElement students = new XElement("Students",
    new XElement("Student",
        new XAttribute("ID", "111"),
        new XElement("FirstName", "John"),
        new XElement("LastName", "Doe"),
        new XElement("DateOfBirth", "2000-10-2"),
        new XElement("Semester", "2"),
        new XElement("Major", "Computer Science"),
        new XElement("Courses",
            new XElement("Course",
                new XAttribute("ID", "CS103"),
                new XElement("Grade", "7.3")),
            new XElement("Course",
                new XAttribute("ID", "CS202"),
                new XElement("Grade", "6.9"))
        )
    ),
    new XElement("Student",
        new XAttribute("ID", "222"),
        new XElement("FirstName", "Jane"),
        new XElement("LastName", "Doe"),
        new XElement("DateOfBirth", "2001-2-22"),
        new XElement("Semester", "1"),
        new XElement("Major", "Electrical Engineering"),
        new XElement("Courses",
            new XElement("Course",
                new XAttribute("ID", "EE111"),
                new XElement("Grade", "5.6")),
            new XElement("Course",
                new XAttribute("ID", "EE303"),
                new XElement("Grade", "8.8"))
        )
    ),
    new XElement("Student",
        new XAttribute("ID", "333"),
        new XElement("FirstName", "Jim"),
        new XElement("LastName", "Doe"),
        new XElement("DateOfBirth", "2000-3-12"),
        new XElement("Semester", "2"),
        new XElement("Major", "Computer Science"),
        new XElement("Courses",
            new XElement("Course",
                new XAttribute("ID", "CS103"),
                new XElement("Grade", "7.6")),
            new XElement("Course",
                new XAttribute("ID", "CS202"),
                new XElement("Grade", "8.2"))
        )
    )
);

string xmlString = students.ToString();
Console.WriteLine(xmlString);