using Newtonsoft.Json.Linq;
using System;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JObject jsonObject = JObject.Parse(jsonString);
JArray students = (JArray)jsonObject["Students"]["Student"];

foreach (JObject student in students)
{
    Console.WriteLine("FirstName: " + student["FirstName"].Value<string>());
}
