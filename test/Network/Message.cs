using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces;
using Shared.Enums;
namespace Shared.Network
{
    [Serializable]
    class Message
    {
        MessageIDs MessageID;
        String[] arg;
        public Message(MessageIDs ID, String[] args)
        {
            MessageID = ID;
            arg = args;
        }

        public MessageIDs Command
        {
            get{ return MessageID;}
        }

        public string[] args
        {
            get{ return arg;}
        }
    }
}
