using System.Text.RegularExpressions;
using spamfilter.BL.Entities;
using spamfilter.Interfaces;

namespace spamfilter.BL.Detectors;

public class DomainExpressionBasedDetector : IDetector
{
    private readonly string _domainRegex;

    public DomainExpressionBasedDetector(string domainRegex)
    {
        _domainRegex = domainRegex;
    }
    
    public IIsMatchOpinion[] GetOpinionsOn(IEmail email)
    {
        if (email.SenderEmailaddress.Contains("@"))
        {
            var split = email.SenderEmailaddress.Split("@", 2, StringSplitOptions.None);
            if (split.Length == 2)
            {
                if (Regex.IsMatch(split[1], _domainRegex))
                {
                    return new IIsMatchOpinion[] {
                        new IsMatchOpinion(100, 
                            "Matched Regex", 
                            nameof(DomainExpressionBasedDetector),
                            true)
                    };
                }
            }
        }

        return Array.Empty<IIsMatchOpinion>();
    }
}