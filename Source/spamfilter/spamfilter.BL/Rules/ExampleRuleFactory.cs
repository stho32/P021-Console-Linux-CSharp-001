using spamfilter.BL.Actions;
using spamfilter.BL.Detectors;
using spamfilter.BL.Helpers;
using spamfilter.Interfaces;
using spamfilter.Interfaces.Detectors;
using spamfilter.Interfaces.Environment;
using spamfilter.Interfaces.Repositories;
using spamfilter.Interfaces.Rules;

namespace spamfilter.BL.Rules;

public class ExampleRuleFactory : IRuleFactory
{
    private readonly IEmailRepository _emailRepository;
    private readonly IEnvironmentFactory _environmentFactory;

    public ExampleRuleFactory(IEmailRepository emailRepository,
        IEnvironmentFactory environmentFactory)
    {
        _emailRepository = emailRepository;
        _environmentFactory = environmentFactory;
    }
    
    public IRule Create()
    {
        var rules = new List<IRule>();
        
        rules.Add(new Rule(
            new IDetector[]
            {
                new InvalidSenderEmailAddressDetector(new EmailValidator()),
                new DomainExpressionBasedDetector("ip-.+"),
                new ImpersonatorDetector("Amazon", new string[] { "amazon.de", "amazon.com" }),
                new EmailEndsWithBasedDetector(".ru"),
                new EmailEndsWithBasedDetector(".br"),
                new EmailEndsWithBasedDetector("@next-traffic-news.de"),
                new EmailEndsWithBasedDetector("no-reply@nebenan.de"),
                new EmailEndsWithBasedDetector("@mailing.fleurop.de"),
                new EmailEndsWithBasedDetector("@email.udemy.com"),
                new EmailEndsWithBasedDetector("@heroku.com"),
            }, 
            _environmentFactory,
            new MoveEmailToFolderActionFactory("MySpam")
        ));

        rules.Add(new Rule(
            new []{ new EmailEndsWithBasedDetector("@italki.com")},
            _environmentFactory, new MoveEmailToFolderActionFactory("iTalki")
            ));

        rules.Add(new Rule(
            new []{ new EmailEndsWithBasedDetector("@github.com")},
            _environmentFactory, new MoveEmailToFolderActionFactory("GitHub")
        ));
        
        rules.Add(new Rule(
            new []{ new EmailEndsWithBasedDetector("@amazon.de")},
            _environmentFactory, new MoveEmailToFolderActionFactory("Amazon")
        ));        

        rules.Add(new Rule(new [] {new EmailEndsWithBasedDetector("@paypal.de")},
            _environmentFactory, new MoveEmailToFolderActionFactory("PayPal")
        ));
        
        rules.Add(new Rule(new [] {new EmailEndsWithBasedDetector("@free-now.com")},
            _environmentFactory, new MoveEmailToFolderActionFactory("FreeNow")
        ));
        
        rules.Add(new Rule(
            new []{ new EmailEndsWithBasedDetector("@meetup.com")},
            _environmentFactory, new MoveEmailToFolderActionFactory("Meetup")
        ));
        
        rules.Add(new Rule(
            new []
            {
                new EmailEndsWithBasedDetector("@mlp.de"),
                new EmailEndsWithBasedDetector("@tk.de"),
                new EmailEndsWithBasedDetector("@rewe.de"),
                new EmailEndsWithBasedDetector("@linkedin.com"),
                new EmailEndsWithBasedDetector("@my-vpa.com"),
                new EmailEndsWithBasedDetector("@mailing.rewe.de"),
                new EmailEndsWithBasedDetector("@1und1.de"),
            },
            _environmentFactory, new MoveEmailToFolderActionFactory("_HamMail")
        ));        
        
        return new RuleList(rules.ToArray());
    }
}