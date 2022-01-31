using spamfilter.Interfaces.Environment;

namespace spamfilter.BL.Environment;

public class NoLogger : ILogger
{
    public void Log(string message)
    {
        // do nothing
    }
}