using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Detectors;
using spamfilter.Interfaces.Entities;

namespace spamfilter.BL.Tests.Detectors;

public class DetectorMock : IDetector
{
    private readonly bool _throwException;

    public DetectorMock(bool throwException)
    {
        _throwException = throwException;
    }

    public IIsMatchOpinion[] GetOpinionsOn(IEmail email)
    {
        if (_throwException)
        {
            throw new Exception("Boom");
        }
        
        return new IIsMatchOpinion[]
        {
            new IsMatchOpinion(100, "I think it is", "Detector", true)
        };
    }
}