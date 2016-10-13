using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Manager_Networker.Containers;

namespace Manager_Networker
{
     // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
     [ServiceContract]
     public interface IManagerService
     {
          [OperationContract]
          void NetworkScan();

          [OperationContract]
          void ConnectToClient(Client client);

          [OperationContract]
          void SendMessageTo(Client client, String Message);
     }
}
