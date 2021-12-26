using spamfilter.Interfaces.Helpers;

namespace spamfilter.BL.Helpers;

public class EmailValidator : IEmailValidator
{
    /// <summary>
    /// Checks, if the given address is a valid email address (lexically)
    /// </summary>
    /// <param name="email">the address to verify</param>
    /// <returns></returns>
    public bool IsValidEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith(".")) {
            return false;
        }
        
        try {
            var address = new System.Net.Mail.MailAddress(email);
            return address.Address == trimmedEmail;
        }
        catch {
            return false;
        }
    }
}