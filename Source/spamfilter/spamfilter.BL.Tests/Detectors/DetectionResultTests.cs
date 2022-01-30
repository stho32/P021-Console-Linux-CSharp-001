using MailKit;
using spamfilter.BL.Detectors;
using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using Xunit;

namespace spamfilter.BL.Tests.Detectors;

public class DetectionResultTests
{
    [Fact]
    public void ConstructionTest()
    {
        var detectionResult = new DetectionResult(
            new Email(
                "Hello world",
                "",
                UniqueId.Invalid,
                "Subject",
                "Body"),
            Array.Empty<IIsMatchOpinion>());
        
        Assert.Equal("Hello world", detectionResult.Email.SenderName);
        Assert.Empty(detectionResult.Opinions);
        Assert.False(detectionResult.IsIncluded);
    }

    [Fact]
    public void When_multiple_opinions_are_there_the_one_with_the_highest_priority_is_used()
    {
        var detectionResult = new DetectionResult(
            new Email(
                "Hello world",
                "",
                UniqueId.Invalid,
                "Subject",
                "Body"),
            new IIsMatchOpinion[]
            {
                new IsMatchOpinion(10, "I am uncertain", "Someone", true),
                new IsMatchOpinion(20, "I do not know", "Someone", true),
                new IsMatchOpinion(1000, "I am certain", "Someone", false),
                new IsMatchOpinion(1, "No one wants to know my opinion", "Someone", true)
            });
        
        Assert.False(detectionResult.IsIncluded);
    }
}