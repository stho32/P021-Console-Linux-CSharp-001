using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Detectors;
using spamfilter.Interfaces.Entities;
using spamfilter.Interfaces.Helpers;

namespace spamfilter.BL.Detectors;

public class ContentBasedDetector : IDetector
{
    private readonly ITextSearchHelper _textSearchHelper;
    private readonly bool _checkSubject;
    private readonly bool _checkBody;
    private readonly string[] _words;

    public ContentBasedDetector(ITextSearchHelper textSearchHelper, string[] words, 
        bool checkSubject, bool checkBody)
    {
        _textSearchHelper = textSearchHelper;
        _checkSubject = checkSubject;
        _checkBody = checkBody;
        _words = words.Select(x => x.ToLower()).ToArray();
    }
    
    public IIsMatchOpinion[] GetOpinionsOn(IEmail email)
    {
        var result = new List<IIsMatchOpinion>();
        
        if (_checkSubject)
        {
            if (_textSearchHelper.ContainsOneOfTheseWords(email.Subject, _words))
            {
                result.Add(
                    new IsMatchOpinion(100,
                        $"The emails subject {email.Subject} contains suspicious words",
                        nameof(ContentBasedDetector),
                        true)
                );
            }
        }

        if (_checkBody)
        {
            if (_textSearchHelper.ContainsOneOfTheseWords(email.Body, _words))
            {
                result.Add(
                    new IsMatchOpinion(100,
                        $"The emails body ({email.Subject}) contains suspicious words",
                        nameof(ContentBasedDetector),
                        true)
                );
            }
        }

        return result.ToArray();
    }
}
