using spamfilter.BL.Rules;
using Xunit;

namespace spamfilter.BL.Tests.Rules;

public class ExampleRuleFactoryTests
{
    [Fact]
    public void Construction_does_not_throw_an_exception()
    {
        var factory = new ExampleRuleFactory(null, null);
        var rule = factory.Create();
        Assert.True(true);
    }
}