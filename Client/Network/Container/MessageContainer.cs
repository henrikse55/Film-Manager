using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;

namespace Client.Network
{
    public class MessageContainer
    {
        String command;
        String[] arg;
        Socket socket;

        public MessageContainer(String Message, String[] add, Socket client)
        {
            command = Message;
            arg = add;
            socket = client;
        }

        public String Message
        {
            get { return command; }
        }

        public String[] args
        {
            get { return arg; }
        }

        public Socket Client
        {
            get { return socket; }
        }
    }
}
