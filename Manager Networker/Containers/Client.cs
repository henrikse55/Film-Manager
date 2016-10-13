using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Runtime.Serialization;

namespace Manager_Networker.Containers
{
     [DataContract]
     public class Client
     {
          String IP = String.Empty;
          int __Port = 0;

          public Client(String _IP, int _Port)
          {
               IP = _IP;
               __Port = _Port;
          }

          [DataMember]
          string Ip
          {
               get { return IP; }
               set { IP = value; }
          }

          [DataMember]
          int Port
          {
               get { return __Port; }
               set { __Port = value; }
          }


     }
}