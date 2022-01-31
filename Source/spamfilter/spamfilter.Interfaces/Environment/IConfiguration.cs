namespace spamfilter.Interfaces.Environment;

public interface IConfiguration
{
    string GetConfigurationValue(string name);
}