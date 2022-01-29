using spamfilter.Interfaces;

namespace spamfilter.BL.Actions;

public class MoveEmailToFolderActionFactory : IActionFactory
{
    private readonly string _targetFolder;

    public MoveEmailToFolderActionFactory(string targetFolder)
    {
        _targetFolder = targetFolder;
    }
    
    public IAction CreateFromEmail(IEmail email, IEmailRepository emailRepository)
    {
        return new MoveEmailToFolderAction(email, emailRepository, _targetFolder);
    }
}