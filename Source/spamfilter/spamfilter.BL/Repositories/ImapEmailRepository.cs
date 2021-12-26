using spamfilter.Interfaces;
using MailKit.Net.Imap;
using MailKit;
using MailKit.Search;
using MimeKit;
using spamfilter.BL.Entities;

namespace spamfilter.BL.Repositories;

/// <summary>
/// Imap client
/// </summary>
public class ImapEmailRepository : IEmailRepository
{
    private readonly string _server;
    private readonly string _username;
    private readonly string _password;

    public ImapEmailRepository(string server, string username, string password)
    {
        _server = server;
        _username = username;
        _password = password;
    }

    public void MoveMailsToFolder(IEmail[] mails, string folderName)
    {
        using var client = new ImapClient ();
        
        client.Connect (_server, 993, true);
        client.Authenticate (_username, _password);

        var inbox = client.Inbox;
        inbox.Open (FolderAccess.ReadOnly);
        
        IMailFolder matchFolder = null;
        foreach (var folder in client.Inbox.GetSubfolders (false)) {
            if (folder.Name == folderName)
            {
                matchFolder = folder;
                break;
            }
        }

        if (matchFolder == null)
            throw new Exception($"Subfolder {folderName} not found.");
        
        var ids = mails.Select(x => x.Id).ToArray();

        inbox.Open(FolderAccess.ReadWrite);
        
        inbox.MoveTo(ids, matchFolder);                

        client.Disconnect (true);
    }
    
    public IEmail[] GetInboxContent()
    {
        using var client = new ImapClient ();
        
        client.Connect (_server, 993, true);
        client.Authenticate (_username, _password);

        var inbox = client.Inbox;
        client.Inbox.Open(FolderAccess.ReadOnly);
        var uniqueIds = client.Inbox.Search (SearchQuery.All);

        var result = new List<IEmail>();
            
        foreach (var uniqueId in uniqueIds)
        {
            var message = inbox.GetMessage (uniqueId);
            var senderNames = string.Join(";", message.From.Select(x => x.Name));
            var senderAddress = string.Join(";", message.From.Select(x => (x as MailboxAddress)?.Address));

            result.Add(new Email(
                senderNames,
                senderAddress,
                uniqueId,
                message.Subject,
                message.TextBody));
        }

        client.Disconnect (true);
        return result.ToArray();
    }
}