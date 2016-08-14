using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Server.Interfaces;
using System.Threading.Tasks;

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

        public async Task FindCommand(MessageContainer network)
        {
            //foreach (IMessage command in Messages)
            //{
            //    if (command.Name.ToUpper().Equals(network.Message.ToUpper()))
            //    {
            //        command.Run(network.args, network.Client);
            //    }
            //}

            IMessage _command = (from _com in Messages where _com.Name.ToUpper().Equals(network.Message.ToUpper()) select _com).SingleOrDefault();

            if (_command != null)
                await _command.Run(network.args, network.Client);
        }
    }
}
