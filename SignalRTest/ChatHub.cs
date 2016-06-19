using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRTest
{
    public class ChatHub : Hub
    {
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}

        //public override Task OnConnected()
        //{
        //    Groups.Add(Context.ConnectionId, Context.User.Identity.Name);
        //    return base.OnConnected();
        //}

        //public override Task OnReconnected()
        //{
        //    Groups.Add(Context.ConnectionId, Context.User.Identity.Name);
        //    return base.OnReconnected();
        //}

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    Groups.Remove(Context.ConnectionId, Context.User.Identity.Name);
        //    return base.OnDisconnected(stopCalled);
        //}

        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}