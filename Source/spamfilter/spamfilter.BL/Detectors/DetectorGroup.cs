using spamfilter.Interfaces;
using spamfilter.Interfaces.Environment;

namespace spamfilter.BL.Detectors;

public class DetectorGroup
{
    private readonly IDetector[] _spamDetectors;
    private readonly IEnvironmentFactory _environmentFactory;

    public DetectorGroup(IDetector[] spamDetectors, IEnvironmentFactory environmentFactory)
    {
        _spamDetectors = spamDetectors;
        _environmentFactory = environmentFactory;
    }

    public IDetectionResult[] Filter(IEmail[] emails)
    {
        var logger = _environmentFactory.GetLogger(nameof(DetectorGroup));

        try
        {
            var results = new List<IDetectionResult>();

            foreach (var email in emails)
            {
                var spamDetectionResult = new DetectionResult(email, GetOpinionsOn(email));
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

        return Array.Empty<IDetectionResult>();
    }

    private IIsMatchOpinion[] GetOpinionsOn(IEmail email)
    {
        var results = new List<IIsMatchOpinion>();
        
        foreach (var detector in _spamDetectors)
        {
            results.AddRange(detector.GetOpinionsOn(email));
        }

        return results.ToArray();
    }
}