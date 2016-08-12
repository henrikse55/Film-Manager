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
            MainLabel.Text = "Sorry, We were unable to connect you to the server \n      please enter the Hostname of the Pc \n so we can connect next time we start";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(garther);
            ChangeTest();
            this.Close();
        }

        private delegate void changetestCallBack();
        private void ChangeTest()
        {
            if (MainLabel.InvokeRequired)
            {
                changetestCallBack c = new changetestCallBack(ChangeTest);
                MainLabel.Invoke(c);
            }else
            {
                MainLabel.Text = "Please wait... \n This might take a while";
            }
        }

        public Task garther()
        {
            try
            {
                var ServerIP = Dns.GetHostAddresses(textBox1.Text);
                String ip = String.Empty;
                foreach (IPAddress i in ServerIP)
                {
                    if (!i.ToString().Contains("f"))
                    {
                        ip = i.ToString();
                        break;
                    }
                }

                Properties.Settings.Default.ServerIP = ip;
                Properties.Settings.Default.Save();
                //this.Close();
                //Environment.Exit(0);
                return Task.FromResult(0);

            }
            catch (Exception)
            {
                return Task.FromResult(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ServerFinderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Restart();
        }
    }
}
