using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Extra.ChatApp.Web
{
    [HubName("Chat")]
    public class ChatHub : Hub
    {
      public void SendMessage (string message)
        {
            Clients.All.receiveMessage(message);
        }
    }
}