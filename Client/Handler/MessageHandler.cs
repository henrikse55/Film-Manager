using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Client.Interfaces;
using Client.Network;
using System.Threading.Tasks;

namespace Client.Handler
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
            //foreach (IMessage command in Messages)
            //{
            //    if (command.Name.ToUpper().Equals(network.Message.ToUpper()))
            //    {
            //        Console.WriteLine("Found Message");
            //        command.Run(network.args);
            //    }
            //}

            IMessage _command = (from _com in Messages where _com.Name.ToUpper().Equals(network.Message.ToUpper()) select _com).SingleOrDefault();

            if(_command != null)
            _command.Run(network.args);

        }
    }
}
