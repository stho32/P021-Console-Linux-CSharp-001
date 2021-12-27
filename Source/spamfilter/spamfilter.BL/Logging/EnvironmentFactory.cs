using spamfilter.Interfaces.Environment;

namespace spamfilter.BL.Logging;

public class EnvironmentFactory : IEnvironmentFactory
{
    public ILogger GetLogger(string origin)
    {
        return new ConsoleLogger(origin);
    }

    public string GetConfigurationValue(string name)
    {
        Console.Write($"{name}: ");
        var value = Console.ReadLine();
        return value??"";
    }
}