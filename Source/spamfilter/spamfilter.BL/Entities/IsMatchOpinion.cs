using spamfilter.Interfaces;

namespace spamfilter.BL.Entities;

public class IsMatchOpinion : IIsMatchOpinion
{
    public int Priority { get; }
    public string Reasoning { get; }
    public string DetectorName { get; }
    public bool IsIncluded { get; }

    public IsMatchOpinion(int priority, string reasoning, string detectorName, bool isIncluded)
    {
        Priority = priority;
        Reasoning = reasoning;
        DetectorName = detectorName;
        IsIncluded = isIncluded;
    }

    public override string ToString()
    {
        return $"{nameof(Priority)}: {Priority}, {nameof(Reasoning)}: {Reasoning}, {nameof(DetectorName)}: {DetectorName}";
    }
}