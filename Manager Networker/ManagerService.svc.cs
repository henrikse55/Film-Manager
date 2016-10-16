using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Manager_Networker.Containers;
using Manager_Networker.Network;

namespace Manager_Networker
{
     // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
     // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
     public class ManagerService : IManagerService
     {
          EventLog logger = new EventLog();
          
          public static ClientManager clientManager;

          public ManagerService()
          {
               if (!EventLog.SourceExists("Film-Manager"))
               {
                    EventLog.CreateEventSource("FilmManager", "Film-Manager");
               }
               logger.Source = "FilmManager";
               logger.Log = "Film-Manager";

               if (clientManager == null)
                    clientManager = new ClientManager();    
          }

          public void ConnectToClient(Client client)
          {
               
          }

          public Task NetworkScan(String User)
          {
               Broadcaster caster = new Broadcaster();
               caster.Pulse(User);

               return Task.FromResult(0);
          }


          public void SendMessageTo(Client client, string Message)
          {
               
          }

          public void StartListening()
          {
               Thread ReciverThread = new Thread(async (x) =>
               {
                    Reciver reciver = new Reciver();
                    await reciver.StartListening();
               });
               ReciverThread.Start();
          }
     }
}
