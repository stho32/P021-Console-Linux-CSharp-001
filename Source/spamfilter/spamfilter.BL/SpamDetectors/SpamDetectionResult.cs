using spamfilter.Interfaces;

namespace spamfilter.BL.SpamDetectors;

public class SpamDetectionResult : ISpamDetectionResult
{
    public SpamDetectionResult(IEmail email, IIsSpamOpinion[] opinions)
    {
        Email = email;
        Opinions = opinions;
    }

    public IEmail Email { get; }
    public IIsSpamOpinion[] Opinions { get; }

    public bool IsSpam
    {
        get
        {
            var opinionsSorted = new List<IIsSpamOpinion>(Opinions);
            opinionsSorted.Sort((x, y) => -1 * x.Priority.CompareTo(y.Priority));

            if (opinionsSorted.Count > 0)
            {
                return opinionsSorted[0].IsSpam;
            }

            return false;
        }
    }
}