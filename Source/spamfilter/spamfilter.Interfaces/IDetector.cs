namespace spamfilter.Interfaces;

/// <summary>
/// A spam-detector collects several opinions about an email
/// </summary>
public interface IDetector
{
    IIsMatchOpinion[] GetOpinionsOn(IEmail email);
}