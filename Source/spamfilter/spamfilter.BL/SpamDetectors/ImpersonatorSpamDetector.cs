using spamfilter.BL.Entities;
using spamfilter.Interfaces;

namespace spamfilter.BL.SpamDetectors;

public class ImpersonatorSpamDetector : ISpamDetector
{
    private readonly string _namePart;
    private readonly string[] _validSenderDomains;

    public ImpersonatorSpamDetector(string namePart, string[] validSenderDomains)
    {
        _namePart = namePart.ToLower();
        _validSenderDomains = validSenderDomains.Select(x=>x.ToLower()).ToArray();
    }
    
    public IIsSpamOpinion[] GetOpinionsOn(IEmail email)
    {
        if (email.SenderName.ToLower().Contains(_namePart))
        {
            if (!EndsWithOneOfThose(email.SenderEmailaddress.ToLower(), _validSenderDomains))
            {
                return new IIsSpamOpinion[]
                {
                    new IsSpamOpinion(100,
                        $"The message is sent from {email.SenderEmailaddress} but tries to trick us into thinking it would be from {string.Join(",", _validSenderDomains)}.",
                        nameof(ImpersonatorSpamDetector),
                        true)
                };
            }
        }

        return Array.Empty<IIsSpamOpinion>();
    }

    private bool EndsWithOneOfThose(string emailaddress, string[] possibleValidEndings)
    {
        foreach (var validEnding in possibleValidEndings)
        {
            if (emailaddress.EndsWith("@" + validEnding))
            {
                return true;
            }
        }

        return false;
    }
}