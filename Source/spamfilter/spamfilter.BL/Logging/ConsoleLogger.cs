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