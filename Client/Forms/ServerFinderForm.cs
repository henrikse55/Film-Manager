using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Client.Forms
{
    public partial class ServerFinderForm : Form
    {
        public ServerFinderForm()
        {
            InitializeComponent();
        }

        private void ServerFinderForm_Load(object sender, EventArgs e)
        {
            MainLabel.Text = "Sorry, We were unable to connect you to the server \n      please enter the Hostname of the Pc";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ServerIP = Dns.GetHostAddresses(textBox1.Text);
            lock (this)
            {
                String ip = ServerIP[0].AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6 ? ServerIP[0].ToString() : ServerIP[1].ToString();
                Program.Network.connect(ip); 
            }
            Program.Network.Send(Program.CreateNetworkMessage("SendData"));
            Properties.Settings.Default.ServerIP = ServerIP[0].ToString();
            Properties.Settings.Default.Save();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
