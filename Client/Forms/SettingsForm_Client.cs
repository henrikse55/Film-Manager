using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        //Cancel button
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Okay button
        private void OkayButton_Click(object sender, EventArgs e)
        {
            var Option = MessageBox.Show("Would you like to save your changed settings?", "Save Setting?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (Option)
            {
                case DialogResult.Yes:
                    Properties.Settings.Default.ServerIP = ServerIP.Text;
                    Properties.Settings.Default.ServerPort = int.Parse(ServerPort.Text);
                    Properties.Settings.Default.Save();
                    Application.Restart();
                    break;

                case DialogResult.No:
                    this.Close();
                    break;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            ServerIP.Text = Properties.Settings.Default.ServerIP;
            ServerPort.Text = Properties.Settings.Default.ServerPort.ToString();
        }
    }
}
