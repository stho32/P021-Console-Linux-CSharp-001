using spamfilter.BL.Helpers;
using Xunit;

namespace spamfilter.BL.Tests.Helpers;

public class TextSearchHelperTests
{
    [Fact]
    public void When_the_text_doesnt_contain_any_of_the_words()
    {
        var helper = new TextSearchHelper();
        var text = "A schnabberlocky picky plocky run around a pubber flocky.";

        Assert.True(helper.ContainsOneOfTheseWords(text, new[] {"schnabberlocky"}));
    }

    [Fact]
    public void The_text_needs_to_contain_at_least_one_of_the_given_words_when_multiple_are_given()
    {
        var helper = new TextSearchHelper();
        var text = "A schnabberlocky picky plocky run around a pubber flocky.";

        Assert.True(helper.ContainsOneOfTheseWords(text, new[] {"car", "schnabberlocky"}));        
    }

    [Fact]
    public void Words_are_detected_as_whole_entities()
    {
        var helper = new TextSearchHelper();
        var text = "A schnabberlocky picky plocky run around a pubber flocky.";

        // As schnabber is only a part of schnabberlocky, as such it does not trigger the detection
        Assert.False(helper.ContainsOneOfTheseWords(text, new[] {"schnabber"}));        
    }
    
    [Fact]
    public void If_words_are_not_found_result_is_False()
    {
        var helper = new TextSearchHelper();
        var text = "A schnabberlocky picky plocky run around a pubber flocky.";

        // As schnabber is only a part of schnabberlocky, as such it does not trigger the detection
        Assert.False(helper.ContainsOneOfTheseWords(text, new[] {"car"}));        
    }
}