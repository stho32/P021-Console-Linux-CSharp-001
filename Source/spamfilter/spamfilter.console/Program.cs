using spamfilter.BL.ExtensionMethods;
using spamfilter.BL.Logging;
using spamfilter.BL.Repositories;
using spamfilter.BL.Rules;

var environment = new EnvironmentFactory();
var server = environment.GetConfigurationValue("Server");
var username = environment.GetConfigurationValue("Username");
var password = environment.GetConfigurationValue("Password");

var emailRepository = new ImapEmailRepository(server??"", username??"", password??"", environment);

var logger = environment.GetLogger("main");

while (true)
{
    logger.Log("Filter going to work...");

    var factory = new ExampleRuleFactory(emailRepository, environment);
    
    var rules = factory.Create();
    var actions = rules.Execute(emailRepository.GetInboxContent());
    actions.Execute(emailRepository);
    
    logger.Log("Waiting 5 Minutes to restart process...");
    System.Threading.Thread.Sleep(5000*60);
}
