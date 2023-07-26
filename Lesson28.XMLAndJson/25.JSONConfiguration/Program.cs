using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

IConfiguration configuration = builder.Build();

Console.WriteLine($"AllowedHosts: {configuration["AllowedHosts"]}");
Console.WriteLine($"AppSettings:Secret: {configuration["AppSettings:Secret"]}");