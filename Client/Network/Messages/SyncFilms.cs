using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Client.Interfaces;
using Shared.Network;

namespace Client.Network.Messages
{
    class SyncFilms : IMessage
    {
        public string Name
        {
            get{ return "SendData";}
        }

        public void Run(string[] args)
        {
            int Size = int.Parse(args[0]);
            Byte[] buffer = new byte[Size];
            Program.Network.socket.BeginReceive(buffer,0,buffer.Length, 0, new AsyncCallback(asyncNet), Program.Network.socket);


        }

        private void asyncNet(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int BytesRec = 
        }
    }
}
