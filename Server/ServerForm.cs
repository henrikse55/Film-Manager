using Server.Network;
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

namespace Server
{
    public partial class ServerForm : Form
    {

        public ServerForm()
        {
            InitializeComponent();
            this.Text = Dns.GetHostName();
            label3.Text = Dns.GetHostName();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateMovieCount();
            
        }

        private delegate void UpdateClientCountCallBack();
        public void UpdateClientCount()
        {
            if(label1.InvokeRequired)
            {
                UpdateClientCountCallBack CallBack = new UpdateClientCountCallBack(UpdateClientCount);
                label1.Invoke(CallBack);
            } else
            {
                label1.Text = Program.Network.ClientList.Count().ToString();
            }
        }

        private delegate void UpdateMovieCountCallBack();
        public void UpdateMovieCount()
        {
            if (label2.InvokeRequired)
            {
                UpdateMovieCountCallBack CallBack = new UpdateMovieCountCallBack(UpdateMovieCount);
                label2.Invoke(CallBack);
            }
            else
            {
                label2.Text = Program.datahandler.DataReader().Rows.Count.ToString();
            }
        }
    }
}
