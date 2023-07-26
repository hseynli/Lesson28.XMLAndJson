using Newtonsoft.Json.Linq;
using System;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JObject jsonObject = JObject.Parse(jsonString);

JArray students = (JArray)jsonObject["Students"]["Student"];

// Get the student to update
var studentToUpdate = students.FirstOrDefault(student => student["@ID"].Value<string>() == "222");

// Add a new property if the student is found
if (studentToUpdate != null)
{
    studentToUpdate["NewProperty"] = "NewValue";
}

// Output modified JSON
Console.WriteLine(jsonObject.ToString());