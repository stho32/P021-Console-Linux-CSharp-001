using MailKit;
using spamfilter.BL.Detectors;
using spamfilter.BL.Entities;
using spamfilter.BL.Helpers;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Detectors;
using Xunit;

namespace spamfilter.BL.Tests.Detectors;

public class InvalidSenderEmailAddressSpamDetectorTests
{
    private IDetector SpamDetector()
    {
        var detector = new InvalidSenderEmailAddressDetector(
            new EmailValidator());

        return detector;
    }
    
    [Fact]
    public void When_the_attached_emailvalidator_is_satisfied_we_get_OK()
    {
        var mail = new Email(
            "Amazon",
            "amazon@amazon.de",
            UniqueId.Invalid,
            "Your orders",
            "");
        
        Assert.Empty(SpamDetector().GetOpinionsOn(mail));
    }
    
    [Fact]
    public void When_the_attached_emailvalidator_is_not_satisfied_it_is_spam()
    {
        var mail = new Email(
            "Amazon",
            "Not-an-email",
            UniqueId.Invalid,
            "Your orders",
            "");
        
        Assert.NotEmpty(SpamDetector().GetOpinionsOn(mail));
    }
}