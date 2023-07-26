using System.Linq;
using System.Text.Json;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JsonDocument doc = JsonDocument.Parse(jsonString);
JsonElement root = doc.RootElement;
JsonElement studentsElement = root.GetProperty("Students").GetProperty("Student");

foreach (JsonElement studentElement in studentsElement.EnumerateArray())
{
    if (studentElement.GetProperty("@ID").GetString() == "111")
    {
        string firstName = studentElement.GetProperty("FirstName").GetString();
        Console.WriteLine($"The first name of the student with ID 111 is {firstName}.");
        break;
    }
}

string studentWithId111 = studentsElement.EnumerateArray()
                                         .Where(p => p.GetProperty("@ID").GetString() == "111")
                                         .FirstOrDefault().GetProperty("FirstName").GetString();
Console.WriteLine($"studentWithId111 = {studentWithId111}" );
