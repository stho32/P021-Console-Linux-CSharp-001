namespace spamfilter.Interfaces.Entities;

/// <summary>
/// Is this message spam or not?
/// </summary>
public interface IIsMatchOpinion
{
    int Priority { get; }
    string Reasoning { get; }
    string DetectorName { get; }
    bool IsIncluded { get; }
}