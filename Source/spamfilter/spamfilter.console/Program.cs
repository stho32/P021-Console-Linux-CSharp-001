using MailKit.Net.Imap;
using MailKit;

using (var client = new ImapClient ()) {
    Console.Write("Server: ");
    var server = Console.ReadLine();
    client.Connect (server, 993, true);

    Console.Write("Username: ");
    var username = Console.ReadLine();
    Console.Write("Password: ");
    var password = Console.ReadLine();
    
    client.Authenticate (username, password);

    // The Inbox folder is always available on all IMAP servers...
    var inbox = client.Inbox;
    inbox.Open (FolderAccess.ReadOnly);

    Console.WriteLine ("Total messages: {0}", inbox.Count);
    Console.WriteLine ("Recent messages: {0}", inbox.Recent);

    for (int i = 0; i < inbox.Count; i++) {
        var message = inbox.GetMessage (i);
        Console.WriteLine ("Subject: {0}", message.Subject);
    }

    client.Disconnect (true);
}
