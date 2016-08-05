using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Shared.Network;
using System.Windows.Forms;

namespace Client.Network
{
    class NetworkHandler
    {
        #region Member Parameters
        public String ServerIP = Properties.Settings.Default.ServerIP;
        public int ServerPort = Properties.Settings.Default.ServerPort;

        private ManualResetEvent ConnectDone = new ManualResetEvent(false);
        private ManualResetEvent ReciveEvent = new ManualResetEvent(false);
        private ManualResetEvent SendEvent = new ManualResetEvent(false);

        private Socket ClientSocket; 
        #endregion

        public NetworkHandler()
        {
            
        }

        /// <summary>
        /// Creates the client socket and attempts to connect to a server
        /// </summary>
        public void Init()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ServerIP);
                IPEndPoint endIP = new IPEndPoint(ipAddress, ServerPort);

                ClientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                int i = 0;
                do
                {
                    ConnectDone.Reset();
                    StateObject state = new StateObject(ClientSocket);
                    ClientSocket.BeginConnect(IPAddress.Parse(ServerIP), ServerPort, new AsyncCallback(ConnectionCallBack), state);
                    ConnectDone.WaitOne();
                    i++;
                } while (!ClientSocket.Connected & i < 10);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Async Call for ending a beginConnect
        /// </summary>
        /// <param name="ar"></param>
        private void ConnectionCallBack(IAsyncResult ar)
        {
            try
            {
                ConnectDone.Set();
                StateObject state = (StateObject)ar.AsyncState;
                state.Socket.EndConnect(ar);

                Console.WriteLine("Connceted To {0}", state.Socket.RemoteEndPoint);
                state.Socket.BeginReceive(state.buffer, 0, state.buffer.Length, 0 , new AsyncCallback(ReciveCallBack), state);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Recives information from the server
        /// </summary>
        /// <param name="ar"></param>
        private void ReciveCallBack(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;

            int bytesRec = state.Socket.EndReceive(ar);
            Shared.Network.Message message = Serilizer.Deserialize(state.buffer);
            Program.messageHandler.QueueMessage(message);

            state.Socket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(ReciveCallBack), state);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int i = socket.EndSend(ar);
        }

        public void Send(Shared.Network.Message message)
        {
            Byte[] bytesToSend = Serilizer.Serialize(message);
            ClientSocket.BeginSend(bytesToSend, 0, bytesToSend.Length, 0, new AsyncCallback(SendCallBack), ClientSocket);
        }
    }
}