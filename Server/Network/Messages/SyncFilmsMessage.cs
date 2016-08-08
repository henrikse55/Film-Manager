using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Server.Interfaces;
using System.Net.Sockets;

namespace Server.Network.Messages
{
    class SyncFilmsMessage : IMessage
    {
        public string Name
        {
            get{ return "SendData";}
        }

        public void Run(string[] args, Socket socket)
        {
            StringWriter sw = new StringWriter();
            Program.datahandler.DataReader().WriteXml(sw);
            Program.Network.Send(socket,Program.CreateNetworkMessage(Name,sw.ToString()));
        }
    }
}
