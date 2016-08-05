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
            IPAddress ipAddress = IPAddress.Parse(ServerIP);
            IPEndPoint endPoint = new IPEndPoint(ipAddress, ServerPort);

            ClientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            int i = 0;
            do
            {
                try
                {
                    ConnectDone.Reset();
                    StateObject state = new StateObject(ClientSocket);
                    ClientSocket.BeginConnect(IPAddress.Parse(ServerIP), ServerPort, new AsyncCallback(ConnectionCallBack), state);
                    ConnectDone.WaitOne();
                }
                catch
                {
                }
            } while (i != 5);

            if (i == 5)
            {
                MessageBox.Show("Failed to connect to the server", "Network error");
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
                state.ClientSocket.EndConnect(ar);

                Console.WriteLine("Connceted To {0}", state.ClientSocket.RemoteEndPoint);
                state.ClientSocket.BeginReceive(state.buffer, 0, state.buffer.Length, 0 , new AsyncCallback(ReciveCallBack), state);
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

            int bytesRec = state.ClientSocket.EndReceive(ar);
            Shared.Network.Message message = Deserialize(state.buffer);

            state.ClientSocket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(ReciveCallBack), state);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int i = socket.EndSend(ar);
        }

        public void Send(Shared.Network.Message message)
        {
            Byte[] bytesToSend = Serialize(message);
            ClientSocket.BeginSend(bytesToSend, 0, bytesToSend.Length, 0, new AsyncCallback(SendCallBack), ClientSocket);
        }

        public byte[] Serialize(Object o)
        {
            if (o == null)
                throw new NullReferenceException();
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                bf.Serialize(stream, o);
                return stream.ToArray();
            }
        }

        public Shared.Network.Message Deserialize(byte[] buffer)
        {
            if (buffer == null)
                throw new NullReferenceException();

            using (MemoryStream stream = new MemoryStream(buffer))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (Shared.Network.Message) bf.Deserialize(stream);
            }
        }
    }
}