using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Interfaces;
using System.Data;
using System.IO;

namespace Server.Network.Messages
{
    class AddFilmMessage : IMessage
    {
        public string Name
        {
            get{ return "addFilm";}
        }

        //Name, Genre, Desc, Location
        public void Run(string[] args, Socket socket)
        {
            Program.datahandler.AddCommand(args[0], args[1], args[2], args[3]);

            DataTable table = Program.datahandler.DataReader();
            StringWriter writer = new StringWriter();
            table.WriteXml(writer);
            byte[] message = Encoding.ASCII.GetBytes(writer.ToString());
            Program.Network.Send(socket, Program.CreateNetworkMessage("SendData", message.Length.ToString()));
            socket.Send(message);
        }
    }
}
