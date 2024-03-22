// ChatHub.cs
using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAssemblySignalRApp.Server.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string firstname, string lastname, string category, string message, DateOnly dateCreated) // Modify the method signature to accept DateCreated as a DateOnly
    {
        await Clients.All.SendAsync("ReceiveMessage", firstname, lastname, category, message, dateCreated); // Pass DateCreated to the ReceiveMessage method
    }
}
