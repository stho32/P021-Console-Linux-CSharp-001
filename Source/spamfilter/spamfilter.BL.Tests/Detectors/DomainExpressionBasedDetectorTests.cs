using MailKit;
using spamfilter.BL.Detectors;
using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Detectors;
using Xunit;

namespace spamfilter.BL.Tests.Detectors;

public class DomainExpressionBasedDetectorTests
{
    private IDetector DetectorUnderTest(string regEx)
    {
        return new DomainExpressionBasedDetector(regEx);
    }

    [Fact]
    public void When_the_domain_is_matching_the_regular_expression_it_detects()
    {
        var email = new Email(
            "",
            "brian@amazon.de",
            UniqueId.Invalid,
            "",
            ""
        );

        var detector = DetectorUnderTest(@".?\.de");
        
        Assert.NotEmpty(detector.GetOpinionsOn(email));
    }

    [Fact]
    public void When_the_domain_is_not_matching_the_regular_expression_it_does_not_detect()
    {
        var email = new Email(
            "",
            "brian@amazon.de",
            UniqueId.Invalid,
            "",
            ""
        );

        var detector = DetectorUnderTest(@".?\.com");
        
        Assert.Empty(detector.GetOpinionsOn(email));        
    }

    [Fact]
    public void
        When_the_regular_expression_would_match_the_part_before_the_domain_but_not_with_the_domain_it_does_not_detect()
    {
        var email = new Email(
            "",
            "brian@amazon.de",
            UniqueId.Invalid,
            "",
            ""
        );

        var detector = DetectorUnderTest(@"b.?n");
        
        Assert.Empty(detector.GetOpinionsOn(email));        
    }
}