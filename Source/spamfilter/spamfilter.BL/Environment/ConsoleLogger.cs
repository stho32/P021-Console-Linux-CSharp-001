using spamfilter.Interfaces.Environment;

namespace spamfilter.BL.Logging;

public class ConsoleLogger : ILogger
{
    private readonly string _origin;

    public ConsoleLogger(string origin)
    {
        _origin = origin;
    }
    
    public void Log(string message)
    {
        Console.WriteLine($"  - [{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} {_origin}] {message}");
    }
}

public class NoLogger : ILogger
{
    public void Log(string message)
    {
        // do nothing
    }
}

public class NoConfiguration : IConfiguration
{
    public string GetConfigurationValue(string name)
    {
        return "";
    }
}