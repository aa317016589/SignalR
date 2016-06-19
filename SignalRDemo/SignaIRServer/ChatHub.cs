using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignaIRServer
{
    public class ChatHub : Hub<IChatClient>
    {
        public void Send(string name, string message)
        {
            Console.WriteLine("ConnectionId:{0}, InvokeMethod:{1}", Context.ConnectionId, "Send");
            Clients.AllExcept(Context.ConnectionId).broadcast(name, message);
        }
    }
}
