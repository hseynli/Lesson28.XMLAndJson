using Newtonsoft.Json.Linq;

string jsonString = File.ReadAllText("inventory.json"); // your JSON string here

JObject jsonObject = JObject.Parse(jsonString);

// 1. Get all brands
JArray inventory = (JArray)jsonObject["Inventory"];
foreach (var car in inventory)
{
    Console.WriteLine("Brand: " + car["Brand"]);
}

// 2. Add a new car to the inventory
JObject newCar = new JObject
        {
            { "ID", "4" },
            { "Brand", "Chevrolet" },
            { "Model", "Malibu" },
            { "Year", "2022" },
            { "Color", "White" }
};

inventory.Add(newCar);
Console.WriteLine("\nJSON after adding new car:\n" + jsonObject.ToString());

// 3. Remove the car with ID = 2
var carToRemove = inventory.FirstOrDefault(car => car["ID"].Value<string>() == "2");
if (carToRemove != null)
{
    carToRemove.Remove();
}

Console.WriteLine("\nJSON after removing car with ID = 2:\n" + jsonObject.ToString());

// 4. Change the model of the car with ID = 1
var carToUpdate = inventory.FirstOrDefault(car => car["ID"].Value<string>() == "1");
if (carToUpdate != null)
{
    carToUpdate["Model"] = "Focus";
}

Console.WriteLine("\nJSON after updating the model of car with ID = 1:\n" + jsonObject.ToString());