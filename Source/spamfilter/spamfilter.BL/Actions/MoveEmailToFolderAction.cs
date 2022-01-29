using spamfilter.Interfaces;

namespace spamfilter.BL.Actions;

public class MoveEmailToFolderAction : IAction
{
    private readonly IEmail _email;
    private readonly IEmailRepository _emailRepository;
    private readonly string _targetFolder;

    public MoveEmailToFolderAction(IEmail email, IEmailRepository emailRepository, 
        string targetFolder)
    {
        _email = email;
        _emailRepository = emailRepository;
        _targetFolder = targetFolder;
    }

    public void Execute()
    {
        _emailRepository.MoveMailsToFolder(new []{ _email }, _targetFolder);
    }
}