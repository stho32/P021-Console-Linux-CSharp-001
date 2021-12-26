namespace spamfilter.Interfaces;

public interface ISpamDetectionResult
{
    IEmail Email { get; }
    IIsSpamOpinion[] Opinions { get; }
    bool IsSpam { get; }
}