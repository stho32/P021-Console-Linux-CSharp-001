using spamfilter.Interfaces;
using spamfilter.Interfaces.Actions;
using spamfilter.Interfaces.Entities;
using spamfilter.Interfaces.Repositories;

namespace spamfilter.BL.Tests.Mocks;

public class ActionMock : IAction
{
    public IEmail Email { get; }

    public ActionMock(IEmail email)
    {
        Email = email;
    }

    public bool HasBeenExecuted { get; private set; } = false;

    public void Execute(IEmailRepository emailRepository)
    {
        HasBeenExecuted = true;
    }
}