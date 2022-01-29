namespace spamfilter.Interfaces;

public interface IActionFactory
{
    IAction CreateFromEmail(IEmail email);
}