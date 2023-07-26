using Newtonsoft.Json.Linq;
using System;

string jsonString = File.ReadAllText("Students.json"); // your JSON string here

JObject jsonObject = JObject.Parse(jsonString);

JArray students = (JArray)jsonObject["Students"]["Student"];

// Create new student object
JObject newStudent = new JObject
{
    ["@ID"] = "444",
    ["FirstName"] = "Emma",
    ["LastName"] = "Smith",
    ["DateOfBirth"] = "2002-5-16",
    ["Semester"] = "1",
    ["Major"] = "Mathematics",
    ["Courses"] = new JObject
    {
        ["Course"] = new JArray
        {
            new JObject
            {
                ["@ID"] = "MATH101",
                ["Grade"] = "8.5"
            },
            new JObject
            {
                ["@ID"] = "MATH202",
                ["Grade"] = "9.0"
            }
        }
    }
};

// Add new student to existing list
students.Add(newStudent);

// Output modified JSON
Console.WriteLine(jsonObject.ToString());