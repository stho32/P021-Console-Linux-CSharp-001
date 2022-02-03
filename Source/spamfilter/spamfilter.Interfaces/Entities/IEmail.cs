using MailKit;

namespace spamfilter.Interfaces.Entities;

/// <summary>
/// This interface contains all necessary information about the mails that we need to operate on
/// </summary>
public interface IEmail
{
    string SenderName { get; }
    string SenderEmailaddress { get; }
    
    UniqueId Id { get; }
    string Subject { get; }
    string TextBody { get; }
    string HtmlBody { get; }
}