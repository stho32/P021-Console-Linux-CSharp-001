using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Helpers;

namespace spamfilter.BL.SpamDetectors;

/// <summary>
/// If the sender has not a valid email address, e.g. if there is nothing given or
/// if the domain is missing, we want to classify this as spam. 
/// </summary>
public class InvalidSenderEmailAddressSpamDetector : ISpamDetector
{
    private readonly IEmailValidator _emailValidator;

    public InvalidSenderEmailAddressSpamDetector(IEmailValidator emailValidator)
    {
        _emailValidator = emailValidator;
    }
    
    public IIsSpamOpinion[] GetOpinionsOn(IEmail email)
    {
        if (!_emailValidator.IsValidEmail(email.SenderEmailaddress))
        {
            return new IIsSpamOpinion[]
            {
                new IsSpamOpinion(
                    100,
                    $"The senders email address is not a valid email address ({email.SenderEmailaddress})",
                    nameof(InvalidSenderEmailAddressSpamDetector),
                    true
                )
            };
        }

        return Array.Empty<IIsSpamOpinion>();
    }
}