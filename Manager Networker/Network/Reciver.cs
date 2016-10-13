using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Manager_Networker.Containers;


namespace Manager_Networker.Network
{
     class Reciver
     {
          private UdpClient ReciverClient = new UdpClient(7777);

          public Task StartListening()
          {
               this.ReciverClient.BeginReceive(Recive,new object());
               return Task.FromResult(0);
          }

          private async void Recive(IAsyncResult ar)
          {
               IPEndPoint end = new IPEndPoint(IPAddress.Any, 7777);
               byte[] bytes = ReciverClient.EndReceive(ar, ref end);
               string[] message = Encoding.ASCII.GetString(bytes).Split('-');
               if (message[0].Equals("Pulse"))
               {
                    Client client = new Client(end.ToString(), end.Port);
                    ManagerService.clientManager.addClientToDictionary(message[0], client);
               }
                    

               await StartListening();
          }
     }
}
