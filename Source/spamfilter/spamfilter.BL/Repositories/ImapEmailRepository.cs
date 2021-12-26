using spamfilter.Interfaces;
using MailKit.Net.Imap;
using MailKit;
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
    
    public IEmail[] GetInboxContent()
    {
        using var client = new ImapClient ();
        
        client.Connect (_server, 993, true);
        client.Authenticate (_username, _password);

        var inbox = client.Inbox;
        inbox.Open (FolderAccess.ReadOnly);

        var result = new List<IEmail>();
            
        for (var i = 0; i < inbox.Count; i++) {
            var message = inbox.GetMessage (i);
            var senderNames = string.Join(";", message.From.Select(x => x.Name));
            var senderAddress = string.Join(";", message.From.Select(x => (x as MailboxAddress)?.Address));
            
            result.Add(new Email(
                senderNames,
                senderAddress,
                message.MessageId,
                message.Subject));
        }

        client.Disconnect (true);
        return result.ToArray();
    }
}