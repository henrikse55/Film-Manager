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
            this.Close();
        }
    }
}
