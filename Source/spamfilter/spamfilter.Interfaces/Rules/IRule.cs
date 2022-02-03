using spamfilter.Interfaces.Actions;
using spamfilter.Interfaces.Entities;

namespace spamfilter.Interfaces.Rules;

public interface IRule
{
    IAction[] Execute(IEmail[] emails);
}

