using spamfilter.Interfaces;

namespace spamfilter.BL.Tests.Rules;

public class ActionMock : IAction
{
    public IEmail Email { get; }

    public ActionMock(IEmail email)
    {
        Email = email;
    }

    public void Execute(IEmailRepository emailRepository)
    {
    }
}