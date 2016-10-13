using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Manager_Networker.Containers;
using System.Runtime.Serialization;

namespace Manager_Networker.Network
{
     [DataContract]
     public class ClientManager
     {

          [DataMember]
          Dictionary<String, Client> Clients = new Dictionary<string, Client>();

          public void addClientToDictionary(String User, Client client)
          {
               if (User != null && client != null)
                    Clients.Add(User, client);
          }

          public Task addClientToDictionaryAsync()
          {

               return Task.FromResult(0);
          }
     }
}
