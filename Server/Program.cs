using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Server.Network;
using Server.Data;
namespace Server
{
    static class Program
    {
        public static ServerSide Network = new ServerSide();
        public static MessageHandler messageHandler = new MessageHandler();
        public static DataHandler datahandler = new DataHandler();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(new ThreadStart(Network.Init)).Start();

            datahandler.DeleteCommand(1);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
