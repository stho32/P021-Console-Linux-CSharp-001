using spamfilter.Interfaces.Actions;
using spamfilter.Interfaces.Entities;

namespace spamfilter.BL.Actions;

public class MoveEmailToFolderActionFactory : IActionFactory
{
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