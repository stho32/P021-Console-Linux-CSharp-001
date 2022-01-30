using MailKit;
using spamfilter.BL.Detectors;
using spamfilter.BL.Entities;
using spamfilter.BL.Logging;
using spamfilter.Interfaces;
using Xunit;

namespace spamfilter.BL.Tests.Detectors;

public class DetectorGroupTests
{
    [Fact]
    public void For_every_email_there_is_a_detection_result_based_on_the_detectors()
    {
        var detectorGroup = new DetectorGroup(
            new IDetector[]
            {
                new DetectorMock(false)
            },
            new EnvironmentFactory()
        );

        var results = detectorGroup.Filter(
            new IEmail[]
            {
                new Email("Sender", "Sender", UniqueId.Invalid, "Subject", "Body"),
                new Email("Sender", "Sender", UniqueId.Invalid, "Subject", "Body")
            });
        
        Assert.Equal(2, results.Length);
    }

    [Fact]
    public void When_an_exception_occurs_in_a_detector_we_detect_nothing()
    {
        var detectorGroup = new DetectorGroup(
            new IDetector[]
            {
                new DetectorMock(true)
            },
            new EnvironmentFactory()
        );

        var results = detectorGroup.Filter(
            new IEmail[]
            {
                new Email("Sender", "Sender", UniqueId.Invalid, "Subject", "Body"),
                new Email("Sender", "Sender", UniqueId.Invalid, "Subject", "Body")
            });
        
        Assert.Empty(results);
    }
}