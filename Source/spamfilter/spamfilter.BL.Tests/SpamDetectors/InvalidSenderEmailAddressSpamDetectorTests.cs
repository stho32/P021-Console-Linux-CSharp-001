using spamfilter.BL.Entities;
using spamfilter.BL.Helpers;
using spamfilter.BL.SpamDetectors;
using spamfilter.Interfaces;
using Xunit;

namespace spamfilter.BL.Tests.SpamDetectors;

public class InvalidSenderEmailAddressSpamDetectorTests
{
    private ISpamDetector SpamDetector()
    {
        var detector = new InvalidSenderEmailAddressSpamDetector(
            new EmailValidator());

        return detector;
    }
    
    [Fact]
    public void When_the_attached_emailvalidator_is_satisfied_we_get_OK()
    {
        var mail = new Email(
            "Amazon",
            "amazon@amazon.de",
            "123",
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
            "123",
            "Your orders",
            "");
        
        Assert.NotEmpty(SpamDetector().GetOpinionsOn(mail));
    }
}