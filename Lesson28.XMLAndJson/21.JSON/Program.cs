using Newtonsoft.Json.Linq;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JObject jsonObject = JObject.Parse(jsonString);

JArray students = (JArray)jsonObject["Students"]["Student"];

// Get the student to remove
var studentToRemove = students.FirstOrDefault(student => student["@ID"].Value<string>() == "222");

// Remove student if found
if (studentToRemove != null)
{
    studentToRemove.Remove();
}

// Output modified JSON
Console.WriteLine(jsonObject.ToString());