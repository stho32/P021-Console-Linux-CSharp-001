using MailKit;
using spamfilter.BL.Detectors;
using spamfilter.BL.Entities;
using spamfilter.BL.Helpers;
using spamfilter.Interfaces;
using Xunit;

namespace spamfilter.BL.Tests.Detectors;

public class ContentBasedDetectorTests
{
    private IDetector Detector(bool checkSubject, bool checkBody)
    {
        return new ContentBasedDetector(
            new TextSearchHelper(),
            new[] {"Hello" },
            checkSubject,
            checkBody);
    }

    [Fact]
    public void When_Hello_is_in_the_subject_and_we_search_for_it_it_detects()
    {
        var email = new Email(
            "",
            "",
            UniqueId.Invalid,
            "Hello",
            ""
        );

        var detector = Detector(true, false);

        Assert.NotEmpty(detector.GetOpinionsOn(email));
    }

    [Fact]
    public void When_Hello_is_not_in_the_subject_and_we_search_for_it_it_does_not_detect()
    {
        var email = new Email(
            "",
            "",
            UniqueId.Invalid,
            "------",
            ""
        );

        var detector = Detector(true, false);

        Assert.Empty(detector.GetOpinionsOn(email));        
    }
    
    [Fact]
    public void When_hello_is_in_the_body_but_we_search_in_the_subject_it_is_not_detected()
    {
        var email = new Email(
            "",
            "",
            UniqueId.Invalid,
            "Here is some other text",
            "Hello"
        );

        var detector = Detector(true, false);

        Assert.Empty(detector.GetOpinionsOn(email));
    }
    
    [Fact]
    public void When_hello_is_in_the_subject_but_we_search_in_the_body_it_is_not_detected()
    {
        var email = new Email(
            "",
            "",
            UniqueId.Invalid,
            "Hello",
            "Some other text"
        );

        var detector = Detector(false, true);

        Assert.Empty(detector.GetOpinionsOn(email));
    }
    
    [Fact]
    public void When_hello_is_in_the_body_and_we_search_in_the_body_it_is_detected()
    {
        var email = new Email(
            "",
            "",
            UniqueId.Invalid,
            "Some other Text",
            "Hello"
        );

        var detector = Detector(false, true);

        Assert.NotEmpty(detector.GetOpinionsOn(email));
    }
}