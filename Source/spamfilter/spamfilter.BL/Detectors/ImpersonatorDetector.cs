using spamfilter.BL.Entities;
using spamfilter.Interfaces;

namespace spamfilter.BL.Detectors;

public class ImpersonatorDetector : IDetector
{
    private readonly string _namePart;
    private readonly string[] _validSenderDomains;

    public ImpersonatorDetector(string namePart, string[] validSenderDomains)
    {
        _namePart = namePart.ToLower();
        _validSenderDomains = validSenderDomains.Select(x=>x.ToLower()).ToArray();
    }
    
    public IIsMatchOpinion[] GetOpinionsOn(IEmail email)
    {
        if (email.SenderName.ToLower().Contains(_namePart))
        {
            if (!EndsWithOneOfThose(email.SenderEmailaddress.ToLower(), _validSenderDomains))
            {
                return new IIsMatchOpinion[]
                {
                    new IsMatchOpinion(100,
                        $"The message is sent from {email.SenderEmailaddress} but tries to trick us into thinking it would be from {string.Join(",", _validSenderDomains)}.",
                        nameof(ImpersonatorDetector),
                        true)
                };
            }
        }

        return Array.Empty<IIsMatchOpinion>();
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