using spamfilter.Interfaces;

namespace spamfilter.BL.Entities;

public class IsMatchOpinion : IIsMatchOpinion
{
    public int Priority { get; }
    public string Reasoning { get; }
    public string DetectorName { get; }
    public bool IsSpam { get; }

    public IsMatchOpinion(int priority, string reasoning, string detectorName, bool isSpam)
    {
        Priority = priority;
        Reasoning = reasoning;
        DetectorName = detectorName;
        IsSpam = isSpam;
    }

    public override string ToString()
    {
        return $"{nameof(Priority)}: {Priority}, {nameof(Reasoning)}: {Reasoning}, {nameof(DetectorName)}: {DetectorName}";
    }
}