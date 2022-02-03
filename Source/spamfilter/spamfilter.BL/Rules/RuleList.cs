using spamfilter.Interfaces;
using spamfilter.Interfaces.Actions;
using spamfilter.Interfaces.Entities;
using spamfilter.Interfaces.Rules;

namespace spamfilter.BL.Rules;

public class RuleList : IRule
{
    private readonly IRule[] _rules;

    public RuleList(IRule[] rules)
    {
        _rules = rules;
    }
    
    public IAction[] Execute(IEmail[] emails)
    {
        var result = new List<IAction>();
        
        foreach (var rule in _rules)
        {
            result.AddRange(rule.Execute(emails));
        }

        return result.ToArray();
    }
}