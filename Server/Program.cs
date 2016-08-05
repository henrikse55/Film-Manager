using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Server.Network;
namespace Server
{
    static class Program
    {
        public static NetworkHandler Network = new NetworkHandler();
        public static MessageHandler messageHandler = new MessageHandler();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(new ThreadStart(Network.Init)).Start();
            new Thread(new ThreadStart(messageHandler.init)).Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
