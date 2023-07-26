using System.Text.Json;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JsonDocument document = JsonDocument.Parse(jsonString);
JsonElement root = document.RootElement;
JsonElement studentsElement = root.GetProperty("Students");
JsonElement studentArray = studentsElement.GetProperty("Student");

foreach (JsonElement studentElement in studentArray.EnumerateArray())
{
    if (studentElement.TryGetProperty("@ID", out JsonElement studentIdElement) &&
        studentIdElement.GetString() == "222")
    {
        Console.WriteLine(studentElement);
    }
}