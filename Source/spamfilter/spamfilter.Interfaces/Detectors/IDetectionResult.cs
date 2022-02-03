using spamfilter.Interfaces.Entities;

namespace spamfilter.Interfaces.Detectors;

public interface IDetectionResult
{
    IEmail Email { get; }
    IIsMatchOpinion[] Opinions { get; }
    bool IsIncluded { get; }
}