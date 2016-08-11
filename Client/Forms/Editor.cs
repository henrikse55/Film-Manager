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
    public partial class Editor : Form
    {
        DataGridView collection;
        DataRow row;
        public Editor(DataGridView grid)
        {
            InitializeComponent();
            collection = grid;
        }

        //TODO Lock Row for other users
        private void Editor_Load(object sender, EventArgs e)
        {
            
            row = ((DataRowView)collection.SelectedRows[0].DataBoundItem).Row;
            FilmTitleTextBox.Text = (String) row["Name"];
            GenreTextBox.Text = (String)row["Genre"];
            LocationTextBox.Text = (String)row["Location"];
            DescriptionBox.Text = (String)row["Description"];
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var option = MessageBox.Show("Sure you wonna save these changes?", "Are You Sure", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            switch (option)
            {
                case DialogResult.Yes:
                    //DataRow row = ((DataRowView)collection.SelectedRows[0].DataBoundItem).Row;
                    //collection.SelectedRows[0].SetValues(row["Id"], FilmTitleTextBox.Text, GenreTextBox.Text, DescriptionBox.Text, LocationTextBox.Text);

                    if(!FilmTitleTextBox.Text.Equals(row["Name"]))
                        Program.Network.Send(Program.CreateNetworkMessage("EditFilm", "Name", FilmTitleTextBox.Text, (String)collection.SelectedRows[0].Cells[0].Value));

                    if (!GenreTextBox.Text.Equals(row["Genre"]))
                        Program.Network.Send(Program.CreateNetworkMessage("EditFilm", "Genre", GenreTextBox.Text, (String)collection.SelectedRows[0].Cells[0].Value));

                    if (!DescriptionBox.Text.Equals(row["Description"]))
                        Program.Network.Send(Program.CreateNetworkMessage("EditFilm", "Description", DescriptionBox.Text, (String)collection.SelectedRows[0].Cells[0].Value));

                    if (!LocationTextBox.Text.Equals(row["Location"]))
                        Program.Network.Send(Program.CreateNetworkMessage("EditFilm", "Location", LocationTextBox.Text, (String)collection.SelectedRows[0].Cells[0].Value));

                    this.Close();
                    break;
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
