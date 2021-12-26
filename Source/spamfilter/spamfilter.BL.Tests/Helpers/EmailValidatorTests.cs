using spamfilter.BL.Helpers;
using Xunit;

namespace spamfilter.BL.Tests.Helpers;

public class EmailValidatorTests
{
    [Fact]
    public void Empty_addresses_are_not_valid()
    {
        var validator = new EmailValidator();
        
        Assert.False(validator.IsValidEmail(""));
        Assert.False(validator.IsValidEmail("\t"));
        Assert.False(validator.IsValidEmail("     "));
        Assert.False(validator.IsValidEmail(null));
    }

    [Fact]
    public void When_it_ends_with_a_dot_it_is_not_valid()
    {
        var validator = new EmailValidator();
        
        Assert.False(validator.IsValidEmail("test@example.com."));
        Assert.False(validator.IsValidEmail("whatever@somewhere_in_space.com."));
    }
    
    [Fact]
    public void Valid_email_addresses_pass()
    {
        var validator = new EmailValidator();
        
        Assert.True(validator.IsValidEmail("someone@example.com"));
        Assert.True(validator.IsValidEmail("do-not-reply@somewhere_in_space.com"));
    }

    [Fact]
    public void Even_though_it_might_look_otherwise_good_it_is_not_valid()
    {
        var validator = new EmailValidator();
        
        Assert.False(validator.IsValidEmail("test@example.com,boing"));
        Assert.False(validator.IsValidEmail("test@example.com big rubbish"));
    }

}