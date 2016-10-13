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

          public Client FindUserByName(String User)
          {
               return (Client) Clients.Where(x => x.Key.Equals(User)).Select(x => x.Value).DefaultIfEmpty(null);
          }

          public bool RemoveByName(String user)
          {
               return Clients.Remove(user);
          }

          public bool RemoveByClient(Client cli)
          {
               String temp = Clients.Where(x => x.Value == cli).Select(x => x.Key).ToString();
               return Clients.Remove(temp);
          }
     }
}
