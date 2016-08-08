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
    public partial class Edit_Client : Form
    {
        DataGridViewSelectedCellCollection selected;
        public Edit_Client(DataGridViewSelectedCellCollection _selected)
        {
            InitializeComponent();
            selected = _selected;
        }

        private void Edit_Client_Load(object sender, EventArgs e)
        {
            textBox1.Text = selected[0].Value.ToString(); 
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            Program.clientform.changer(textBox1.Text);
            this.Close();
        }
    }
}