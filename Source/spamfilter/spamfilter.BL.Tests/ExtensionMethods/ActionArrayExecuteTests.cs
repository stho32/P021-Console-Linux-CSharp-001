using spamfilter.BL.Entities;
using spamfilter.BL.Tests.Rules;
using spamfilter.Interfaces;
using spamfilter.BL.ExtensionMethods;
using spamfilter.BL.Tests.Mocks;
using spamfilter.Interfaces.Actions;
using Xunit;

namespace spamfilter.BL.Tests.ExtensionMethods;

public class ActionArrayExecuteTests
{
    [Fact]
    public void Execute_does_execute_every_action_in_the_array()
    {
        var actions = new IAction[]
        {
            new ActionMock(Email.Empty()),
            new ActionMock(Email.Empty())
        };

        actions.Execute(new EmailRepositoryMock());
        
        Assert.True(((ActionMock)actions[0]).HasBeenExecuted);
        Assert.True(((ActionMock)actions[1]).HasBeenExecuted);
    }
    
}