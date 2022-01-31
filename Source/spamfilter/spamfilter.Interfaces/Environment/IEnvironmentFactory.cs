namespace spamfilter.Interfaces.Environment;

public interface IEnvironmentFactory
{
    ILogger GetLogger(string origin);
    IConfiguration GetConfiguration();
}