using spamfilter.BL;
using spamfilter.BL.Helpers;
using spamfilter.BL.Repositories;
using spamfilter.BL.SpamDetectors;
using spamfilter.Interfaces;

Console.Write("Server: ");
var server = Console.ReadLine();
Console.Write("Username: ");
var username = Console.ReadLine();
Console.Write("Password: ");
var password = Console.ReadLine();

var spamfilter = new Spamfilter(
    server??"",
    username??"",
    password??"",
    new ISpamDetector[]
    {
        new InvalidSenderEmailAddressSpamDetector(new EmailValidator()),
        new DomainExpressionBasedSpamDetector("ip-.+"),
        new ImpersonatorSpamDetector("Amazon", new string[] { "amazon.de", "amazon.com" }),
        new EmailEndsWithBasedSpamDetector(".ru"),
        new EmailEndsWithBasedSpamDetector(".br"),
        new EmailEndsWithBasedSpamDetector("@next-traffic-news.de"),
        new EmailEndsWithBasedSpamDetector("no-reply@nebenan.de")
    });

var results = spamfilter.DetectSpamInInbox();
var spam = results
    .Where(x => x.IsSpam)
    .Select(x=> x.Email).ToArray();

spamfilter.Move(spam, "MySpam");