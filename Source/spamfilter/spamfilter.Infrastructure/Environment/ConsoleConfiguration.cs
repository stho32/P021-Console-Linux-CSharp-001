using spamfilter.Interfaces.Environment;

namespace spamfilter.Infrastructure.Environment;

public class ConsoleConfiguration : IConfiguration
{
    public string GetConfigurationValue(string name)
    {
        Console.Write($"{name}: ");
        var value = Console.ReadLine();
        return value??"";
    }
}