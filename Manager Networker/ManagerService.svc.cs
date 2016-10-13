using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using Manager_Networker.Containers;
using Manager_Networker.Network;

namespace Manager_Networker
{
     // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
     // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
     public class ManagerService : IManagerService
     {
          EventLog logger = new EventLog();

          public ManagerService()
          {
               if (!EventLog.SourceExists("Film-Manager"))
               {
                    EventLog.CreateEventSource("FilmManager", "Film-Manager");
               }
               logger.Source = "FilmManager";
               logger.Log = "Film-Manager";

          }

          public void ConnectToClient(Client client)
          {
               throw new NotImplementedException();
          }

          public void NetworkScan()
          {
               Broadcaster caster = new Broadcaster();
               caster.Pulse("null");
          }

          public void SendMessageTo(Client client, string Message)
          {
               
          }
     }
}
