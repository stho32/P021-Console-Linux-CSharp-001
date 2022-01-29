using spamfilter.Interfaces;

namespace spamfilter.BL.Actions;

public class MoveEmailToFolderAction : IAction
{
    private readonly IEmail _email;
    private readonly string _targetFolder;

    public MoveEmailToFolderAction(IEmail email, 
        string targetFolder)
    {
        _email = email;
        _targetFolder = targetFolder;
    }

    public void Execute(IEmailRepository emailRepository)
    {
        emailRepository.MoveMailsToFolder(new []{ _email }, _targetFolder);
    }
}