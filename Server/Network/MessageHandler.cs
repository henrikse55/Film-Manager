using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Shared.Network;
using Shared.Enums;
namespace Server.Network
{
    class MessageHandler
    {
        private Dictionary<Message, Socket> queuedMessages = new Dictionary<Message, Socket>();

        public void QueueMessage(Message message, Socket socket)
        {
            if(message != null || socket != null)
            queuedMessages.Add(message, socket);
        }

        public async void init()
        {
            do
            {
                if(queuedMessages.Count > 0)
                await findAndRunCommand();
            } while (true);
        }

        async Task findAndRunCommand()
        {
            var message = getMesage();
            switch (message.Key.Command)
            {
                case MessageIDs.SendMovies:
                    //TODO prepare and send films to client
                    break;
            }

        }

        private void SendMovies(Socket socket)
        {
            //TODO Make it do stuff, ELAIS MAKE THE GOD DAM DATABASE
        }

        KeyValuePair<Message, Socket> getMesage()
        {
            return queuedMessages.First();
        }
    }
}