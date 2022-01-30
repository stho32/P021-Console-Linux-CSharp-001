namespace spamfilter.Interfaces;

public interface IDetectionResult
{
    IEmail Email { get; }
    IIsMatchOpinion[] Opinions { get; }
    bool IsIncluded { get; }
}