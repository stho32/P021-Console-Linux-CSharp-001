using spamfilter.BL.SpamDetectors;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Environment;

namespace spamfilter.BL;

public class Spamfilter
{
    private readonly IEmailRepository _emailRepository;
    private readonly SpamDetectorGroup _spamDetectors;

    public Spamfilter(
        ISpamDetector[] spamDetectors,
        IEmailRepository emailRepository,
        IEnvironmentFactory environmentFactory)
    {
        _emailRepository = emailRepository;
        _spamDetectors = new SpamDetectorGroup(spamDetectors, environmentFactory);
    }

    public ISpamDetectionResult[] DetectSpamInInbox()
    {
        var mails = _emailRepository.GetInboxContent();

        var result = _spamDetectors.Filter(mails);

        return result;
    }

    public void Move(IEmail[] spam, string folderName)
    {
        _emailRepository.MoveMailsToFolder(spam, folderName);
    }
}