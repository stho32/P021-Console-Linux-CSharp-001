using spamfilter.Interfaces;

namespace spamfilter.BL.ExtensionMethods;

public static class ActionArrayExtensionMethods
{
    public static void Execute(this IAction[] actions, IEmailRepository emailRepository)
    {
        foreach (var action in actions) action.Execute(emailRepository);
    }
}