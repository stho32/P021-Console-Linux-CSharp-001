using spamfilter.BL.Entities;
using spamfilter.Interfaces;

namespace spamfilter.BL.Detectors;

public class EmailEndsWithBasedDetector : IDetector
{
    private readonly string _emailEndsWith;

    public EmailEndsWithBasedDetector(string emailEndsWith)
    {
        _emailEndsWith = emailEndsWith;
    }
    
    public IIsMatchOpinion[] GetOpinionsOn(IEmail email)
    {
        if (email.SenderEmailaddress.EndsWith(_emailEndsWith))
        {
            return new IIsMatchOpinion[]
            {
                new IsMatchOpinion(100, $"{email.SenderEmailaddress} endet mit {_emailEndsWith}",
                    nameof(EmailEndsWithBasedDetector),
                    true)
            };
        }

        return Array.Empty<IIsMatchOpinion>();
    }
}