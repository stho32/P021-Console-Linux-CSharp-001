using spamfilter.Interfaces;

namespace spamfilter.BL.Tests.Mocks;

public class ActionFactoryMock : IActionFactory
{
    public IAction CreateFromEmail(IEmail email)
    {
        return new ActionMock(email);
    }
}