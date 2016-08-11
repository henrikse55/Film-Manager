using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Server.Interfaces;
namespace Server.Network.Messages
{
    class EditMessage : IMessage
    {
        public string Name
        {
            get
            {
                return "EditFilm";
            }
            
        }

        public void Run(string[] args, Socket socket)
        {
            switch(args[0])
            {
                case "Name":
                    Program.datahandler.UpdateTabel(Data.DataHandler.Columns.Name, args[1], Convert.ToInt32(args[2]));
                    ReSync();
                    break;
                case "Genre":
                    Program.datahandler.UpdateTabel(Data.DataHandler.Columns.Genre, args[1], Convert.ToInt32(args[2]));
                    ReSync();
                    break;
                case "Description":
                    Program.datahandler.UpdateTabel(Data.DataHandler.Columns.Description, args[1], Convert.ToInt32(args[2]));
                    ReSync();
                    break;
                case "Location":
                    Program.datahandler.UpdateTabel(Data.DataHandler.Columns.Location, args[1], Convert.ToInt32(args[2]));
                    ReSync();
                    break;
            }
        }

        private void ReSync()
        {
            Program.Network.ClientList.ForEach(_socket =>
            {
                Program.Network.Send(_socket, "Resync");
            });
        }
    }
}
