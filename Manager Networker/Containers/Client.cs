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
          int Port = 0;

          public Client(String _IP, int _Port)
          {
               IP = _IP;
               Port = _Port;
          }

          [DataMember]
          string getIpString
          {
               get { return IP; }
               set { IP = value; }
          }

          [DataMember]
          IPAddress getAsIPAddress
          {
               get { return convertToIPAddress(IP); }
          }

          public IPAddress convertToIPAddress(String IP)
          {
               IPAddress _temp = IPAddress.None;
               bool temp = IPAddress.TryParse(IP, out _temp);
               if (temp)
               {
                    return _temp;
               }
               return null;
          }
     }
}