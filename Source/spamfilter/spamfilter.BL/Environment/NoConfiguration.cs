using spamfilter.Interfaces.Environment;

namespace spamfilter.BL.Environment;

public class NoConfiguration : IConfiguration
{
    public string GetConfigurationValue(string name)
    {
        return "";
    }
}