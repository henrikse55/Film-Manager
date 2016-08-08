using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using Client.Network;
using Shared.Network;
using System.Windows.Forms;

namespace Client.Network
{
    public class ClientSide
    {
        public String Ip = Properties.Settings.Default.ServerIP;
        public int Port = Properties.Settings.Default.ServerPort;
        private Boolean _Quitting = false;
        public Boolean _isLoggedin = false;
        private Socket client;

        private static ManualResetEvent ConnectDone = new ManualResetEvent(false);
        private static ManualResetEvent ReciveDone = new ManualResetEvent(false);
        private static ManualResetEvent SendDone = new ManualResetEvent(false);

        public ClientSide getNetwork
        {
            get { return this; }
        }

        public void Init()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(Ip);
                IPEndPoint endIP = new IPEndPoint(ipAddress, Port);

                client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                int i = 0;
                do
                {
                    ConnectDone.Reset();
                    client.BeginConnect(IPAddress.Parse(Ip), Port, new AsyncCallback(onConnectionCallBack), client);
                    ConnectDone.WaitOne();
                    i++;
                } while (!client.Connected & i < 10);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public Socket socket
        {
            get { return client; }
        }

        private void onConnectionCallBack(IAsyncResult ar)
        {
            try
            {
                ConnectDone.Set();
                Socket socket = (Socket)ar.AsyncState;
                socket.EndConnect(ar);

                Console.WriteLine("Connected to: {0}", socket.RemoteEndPoint.ToString());
                StateObject state = new StateObject(socket);
                socket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(onRecive), state);
            }
            catch
            {
                Console.WriteLine("Failed to connect");
            }
        }
        private void onRecive(IAsyncResult ar)
        {
            try
            {

                StateObject state = (StateObject)ar.AsyncState;

                int BytesRec = state.socket.EndReceive(ar);
                String Message = BytesToString(state.buffer, BytesRec);

                Console.WriteLine("Recived: " + Message);
                String[] temp = Message.Split('-');
                var argsTemp = temp.ToList();
                argsTemp.RemoveAt(0);


                state.socket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, new AsyncCallback(onRecive), state);

                MessageContainer container = new MessageContainer(temp[0], argsTemp.ToArray(), state.socket);
                Program.messageHandler.FindCommand(container);

            }
            catch
            {

            }
            
        }
        public void shutdown()
        {
            _Quitting = true;
            try
            {
                SendDone.WaitOne();
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch
            {

            }
        }

        public void Send(String text)
        {
            byte[] BytesToSend = StringToBytes(text);

            client.BeginSend(BytesToSend, 0,BytesToSend.Length, 0, new AsyncCallback(SendCallBack), client);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                SendDone.Set();
                Socket socket = (Socket) ar.AsyncState;
                int bytes = socket.EndSend(ar);
                Console.WriteLine("Sent: " + bytes);
            }
            catch (Exception e)
            {
                if (_Quitting)
                    return;
                throw e;
            }
        }

        #region Help Methods
        private String BytesToString(byte[] bytes, int bytesRec)
        {
            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }

        private byte[] StringToBytes(String text)
        {
            return Encoding.ASCII.GetBytes(text);
        } 
        #endregion
    }
}
