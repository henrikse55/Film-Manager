using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Server.Network;
using Server.Data;
using System.Text;
using Server.Network.Messages;
using Server.Timers;
namespace Server
{
    static class Program
    {
        public static ServerSide Network = new ServerSide();
        public static MessageHandler messageHandler = new MessageHandler();
        public static DataHandler datahandler = new DataHandler();
        public static KeepNetworkAlive keepAliveTimer = new KeepNetworkAlive();
        public static Form1 ServerForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(new ThreadStart(Network.Init)).Start();
            new Thread(new ThreadStart(keepAliveTimer.Start)).Start();

            messageHandler.addMessage(new SyncFilmsMessage());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(ServerForm = new Form1());
        }


        /// <summary>
        /// a simple methods for createing a network message to the server
        /// </summary>
        /// <param name="Command">What command is it you are sending</param>
        /// <param name="args">exstra information the server might need</param>
        public static string CreateNetworkMessage(String Command, params String[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Command);
            List<String> list = new List<string>();
            list.AddRange(args);
            list.ForEach(x => sb.Append("-" + x));
            return sb.ToString();
        }
    }
}
