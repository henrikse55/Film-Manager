using System;
using System.Windows.Forms;
using System.Threading;
namespace Client
{
    static class Program
    {
        public static MessageHandler messageHandler = new MessageHandler();
        public static NetworkHandler Network = new NetworkHandler();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.Sleep(500);
            new Thread(new ThreadStart(messageHandler.init)).Start();
            new Thread(new ThreadStart(Network.Init)).Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientForm());
        }
    }
}
