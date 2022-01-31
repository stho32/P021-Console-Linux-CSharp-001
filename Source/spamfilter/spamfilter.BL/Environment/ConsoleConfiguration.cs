using spamfilter.Interfaces.Environment;

namespace spamfilter.BL.Logging;

public class ConsoleConfiguration : IConfiguration
{
    public string GetConfigurationValue(string name)
    {
        Console.Write($"{name}: ");
        var value = Console.ReadLine();
        return value??"";
    }
}