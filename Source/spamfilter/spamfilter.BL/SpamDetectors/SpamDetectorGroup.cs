using spamfilter.Interfaces;
using spamfilter.Interfaces.Environment;

namespace spamfilter.BL.SpamDetectors;

public class SpamDetectorGroup
{
    private readonly ISpamDetector[] _spamDetectors;
    private readonly IEnvironmentFactory _environmentFactory;

    public SpamDetectorGroup(ISpamDetector[] spamDetectors, IEnvironmentFactory environmentFactory)
    {
        _spamDetectors = spamDetectors;
        _environmentFactory = environmentFactory;
    }

    public ISpamDetectionResult[] Filter(IEmail[] emails)
    {
        var logger = _environmentFactory.GetLogger(nameof(SpamDetectorGroup));

        try
        {
            var results = new List<ISpamDetectionResult>();

            foreach (var email in emails)
            {
                var spamDetectionResult = new SpamDetectionResult(email, GetOpinionsOn(email));
                if (spamDetectionResult.IsSpam)
                {
                    logger.Log(
                        $"{spamDetectionResult.Email.Subject} from {spamDetectionResult.Email.SenderEmailaddress} is spam");
                    foreach (var opinion in spamDetectionResult.Opinions)
                    {
                        logger.Log($"  {opinion.DetectorName}: {opinion.Reasoning}");
                    }
                }

                results.Add(spamDetectionResult);
            }

            return results.ToArray();
        }
        catch (Exception e)
        {
            logger.Log(e.ToString());
        }

        return Array.Empty<ISpamDetectionResult>();
    }

    private IIsSpamOpinion[] GetOpinionsOn(IEmail email)
    {
        var results = new List<IIsSpamOpinion>();
        
        foreach (var detector in _spamDetectors)
        {
            results.AddRange(detector.GetOpinionsOn(email));
        }

        return results.ToArray();
    }
}