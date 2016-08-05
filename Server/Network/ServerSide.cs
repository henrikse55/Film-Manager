using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using Shared.Network;

namespace Server.Network
{
    public class ServerSide : IDisposable
    {
        private List<Socket> Clients = new List<Socket>();
        private int Port = 7777;
        private Socket server;

        private ManualResetEvent AllDone = new ManualResetEvent(false);

        public void Init()
        {
            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, Port);

            try
            {
                server = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(remoteEP);
                server.Listen(4);

                while (true)
                {
                    AllDone.Reset();
                    server.BeginAccept(new AsyncCallback(AcceptCallBack), server);
                    AllDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Init: " + e.Message);
            }
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            AllDone.Set();
            Socket Listner = (Socket)ar.AsyncState;
            Socket client = Listner.EndAccept(ar);

            Clients.Add(client);

            StateObject state = new StateObject(client);

            client.BeginReceive(state.buffer, 0, state.buffer.Length,0 , new AsyncCallback(onDataRecived), state);
        }

        public Socket getSocketByIP(String IP)
        {
            return (from socket in Clients where socket.RemoteEndPoint.ToString().Equals(IP) select socket).SingleOrDefault(null);
        }

        public List<Socket> ClientList
        {
            get { return Clients; }
        }

        public void keepAlive()
        {
            Clients.ForEach(x => Send(x, "HeartBeat".ToUpper()));
        }

        private void onDataRecived(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState;

                int bytesRec = state.socket.EndReceive(ar);
                String Message = Encoding.ASCII.GetString(state.buffer, 0, bytesRec);
                if (Message.Contains("Shutdown"))
                {
                    Clients.Remove(state.socket);
                    state.socket.Shutdown(SocketShutdown.Both);
                    state.socket.Close();
                }
                else
                {
                    String temp = Message.Split('-')[0];
                    var args = Message.Split('-').ToList();
                    args.RemoveAt(0);

                    MessageContainer container = new MessageContainer(temp, args.ToArray(), state.socket);

                    Program.messageHandler.FindCommand(container);

                    //if(!temp.Equals("SendFile"))
                    state.socket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(onDataRecived), state);
                }
                Console.WriteLine(Message);
            }
            catch
            {
                StateObject state = (StateObject)ar.AsyncState;
                Clients.Remove(state.socket);
            }
        }

        public void Send(Socket client, String data)
        {
            Byte[] BytesToSend = Encoding.ASCII.GetBytes(data);

            client.BeginSend(BytesToSend,0,BytesToSend.Length,0, new AsyncCallback(SendCallBack), client);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                int SendBytes = client.EndSend(ar);
                Console.WriteLine("Sendt: " + SendBytes);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Sending: " + e.Message);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    AllDone.Close();
                    server.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ServerSide() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
