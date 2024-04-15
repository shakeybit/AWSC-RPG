using Microsoft.Extensions.Configuration;

// Build configuration
var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddXmlFile("appsettings.xml")
    .Build();

// Read configuration settings
int maxX = int.Parse(config["worldSettings:maxX"]);
int maxY = int.Parse(config["worldSettings:maxY"]);