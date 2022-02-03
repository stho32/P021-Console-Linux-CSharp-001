using MailKit;
using spamfilter.BL.Entities;
using spamfilter.BL.Environment;
using spamfilter.BL.Rules;
using spamfilter.BL.Tests.Detectors;
using spamfilter.BL.Tests.Mocks;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Detectors;
using spamfilter.Interfaces.Entities;
using Xunit;

namespace spamfilter.BL.Tests.Rules;

public class RuleTests
{
    [Fact]
    public void For_every_matching_email_it_returns_an_action()
    {
        var rule = new Rule(
            new IDetector[]
            {
                new DetectorMock(false)
            },
            EnvironmentFactory.NoEnvironment(),
            new ActionFactoryMock()
        );

        var actions = rule.Execute(
            new IEmail[]
            {
                new Email("", "", UniqueId.Invalid, "1" , "", ""),
                new Email("", "", UniqueId.Invalid, "2" , "", "")
            }
        );
        
        Assert.Equal(2, actions.Length);
        Assert.IsType<ActionMock>(actions[0]);
        Assert.IsType<ActionMock>(actions[1]);
        Assert.Equal("1", (actions[0] as ActionMock)?.Email.Subject);
        Assert.Equal("2", (actions[1] as ActionMock)?.Email.Subject);
    }
}