using spamfilter.Interfaces.Entities;

namespace spamfilter.Interfaces.Actions;

public interface IActionFactory
{
    IAction CreateFromEmail(IEmail email);
}