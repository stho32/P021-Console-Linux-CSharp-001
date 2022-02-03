using MailKit;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Entities;

namespace spamfilter.BL.Entities;

public class Email : IEmail
{
    public string SenderName { get; }
    public string SenderEmailaddress { get; }
    public UniqueId Id { get; }
    public string Subject { get; }
    public string Body { get; }

    public Email(string senderName, string senderEmailaddress, UniqueId id, string subject, string body)
    {
        SenderName = senderName;
        SenderEmailaddress = senderEmailaddress;
        Id = id;
        Subject = subject;
        Body = body;
    }

    public override string ToString()
    {
        return $"{nameof(SenderName)}: {SenderName}, {nameof(SenderEmailaddress)}: {SenderEmailaddress}, {nameof(Id)}: {Id}, {nameof(Subject)}: {Subject}";
    }
}