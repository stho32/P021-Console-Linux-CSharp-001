using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Detectors;
using spamfilter.Interfaces.Entities;

namespace spamfilter.BL.Detectors;

public class BelowSizeDetector : IDetector
{
    private readonly int _detectBodySizeBelowNBytes;

    public BelowSizeDetector(int detectBodySizeBelowNBytes)
    {
        _detectBodySizeBelowNBytes = detectBodySizeBelowNBytes;
    }
    
    public IIsMatchOpinion[] GetOpinionsOn(IEmail email)
    {
        if (email.Body.Length < _detectBodySizeBelowNBytes)
        {
            return new IIsMatchOpinion[]
            {
                new IsMatchOpinion(100,
                    $"Body length less than {_detectBodySizeBelowNBytes} bytes",
                    nameof(BelowSizeDetector),
                    true)
            };
        }
        
        return Array.Empty<IIsMatchOpinion>();
    }
}