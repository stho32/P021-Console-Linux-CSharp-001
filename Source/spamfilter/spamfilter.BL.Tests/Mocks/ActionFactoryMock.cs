using spamfilter.Interfaces;
using spamfilter.Interfaces.Actions;
using spamfilter.Interfaces.Entities;

namespace spamfilter.BL.Tests.Mocks;

public class ActionFactoryMock : IActionFactory
{
    public IAction CreateFromEmail(IEmail email)
    {
        return new ActionMock(email);
    }
}