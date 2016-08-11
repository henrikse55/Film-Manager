using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Server.Interfaces;
using System.Net.Sockets;
using System.Data;
using System.Threading;
namespace Server.Network.Messages
{
    class SyncFilmsMessage : IMessage
    {
        public string Name
        {
            get{ return "SendData";}
        }

        public async Task<AsyncMessageResult> Run(string[] args, Socket socket)
        {
            try
            {
                DataTable table = await Program.datahandler.DataReader();
                StringWriter writer = new StringWriter();
                table.WriteXml(writer);
                byte[] message = Encoding.ASCII.GetBytes(writer.ToString());
                Program.Network.Send(socket, Program.CreateNetworkMessage("SendData", message.Length.ToString()));
                Program.Network.Send(socket, writer.ToString());
                return AsyncMessageResult.Succeful;
            }
            catch
            {
                return AsyncMessageResult.Error;
            }
        }
    }
}
