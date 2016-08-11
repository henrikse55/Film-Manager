using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface IMessage
    {
        String Name { get; }

        Task<AsyncMessageResult> Run(String[] args, Socket socket);
    }
}