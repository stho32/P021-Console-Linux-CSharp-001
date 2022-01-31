using spamfilter.BL.Actions;
using Xunit;

namespace spamfilter.BL.Tests.Actions;

public class MoveEmailToFolderActionFactoryTests
{
    [Fact]
    public void Instanciates_a_class_of_type_MoveEmailToFolderAction()
    {
        var factory = new MoveEmailToFolderActionFactory("targetfolder");
        var action = factory.CreateFromEmail(null);
        Assert.IsType<MoveEmailToFolderAction>(action); 
    }
}