using spamfilter.Interfaces;

namespace spamfilter.BL.Entities;

public class IsSpamOpinion : IIsSpamOpinion
{
    public int Priority { get; }
    public string Reasoning { get; }
    public string DetectorName { get; }
    public bool IsSpam { get; }

    public IsSpamOpinion(int priority, string reasoning, string detectorName, bool isSpam)
    {
        Priority = priority;
        Reasoning = reasoning;
        DetectorName = detectorName;
        IsSpam = isSpam;
    }
}