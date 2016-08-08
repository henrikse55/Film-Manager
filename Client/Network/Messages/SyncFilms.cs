using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Interfaces;

namespace Client.Network.Messages
{
    class SyncFilms : IMessage
    {
        public string Name
        {
            get{ return "SendData";}
        }

        //XML
        public void Run(string[] args)
        {
            Program.clientform.SyncData(args[0]);
        }
    }
}
