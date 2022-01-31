using spamfilter.Interfaces;

namespace spamfilter.BL.Tests.Rules;

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