using spamfilter.BL.Environment;
using spamfilter.BL.Rules;
using spamfilter.BL.Tests.Mocks;
using Xunit;

namespace spamfilter.BL.Tests.Rules;

public class ExampleRuleFactoryTests
{
    [Fact]
    public void Construction_does_not_throw_an_exception()
    {
        var factory = new ExampleRuleFactory(
            new EmailRepositoryMock(), 
            EnvironmentFactory.NoEnvironment());
        
        var rule = factory.Create();
        Assert.True(true);
    }
}