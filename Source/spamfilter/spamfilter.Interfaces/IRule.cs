namespace spamfilter.Interfaces;

public interface IRule
{
    IAction[] Execute();
}