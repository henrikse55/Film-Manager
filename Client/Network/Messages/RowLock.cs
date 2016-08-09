using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Interfaces;

namespace Client.Network.Messages
{
    class RowLock : IMessage
    {
        //ID

        public string Name
        {
            get{ return "LockRow";}
        }

        public void Run(string[] args)
        {
            //Might Not be needed
        }
    }
}
