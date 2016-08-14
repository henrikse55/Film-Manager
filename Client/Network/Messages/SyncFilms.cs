using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Client.Interfaces;
using Shared.Network;
using System.IO;

namespace Client.Network.Messages
{
    class SyncFilms : IMessage
    {
        Byte[] buffer;
        public string Name
        {
            get{ return "SendData";}
        }

        public void Run(string[] args)
        {
            try
            {
                int Size = int.Parse(args[0]);
                buffer = new byte[Size];
                Program.Network.socket.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(asyncNet), Program.Network.socket);

            }
            catch
            {
                Console.WriteLine("something went horrobly wrong, attempting to reSync");
                Program.Network.Send("SendData");
            }
        }

        private void asyncNet(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int bytesRec = socket.EndReceive(ar);
            if (bytesRec == buffer.Length)
            {
                Console.WriteLine("Everything recived!");
                Program.clientform.AddData(buffer);
            }else
            {
            Program.Network.socket.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(asyncNet), Program.Network.socket);
            }

        }
    }
}
