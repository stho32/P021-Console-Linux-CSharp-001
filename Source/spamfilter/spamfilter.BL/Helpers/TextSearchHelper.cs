using spamfilter.Interfaces.Helpers;

namespace spamfilter.BL.Helpers;

public class TextSearchHelper : ITextSearchHelper
{
    public bool ContainsOneOfTheseWords(string text, string[] words)
    {
        var split = TextAsWords(text);

        foreach (var word in words)
        {
            foreach (var textPart in split)
            {
                if (String.Equals(word, textPart, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private string[] TextAsWords(string text)
    {
        return text.Split(new[] {" ", "\t", "\n", "\r", ".", ","},
            StringSplitOptions.RemoveEmptyEntries |
            StringSplitOptions.TrimEntries);
    }
}