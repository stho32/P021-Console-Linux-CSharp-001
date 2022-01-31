using spamfilter.Interfaces;

namespace spamfilter.BL.Tests.ExtensionMethods;

public class EmailRepositoryMock : IEmailRepository
{
    public IEmail[] GetInboxContent()
    {
        return Array.Empty<IEmail>();
    }

    public void MoveMailsToFolder(IEmail[] mails, string folderName)
    {
    }
}