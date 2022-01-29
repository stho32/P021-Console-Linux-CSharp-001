using spamfilter.Interfaces;

namespace spamfilter.BL.Actions;

public class MoveEmailToFolderActionFactory : IActionFactory
{
    private readonly IEmailRepository _emailRepository;
    private readonly string _targetFolder;

    public MoveEmailToFolderActionFactory(string targetFolder)
    {
        _targetFolder = targetFolder;
    }
    
    public IAction CreateFromEmail(IEmail email)
    {
        return new MoveEmailToFolderAction(email, _targetFolder);
    }
}