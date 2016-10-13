using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Manager_Networker.Network
{
     public class Broadcaster
     {
          UdpClient BroadcastClient = new UdpClient();
          IPEndPoint Ip;
          public Broadcaster()
          {
               Ip = new IPEndPoint(IPAddress.Broadcast, 7777);
          }

          public Task Pulse(String User)
          {
               try
               {
                    byte[] BytesToSend = Encoding.ASCII.GetBytes("Pulse-" + User);
                    BroadcastClient.Send(BytesToSend, BytesToSend.Length, Ip);
                    BroadcastClient.Close();
               }
               catch { throw; }
               return Task.FromResult(0);
          }
     }
}