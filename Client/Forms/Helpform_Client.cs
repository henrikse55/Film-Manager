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
            MessageBox.Show("How do I use the search function? \n\nTo start the search function, click the search button in the menu bar. To search for a movie you must create a filter first. To create a filter, first off name it in the 'Filter name' box. You can now choose if you want an inclusive or an exclusive search. Now you have to choose which column you want to search from. After that you simply write you search in the 'Text to Compare' box, Save Filter and then press the 'Search' button.", "Help Box", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        //How do I remove?
        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How do I remove? \n\nTo remove a row, you simply choose a row and then press the 'Films' button in the menu bar. Then you press the 'Remove' button.", "Help Box", MessageBoxButtons.OK ,MessageBoxIcon.Question);
        }

        //"How do I edit?"
        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How do I edit? \n\nTo open the editor, double click on the row you wish to edit." , "Help Box", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
