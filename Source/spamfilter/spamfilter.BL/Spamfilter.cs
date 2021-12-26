using spamfilter.BL.Repositories;
using spamfilter.BL.SpamDetectors;
using spamfilter.Interfaces;

namespace spamfilter.BL;

public class Spamfilter
{
    private readonly string _server;
    private readonly string _username;
    private readonly string _password;
    private readonly SpamDetectorGroup _spamDetectors;

    public Spamfilter(
        string server,
        string username,
        string password,
        ISpamDetector[] spamDetectors)
    {
        _server = server;
        _username = username;
        _password = password;
        _spamDetectors = new SpamDetectorGroup(spamDetectors);
    }

    public ISpamDetectionResult[] DetectSpamInInbox()
    {
        var imapRepository = new ImapEmailRepository(_server, _username, _password);
        var mails = imapRepository.GetInboxContent();

        var result = _spamDetectors.Filter(mails);
        
        /*
        foreach (var entry in result)
        {
            Console.WriteLine($" - {entry.Email.SenderEmailaddress} : {entry.Email.Subject}");
            if (entry.IsSpam)
            {
                Console.WriteLine($" -> Is spam because");
                foreach (var opinion in entry.Opinions)
                {
                    Console.WriteLine($"   -> {opinion}");
                }
            }
        }*/

        return result;
    }

    public void Move(IEmail[] spam, string folderName)
    {
        var imapRepository = new ImapEmailRepository(_server, _username, _password);
        imapRepository.MoveMailsToFolder(spam, folderName);
    }
}