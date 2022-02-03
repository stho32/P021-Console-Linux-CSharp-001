using MailKit;
using spamfilter.Interfaces.Entities;

namespace spamfilter.BL.Entities;

public class Email : IEmail
{
    public string SenderName { get; }
    public string SenderEmailaddress { get; }
    public UniqueId Id { get; }
    public string Subject { get; }
    public string TextBody { get; }
    public string HtmlBody { get; }

    public Email(string senderName, string senderEmailaddress, UniqueId id, string subject, string body, string htmlBody)
    {
        SenderName = senderName;
        SenderEmailaddress = senderEmailaddress;
        Id = id;
        Subject = subject;
        TextBody = body;
        HtmlBody = htmlBody;
    }

    public override string ToString()
    {
        return $"{nameof(SenderName)}: {SenderName}, {nameof(SenderEmailaddress)}: {SenderEmailaddress}, {nameof(Id)}: {Id}, {nameof(Subject)}: {Subject}";
    }

    public static IEmail Empty()
    {
        return new Email(
            "", 
            "", 
            UniqueId.Invalid, 
            "", 
            "", 
            ""
        );
    }
}