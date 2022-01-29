using spamfilter.BL;
using spamfilter.BL.Actions;
using spamfilter.BL.Detectors;
using spamfilter.BL.Helpers;
using spamfilter.BL.Logging;
using spamfilter.BL.Repositories;
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

    var spamRule = new Rule(
        new IDetector[]
        {
            new InvalidSenderEmailAddressDetector(new EmailValidator()),
            new DomainExpressionBasedDetector("ip-.+"),
            new ImpersonatorDetector("Amazon", new string[] { "amazon.de", "amazon.com" }),
            new EmailEndsWithBasedDetector(".ru"),
            new EmailEndsWithBasedDetector(".br"),
            new EmailEndsWithBasedDetector("@next-traffic-news.de"),
            new EmailEndsWithBasedDetector("no-reply@nebenan.de")
        }, 
        emailRepository,
        environment,
        new MoveEmailToFolderActionFactory("MySpam")
        );

    var actions = spamRule.Execute();

    foreach (var action in actions)
    {
        action.Execute();
    }
    
    logger.Log("Waiting 5 Minutes to restart process...");
    System.Threading.Thread.Sleep(5000*60);
}
