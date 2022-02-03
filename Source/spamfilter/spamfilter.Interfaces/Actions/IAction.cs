using spamfilter.Interfaces.Repositories;

namespace spamfilter.Interfaces.Actions;

/// <summary>
/// An action is the result of a rule
/// </summary>
public interface IAction
{
    void Execute(IEmailRepository emailRepository);
}