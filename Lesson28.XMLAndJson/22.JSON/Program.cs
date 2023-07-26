using Newtonsoft.Json.Linq;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JObject jsonObject = JObject.Parse(jsonString);

JArray students = (JArray)jsonObject["Students"]["Student"];

// Get the student to update
var studentToUpdate = students.FirstOrDefault(student => student["@ID"].Value<string>() == "111");

// Update student's FirstName if found
if (studentToUpdate != null)
{
    studentToUpdate["FirstName"].Replace("NewFirstName");
}

// Output modified JSON
Console.WriteLine(jsonObject.ToString());