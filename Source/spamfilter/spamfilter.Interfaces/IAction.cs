namespace spamfilter.Interfaces;

/// <summary>
/// An action is the result of a rule
/// </summary>
public interface IAction
{
    void Execute();
}