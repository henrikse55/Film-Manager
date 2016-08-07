using System;
using System.Windows.Forms;
using System.Threading;
using Client.Network;
using Client.Handler;
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
            //Temporary Disabled Network comunication to be able to work on the client solo
            //new Thread(new ThreadStart(Network.Init)).Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(clientform = new ClientForm());
        }
    }
}
