using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Helpers;

namespace spamfilter.BL.Detectors;

/// <summary>
/// If the sender has not a valid email address, e.g. if there is nothing given or
/// if the domain is missing, we want to classify this as spam. 
/// </summary>
public class InvalidSenderEmailAddressDetector : IDetector
{
    private readonly IEmailValidator _emailValidator;

    public InvalidSenderEmailAddressDetector(IEmailValidator emailValidator)
    {
        _emailValidator = emailValidator;
    }
    
    public IIsMatchOpinion[] GetOpinionsOn(IEmail email)
    {
        if (!_emailValidator.IsValidEmail(email.SenderEmailaddress))
        {
            return new IIsMatchOpinion[]
            {
                new IsMatchOpinion(
                    100,
                    $"The senders email address is not a valid email address ({email.SenderEmailaddress})",
                    nameof(InvalidSenderEmailAddressDetector),
                    true
                )
            };
        }

        return Array.Empty<IIsMatchOpinion>();
    }
}