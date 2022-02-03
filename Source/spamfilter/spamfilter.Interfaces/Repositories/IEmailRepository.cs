using spamfilter.Interfaces.Entities;

namespace spamfilter.Interfaces.Repositories;

/// <summary>
/// Within this application we look upon an email client as a repository.
/// It is essentially your email client.
/// </summary>
public interface IEmailRepository
{
    IEmail[] GetInboxContent();
    void MoveMailsToFolder(IEmail[] mails, string folderName);
}