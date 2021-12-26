using spamfilter.BL.Repositories;

Console.Write("Server: ");
var server = Console.ReadLine();
Console.Write("Username: ");
var username = Console.ReadLine();
Console.Write("Password: ");
var password = Console.ReadLine();

var imapRepository = new ImapEmailRepository(server??"", username??"", password??"");

var mails = imapRepository.GetInboxContent();

foreach (var mail in mails)
{
    Console.WriteLine(mail);
}