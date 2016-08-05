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
using SharedCode.Network;

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
                ConnectDone.Reset();
                StateObject state = new StateObject(ClientSocket);
                ClientSocket.BeginConnect(IPAddress.Parse(ServerIP), ServerPort ,new AsyncCallback(ConnectionCallBack), state);
                ConnectDone.WaitOne();
            } while (i != 5);
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

        public Object Deserialize(byte[] buffer)
        {
            if (buffer == null)
                throw new NullReferenceException();

            using (MemoryStream stream = new MemoryStream(buffer))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(stream);
            }
        }
    }
}