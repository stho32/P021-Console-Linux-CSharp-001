using spamfilter.BL.Detectors;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Environment;

namespace spamfilter.BL;

public class Rule : IRule
{
    private readonly IEmailRepository _emailRepository;
    private readonly IActionFactory _actionFactory;
    private readonly SpamDetectorGroup _spamDetectors;

    public Rule(
        IDetector[] spamDetectors,
        IEmailRepository emailRepository,
        IEnvironmentFactory environmentFactory,
        IActionFactory actionFactory)
    {
        _emailRepository = emailRepository;
        _actionFactory = actionFactory;
        _spamDetectors = new SpamDetectorGroup(spamDetectors, environmentFactory);
    }

    private IDetectionResult[] DetectInInbox()
    {
        var mails = _emailRepository.GetInboxContent();

        var result = _spamDetectors.Filter(mails);

        return result;
    }

    public void Move(IEmail[] spam, string folderName)
    {
        _emailRepository.MoveMailsToFolder(spam, folderName);
    }

    public IAction[] Execute()
    {
        var possiblyMatches = DetectInInbox();
        var matches = possiblyMatches
            .Where(x => x.IsSpam)
            .Select(x=> x.Email).ToArray();

        var result = new List<IAction>();

        foreach(var match in matches) 
        {
            result.Add(_actionFactory.CreateFromEmail(match, _emailRepository));        
        }

        return result.ToArray();
    }
}