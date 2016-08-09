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
    public partial class Helpform_Client : Form
    {
        public Helpform_Client()
        {
            InitializeComponent();
        }

        private void Okay_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //"How do I use the search function?"
        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dette er en box");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dette er en box");
        }

        //"How do I edit?"
        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dette er en box");
        }
    }
}
