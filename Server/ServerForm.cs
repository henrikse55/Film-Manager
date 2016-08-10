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

namespace Server
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
    }
}
