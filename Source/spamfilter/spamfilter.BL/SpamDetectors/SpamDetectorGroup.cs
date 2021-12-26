using spamfilter.Interfaces;

namespace spamfilter.BL.SpamDetectors;

public class SpamDetectorGroup
{
    private readonly ISpamDetector[] _spamDetectors;

    public SpamDetectorGroup(ISpamDetector[] spamDetectors)
    {
        _spamDetectors = spamDetectors;
    }
    
    public ISpamDetectionResult[] Filter(IEmail[] emails)
    {
        var results = new List<ISpamDetectionResult>();

        foreach (var email in emails)
        {
            results.Add(
                new SpamDetectionResult(
                    email, 
                    GetOpinionsOn(email))
                );
        }

        return results.ToArray();
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