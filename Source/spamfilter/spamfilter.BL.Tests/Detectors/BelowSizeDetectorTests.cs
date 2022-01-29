using MailKit;
using spamfilter.BL.Detectors;
using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using Xunit;

namespace spamfilter.BL.Tests.Detectors;

public class BelowSizeDetectorTests
{
    private IDetector BelowSizeDetector(int detectBelowNBytes)
    {
        return new BelowSizeDetector(detectBelowNBytes);
    }
    
    [Fact]
    public void When_an_email_is_below_a_specified_size_it_is_detected()
    {
        var email = new Email(
            "",
            "",
            UniqueId.Invalid,
            "This is a subject",
            "This body has a size below 1000 bytes."
        );

        var detector = BelowSizeDetector(1000);

        Assert.NotEmpty(detector.GetOpinionsOn(email));
    }
    
    [Fact]
    public void When_an_email_is_bigger_than_a_specified_size_it_is_not_detected()
    {
        var email = new Email(
            "",
            "",
            UniqueId.Invalid,
            "This is a subject",
            "This body is bigger than 20 bytes."
        );

        var detector = BelowSizeDetector(20);

        Assert.Empty(detector.GetOpinionsOn(email));
    }
    
}