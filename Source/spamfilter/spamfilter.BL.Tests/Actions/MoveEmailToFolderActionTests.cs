using spamfilter.BL.Actions;
using spamfilter.BL.Entities;
using spamfilter.BL.Tests.Mocks;
using Xunit;

namespace spamfilter.BL.Tests.Actions;

public class MoveEmailToFolderActionTests
{
    [Fact]
    public void Execute_calls_the_MoveEmailToFolder_method_of_the_emailrepository()
    {
        var emailrepository = new EmailRepositoryMock();
        var action = new MoveEmailToFolderAction(
            Email.Empty(), 
            "SomeFolder");
        action.Execute(emailrepository);
        
        Assert.True(emailrepository.MoveMailsToFolderHasBeenCalled);
    }
}