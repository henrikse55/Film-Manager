using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Shared.Network
{
    class StateObject
    {
        /// <summary>
        /// Creates a stateObject for comunication with the server
        /// </summary>
        /// <param name="socket">The Client Socket</param>
        public StateObject(Socket socket)
        {
            this.socket = socket;
        }

        public const int bufferSize = 1024;

        public byte[] buffer = new byte[bufferSize];

        public Socket socket;

    }
}
