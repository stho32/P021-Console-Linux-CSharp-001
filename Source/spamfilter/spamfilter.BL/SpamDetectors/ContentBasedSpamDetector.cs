using spamfilter.BL.Entities;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Helpers;

namespace spamfilter.BL.SpamDetectors;

public class ContentBasedSpamDetector : ISpamDetector
{
    private readonly ITextSearchHelper _textSearchHelper;
    private readonly string[] _words;

    public ContentBasedSpamDetector(ITextSearchHelper textSearchHelper, string[] words)
    {
        _textSearchHelper = textSearchHelper;
        _words = words.Select(x => x.ToLower()).ToArray();
    }
    
    public IIsSpamOpinion[] GetOpinionsOn(IEmail email)
    {
        if (_textSearchHelper.ContainsOneOfTheseWords(email.Subject, _words))
        {
            return new IIsSpamOpinion[]
            {
                new IsSpamOpinion(100, 
                    $"The emails subject {email.Subject} contains suspicious words", 
                    nameof(ContentBasedSpamDetector),
                    true)
            };
        }
        if (_textSearchHelper.ContainsOneOfTheseWords(email.Body, _words))
        {
            return new IIsSpamOpinion[]
            {
                new IsSpamOpinion(100, 
                    $"The emails body ({email.Subject}) contains suspicious words", 
                    nameof(ContentBasedSpamDetector),
                    true)
            };
        }

        return Array.Empty<IIsSpamOpinion>();
    }
}
