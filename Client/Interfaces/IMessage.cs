using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;

namespace Client.Interfaces
{
    public interface IMessage
    {
        String Name { get; }

        void Run(String[] args);
    }
}
