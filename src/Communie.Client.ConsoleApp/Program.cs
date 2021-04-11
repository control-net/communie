using System;
using System.Linq;
using Microsoft.AspNetCore.SignalR.Client;

var serverUrl = args.Any() ? args[0] : "https://localhost:5001/chathub";

var hubConnection = new HubConnectionBuilder()
    .WithUrl(serverUrl)
    .Build();

hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
{
    var encodedMsg = $"{user}: {message}";
    Console.WriteLine(string.Empty);
    Console.WriteLine(encodedMsg);
});

await hubConnection.StartAsync();

while(true)
{
    Console.Write("> ");
    var msg = Console.ReadLine();

    if(msg.ToLower() == "exit")
    {
        await hubConnection.DisposeAsync();
        Environment.Exit(0);
    }

    await hubConnection.SendAsync("SendMessage", "ConsoleUser", msg);

    Console.WriteLine(string.Empty);
}
