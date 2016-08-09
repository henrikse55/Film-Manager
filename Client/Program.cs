using System;
using System.Windows.Forms;
using System.Threading;
using Client.Network;
using Client.Handler;
using System.Text;
using System.Collections.Generic;
using Client.Network.Messages;

namespace Client
{
    static class Program
    {
        public static ClientForm clientform;
        public static MessageHandler messageHandler = new MessageHandler();
        public static ClientSide Network = new ClientSide();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.Sleep(500);
            clientform = new ClientForm();
            new Thread(new ThreadStart(Network.Init)).Start();
            
            messageHandler.addMessage(new SyncFilms());
            messageHandler.addMessage(new ReSyncMessage());

            Application.EnableVisualStyles();
            Application.Run(clientform);
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
