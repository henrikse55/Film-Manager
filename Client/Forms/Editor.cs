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

        public Editor(DataGridView grid)
        {
            InitializeComponent();
            collection = grid;
        }

        //TODO Lock Row for other users
        private void Editor_Load(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)collection.SelectedRows[0].DataBoundItem).Row;
            FilmTitleTextBox.Text = (String) row["Navn"];
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
                    DataRow row = ((DataRowView)collection.SelectedRows[0].DataBoundItem).Row;
                    collection.SelectedRows[0].SetValues(row["Id"], FilmTitleTextBox.Text, GenreTextBox.Text, DescriptionBox.Text, LocationTextBox.Text);
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
