namespace spamfilter.Interfaces.Helpers;

public interface IEmailValidator
{
    bool IsValidEmail(string? email);
}