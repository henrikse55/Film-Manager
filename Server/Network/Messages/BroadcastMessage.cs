using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Server.Interfaces;

namespace Server.Network.Messages
{
    class BroadcastMessage : IMessage
    {
        public string Name
        {
            get { return "broadcast";}
        }

        public Task<AsyncMessageResult> Run(string[] args, Socket socket)
        {
            List<String> list = new List<string>();
            list.AddRange(args);
            list.RemoveAt(0);
            Program.Network.ClientList.ForEach(_Socket => 
            {
                if(_Socket != socket)
                Program.Network.Send(_Socket, Program.CreateNetworkMessage(args[0], list.ToArray()));
            });

            return Task.FromResult(AsyncMessageResult.Succeful);
        }
    }
}
