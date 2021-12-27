using spamfilter.BL;
using spamfilter.BL.Helpers;
using spamfilter.BL.Logging;
using spamfilter.BL.Repositories;
using spamfilter.BL.SpamDetectors;
using spamfilter.Interfaces;

var environment = new EnvironmentFactory();
var server = environment.GetConfigurationValue("Server");
var username = environment.GetConfigurationValue("Username");
var password = environment.GetConfigurationValue("Password");

var emailRepository = new ImapEmailRepository(server??"", username??"", password??"", environment);

var logger = environment.GetLogger("main");

while (true)
{
    logger.Log("Spamfilter going to work...");

    var spamfilter = new Spamfilter(
        new ISpamDetector[]
        {
            new InvalidSenderEmailAddressSpamDetector(new EmailValidator()),
            new DomainExpressionBasedSpamDetector("ip-.+"),
            new ImpersonatorSpamDetector("Amazon", new string[] { "amazon.de", "amazon.com" }),
            new EmailEndsWithBasedSpamDetector(".ru"),
            new EmailEndsWithBasedSpamDetector(".br"),
            new EmailEndsWithBasedSpamDetector("@next-traffic-news.de"),
            new EmailEndsWithBasedSpamDetector("no-reply@nebenan.de")
        }, 
        emailRepository,
        environment
        );

    var results = spamfilter.DetectSpamInInbox();
    var spam = results
        .Where(x => x.IsSpam)
        .Select(x=> x.Email).ToArray();

    if (spam.Length > 0)
    {
        spamfilter.Move(spam, "MySpam");        
    }
    
    logger.Log("Waiting 5 Minutes to restart process...");
    System.Threading.Thread.Sleep(5000*60);
}
