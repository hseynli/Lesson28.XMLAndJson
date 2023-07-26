using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);

IConfiguration config = builder.Build();

var myFirstClass = config.GetSection("MyFirstClass").Get<MyFirstClass>();
var mySecondClass = config.GetSection("MySecondClass").Get<MySecondClass>();
Console.WriteLine($"The answer is always {myFirstClass.Option2}");

public class MyFirstClass
{
    public string Option1 { get; set; }
    public int Option2 { get; set; }
}

public class MySecondClass
{
    public string SettingOne { get; set; }
    public int SettingTwo { get; set; }
}