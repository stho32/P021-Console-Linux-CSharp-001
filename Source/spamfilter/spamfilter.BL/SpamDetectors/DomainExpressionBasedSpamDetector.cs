using System.Text.RegularExpressions;
using spamfilter.BL.Entities;
using spamfilter.Interfaces;

namespace spamfilter.BL.SpamDetectors;

public class DomainExpressionBasedSpamDetector : ISpamDetector
{
    private readonly string _domainRegex;

    public DomainExpressionBasedSpamDetector(string domainRegex)
    {
        _domainRegex = domainRegex;
    }
    
    public IIsSpamOpinion[] GetOpinionsOn(IEmail email)
    {
        if (email.SenderEmailaddress.Contains("@"))
        {
            var split = email.SenderEmailaddress.Split("@", 2, StringSplitOptions.None);
            if (split.Length == 2)
            {
                if (Regex.IsMatch(split[1], _domainRegex))
                {
                    return new IIsSpamOpinion[] {
                        new IsSpamOpinion(100, 
                            "Matched Regex", 
                            nameof(DomainExpressionBasedSpamDetector),
                            true)
                    };
                }
            }
        }

        return Array.Empty<IIsSpamOpinion>();
    }
}