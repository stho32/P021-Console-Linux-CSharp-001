using MailKit;
using spamfilter.BL.Actions;
using spamfilter.BL.Entities;
using Xunit;

namespace spamfilter.BL.Tests.Actions;

public class MoveEmailToFolderActionFactoryTests
{
    [Fact]
    public void Instanciates_a_class_of_type_MoveEmailToFolderAction()
    {
        var factory = new MoveEmailToFolderActionFactory("targetfolder");
        var action = factory.CreateFromEmail(new Email("", "", UniqueId.Invalid, "", "", ""));
        Assert.IsType<MoveEmailToFolderAction>(action); 
    }
}