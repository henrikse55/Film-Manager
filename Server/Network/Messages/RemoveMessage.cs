using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Interfaces;

namespace Server.Network.Messages
{
    class RemoveMessage : IMessage
    {
        public string Name
        {
            get{ return "RemoveFilm";}
        }

        public async Task<AsyncMessageResult> Run(string[] args, Socket socket)
        {
            await Program.datahandler.DeleteCommand(int.Parse(args[0]));

            Program.Network.ClientList.ForEach(_Socket => 
            {
                Program.Network.Send(_Socket,"ReSync");
            });

            return AsyncMessageResult.Succeful;
        }
    }
}
