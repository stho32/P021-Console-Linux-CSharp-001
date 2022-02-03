using spamfilter.Interfaces;
using spamfilter.Interfaces.Entities;
using spamfilter.Interfaces.Repositories;

namespace spamfilter.BL.Tests.Mocks;

public class EmailRepositoryMock : IEmailRepository
{
    public IEmail[] GetInboxContent()
    {
        return Array.Empty<IEmail>();
    }

    public void MoveMailsToFolder(IEmail[] mails, string folderName)
    {
        MoveMailsToFolderHasBeenCalled = true;
    }

    public bool MoveMailsToFolderHasBeenCalled { get; private set; }
}