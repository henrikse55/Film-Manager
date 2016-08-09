using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class AddFilm : Form
    {
        public AddFilm()
        {
            InitializeComponent();
        }

        //TODO Lock Row for other users
        private void Editor_Load(object sender, EventArgs e)
        {
            //FilmTitleTextBox.Text = (String) row["Name"];
            //GenreTextBox.Text = (String)row["Genre"];
            //LocationTextBox.Text = (String)row["Location"];
            //DescriptionBox.Text = (String)row["Description"];
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Program.Network.Send(Program.CreateNetworkMessage("addFilm", FilmTitleTextBox.Text, GenreTextBox.Text, DescriptionBox.Text, LocationTextBox.Text));
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
