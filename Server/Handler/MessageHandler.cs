using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Server.Interfaces;

namespace Server.Network
{
    public class MessageHandler
    {
        List<IMessage> Messages = new List<IMessage>();

        public void addMessage(IMessage Message)
        {
            Messages.Add(Message);
        }

        public void addMessage(IMessage[] Message)
        {
            Messages.AddRange(Message);
        }

        public void FindCommand(MessageContainer network)
        {
            foreach (IMessage command in Messages)
            {
                if (command.Name.ToUpper().Equals(network.Message.ToUpper()))
                {
                    Console.WriteLine("Found Message");
                    command.Run(network.args, network.Client);
                }
            }
        }
    }
}
