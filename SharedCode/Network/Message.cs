using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SharedCode.Interfaces;
namespace SharedCode.Network
{
    class Message : IMessage
    {
        int i = 0;
        public int Command
        {
            get{throw new NotImplementedException();}
        }

        public string[] args
        {
            get{ throw new NotImplementedException();}
        }

        public int test
        {
            get { return i; }
            set { i = value; }
        }
    }
}
