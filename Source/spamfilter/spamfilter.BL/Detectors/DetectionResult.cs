using spamfilter.Interfaces;

namespace spamfilter.BL.Detectors;

public class DetectionResult : IDetectionResult
{
    public DetectionResult(IEmail email, IIsMatchOpinion[] opinions)
    {
        Email = email;
        Opinions = opinions;
    }

    public IEmail Email { get; }
    public IIsMatchOpinion[] Opinions { get; }

    public bool IsSpam
    {
        get
        {
            var opinionsSorted = new List<IIsMatchOpinion>(Opinions);
            opinionsSorted.Sort((x, y) => -1 * x.Priority.CompareTo(y.Priority));

            if (opinionsSorted.Count > 0)
            {
                return opinionsSorted[0].IsSpam;
            }

            return false;
        }
    }
}