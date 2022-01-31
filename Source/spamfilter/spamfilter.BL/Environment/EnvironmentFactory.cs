using spamfilter.Interfaces.Environment;

namespace spamfilter.BL.Logging;

public class EnvironmentFactory : IEnvironmentFactory
{
    private readonly ILogger _logger;
    private readonly IConfiguration _configuration;

    public EnvironmentFactory(
        ILogger logger, 
        IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    
    public ILogger GetLogger(string origin)
    {
        return _logger;
    }

    public IConfiguration GetConfiguration()
    {
        return _configuration;
    }

    public static IEnvironmentFactory NoEnvironment()
    {
        return new EnvironmentFactory(new NoLogger(), new NoConfiguration());
    }
}