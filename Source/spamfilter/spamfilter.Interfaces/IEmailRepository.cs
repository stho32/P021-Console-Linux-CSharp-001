namespace spamfilter.Interfaces;

/// <summary>
/// Within this application we look upon an email client as a repository.
/// It is essentially your email client.
/// </summary>
public interface IEmailRepository
{
    IEmail[] GetInboxContent();
}