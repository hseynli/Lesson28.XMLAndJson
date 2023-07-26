using System.Text.Json;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JsonDocument doc = JsonDocument.Parse(jsonString);
JsonElement root = doc.RootElement;
JsonElement studentsElement = root.GetProperty("Students").GetProperty("Student");

foreach (JsonElement studentElement in studentsElement.EnumerateArray())
{
    if (studentElement.TryGetProperty("@ID", out JsonElement idElement) && idElement.GetString() == "222")
    {
        Console.WriteLine("Found student with ID 222:");

        foreach (JsonProperty property in studentElement.EnumerateObject())
        {
            Console.WriteLine($"Property name: {property.Name}");
            Console.WriteLine($"Property value: {property.Value}");
        }

        break;
    }
}