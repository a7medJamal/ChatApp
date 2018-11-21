using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Extra.ChatApp.Web
{
    [HubName("Chat")]
    public class ChatHub : Hub
    {
        private static readonly string MethodeName = "receiveMessage";
      public void SendMessage (string message)
        {
            Clients.All.receiveMessage(message);
            ((IClientProxy)Clients.All).Invoke(MethodeName, message);


            Clients.Caller.receiveMessage("send");
            Clients.Client(Context.ConnectionId).receiveMessage("send");


            Clients.Others.receiveMessage("New Message");
            Clients.AllExcept(Context.ConnectionId).receiveMessage("New Message");

        }

        public override Task OnConnected()
        {
            Clients.All.receiveMessage($"{Context.ConnectionId} : connected");
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            Clients.All.receiveMessage($"{Context.ConnectionId} : Reconnected");
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.receiveMessage($"{Context.ConnectionId} : Disconnected");
            return base.OnDisconnected(stopCalled);
        }
    }
}