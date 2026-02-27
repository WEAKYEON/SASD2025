using Microsoft.Extensions.Configuration;

public static class MyConfig
{
    public static string ReadConnectionString()
    {
        var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
        var conn = config["Connection"];
        return conn!;
    }
}