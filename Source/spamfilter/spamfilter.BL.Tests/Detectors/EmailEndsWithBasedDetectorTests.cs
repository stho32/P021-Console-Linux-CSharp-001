using MailKit;
using spamfilter.BL.Detectors;
using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Detectors;
using Xunit;

namespace spamfilter.BL.Tests.Detectors;

public class EmailEndsWithBasedDetectorTests
{
    private IDetector DetectorUnderTest(string emailEndsWith)
    {
        return new EmailEndsWithBasedDetector(emailEndsWith);
    }

    [Fact]
    public void When_the_email_address_ends_with_the_string_then_it_detects()
    {
        var email = new Email(
            "",
            "brian@amazon.de",
            UniqueId.Invalid,
            "",
            ""
        );

        var detector = DetectorUnderTest(@"@amazon.de");
        
        Assert.NotEmpty(detector.GetOpinionsOn(email));
    }

    [Fact]
    public void When_the_email_address_does_not_end_with_the_string_it_does_not_detect()
    {
        var email = new Email(
            "",
            "brian@amazon.de",
            UniqueId.Invalid,
            "",
            ""
        );

        var detector = DetectorUnderTest(@"@1und1.de");
        
        Assert.Empty(detector.GetOpinionsOn(email));        
    }
}