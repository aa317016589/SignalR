using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignaIRServer
{
    public interface IChatClient
    {
        void broadcast(string name, string message);
    }

    public interface IChatHub
    {
        void Send(string name, string message);
    }
}
