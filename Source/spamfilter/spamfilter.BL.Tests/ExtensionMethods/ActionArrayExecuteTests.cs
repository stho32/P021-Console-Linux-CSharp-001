using spamfilter.BL.Tests.Rules;
using spamfilter.Interfaces;
using spamfilter.BL.ExtensionMethods;
using Xunit;

namespace spamfilter.BL.Tests.ExtensionMethods;

public class ActionArrayExecuteTests
{
    [Fact]
    public void Execute_does_execute_every_action_in_the_array()
    {
        var actions = new IAction[]
        {
            new ActionMock(null),
            new ActionMock(null)
        };

        actions.Execute(new EmailRepositoryMock());
        
        Assert.True(((ActionMock)actions[0]).HasBeenExecuted);
        Assert.True(((ActionMock)actions[1]).HasBeenExecuted);
    }
    
}