using Newtonsoft.Json.Linq;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JObject jsonObject = JObject.Parse(jsonString);

JArray students = (JArray)jsonObject["Students"]["Student"];

foreach (JObject student in students)
{
    Console.WriteLine("ID: " + student["@ID"].Value<string>());
    Console.WriteLine("FirstName: " + student["FirstName"].Value<string>());
    Console.WriteLine("LastName: " + student["LastName"].Value<string>());
    Console.WriteLine("DateOfBirth: " + student["DateOfBirth"].Value<string>());
    Console.WriteLine("Semester: " + student["Semester"].Value<string>());
    Console.WriteLine("Major: " + student["Major"].Value<string>());

    Console.WriteLine("Courses:");
    JArray courses = (JArray)student["Courses"]["Course"];
    foreach (JObject course in courses)
    {
        Console.WriteLine("\tCourse ID: " + course["@ID"].Value<string>());
        Console.WriteLine("\tGrade: " + course["Grade"].Value<string>());
    }
}