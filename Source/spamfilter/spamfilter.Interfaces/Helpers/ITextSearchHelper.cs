namespace spamfilter.Interfaces.Helpers;

public interface ITextSearchHelper
{
    bool ContainsOneOfTheseWords(string text, string[] words);
}