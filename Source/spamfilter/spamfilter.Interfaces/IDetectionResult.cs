namespace spamfilter.Interfaces;

public interface IDetectionResult
{
    IEmail Email { get; }
    IIsMatchOpinion[] Opinions { get; }
    bool IsSpam { get; }
}