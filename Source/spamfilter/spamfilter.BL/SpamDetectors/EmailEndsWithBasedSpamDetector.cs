using spamfilter.BL.Entities;
using spamfilter.Interfaces;

namespace spamfilter.BL.SpamDetectors;

public class EmailEndsWithBasedSpamDetector : ISpamDetector
{
    private readonly string _emailEndsWith;

    public EmailEndsWithBasedSpamDetector(string emailEndsWith)
    {
        _emailEndsWith = emailEndsWith;
    }
    
    public IIsSpamOpinion[] GetOpinionsOn(IEmail email)
    {
        if (email.SenderEmailaddress.EndsWith(_emailEndsWith))
        {
            return new IIsSpamOpinion[]
            {
                new IsSpamOpinion(100, $"{email.SenderEmailaddress} endet mit {_emailEndsWith}",
                    nameof(EmailEndsWithBasedSpamDetector),
                    true)
            };
        }

        return Array.Empty<IIsSpamOpinion>();
    }
}