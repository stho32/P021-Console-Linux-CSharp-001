using spamfilter.BL.Entities;
using spamfilter.BL.SpamDetectors;
using spamfilter.Interfaces;
using Xunit;

namespace spamfilter.BL.Tests.SpamDetectors;

public class ImpersonatorSpamDetectorTests
{
    private ISpamDetector SpamDetector()
    {
        var detector = new ImpersonatorSpamDetector("Amazon", new string[]
        {
            "amazon.com",
            "amazon.de"
        });

        return detector;
    }
    
    [Fact]
    public void A_mail_from_amazon_is_ok_if_it_is_from_amazon_de()
    {
        var mail = new Email(
            "Amazon",
            "amazon@amazon.de",
            "123",
            "Your orders");
        
        Assert.Empty(SpamDetector().GetOpinionsOn(mail));
    }
    
    [Fact]
    public void A_mail_from_amazon_is_ok_if_it_is_from_amazon_com()
    {
        var mail = new Email(
            "Amazon",
            "amazon@amazon.com",
            "123",
            "Your orders");
        
        Assert.Empty(SpamDetector().GetOpinionsOn(mail));
    }
    
    [Fact]
    public void A_mail_from_amazon_is_NOT_ok_if_domain_is_wrong()
    {
        var mail = new Email(
            "Amazon",
            "amazon@someimpersonator.com",
            "123",
            "Your orders");

        var result = SpamDetector().GetOpinionsOn(mail);
        Assert.Single(result);
        Assert.True(result[0].IsSpam);
    }
}