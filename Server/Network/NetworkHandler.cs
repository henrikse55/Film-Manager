using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using Shared.Network;

namespace Server.Network
{
    class NetworkHandler
    {
        #region Private Members
        private List<Socket> Clients = new List<Socket>();
        private Socket ServerSocket;

        private int Port = 7777;

        private ManualResetEvent allDone = new ManualResetEvent(false);
        #endregion

        public void Init()
        {
            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, Port);

            try
            {
                ServerSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                ServerSocket.Bind(remoteEP);
                ServerSocket.Listen(4);

                while (true)
                {
                    allDone.Reset();
                    ServerSocket.BeginAccept(new AsyncCallback(AcceptCallBack), ServerSocket);
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Init: " + e.Message);
            }
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            allDone.Set();
            Socket Listner = (Socket)ar.AsyncState;
            Socket client = Listner.EndAccept(ar);

            Clients.Add(client);

            StateObject state = new StateObject(client);

            client.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(ReciveCallBack), state);
        }

        private void ReciveCallBack(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            int BytesRec = state.Socket.EndReceive(ar);
            Message message = Serilizer.Deserialize(state.buffer);

            state.Socket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(ReciveCallBack), state);
        }

        
    }
}
