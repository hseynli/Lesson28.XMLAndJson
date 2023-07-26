using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

IConfiguration configuration = builder.Build();

Console.WriteLine($"AllowedHosts: {configuration.GetSection("AllowedHosts").Value}");
Console.WriteLine($"AppSettings:Secret: {configuration.GetSection("AppSettings").GetSection("Secret").Value}");