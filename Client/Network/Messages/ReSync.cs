using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Interfaces;
namespace Client.Network.Messages
{
    class ReSyncMessage : IMessage
    {
        public string Name
        {
            get{ return "ReSync";}
        }

        public void Run(string[] args)
        {
            Console.WriteLine("ReSyncing...");
            Program.Network.Send("SendData");
        }
    }
}
