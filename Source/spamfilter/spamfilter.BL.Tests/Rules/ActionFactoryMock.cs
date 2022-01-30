using spamfilter.Interfaces;

namespace spamfilter.BL.Tests.Rules;

public class ActionFactoryMock : IActionFactory
{
    public IAction CreateFromEmail(IEmail email)
    {
        return new ActionMock(email);
    }
}