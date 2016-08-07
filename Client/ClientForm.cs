using System;
using Client.Forms;
using System.Windows.Forms;
using System.Data;

namespace Client
{
    public partial class ClientForm : Form
    {
        DataTable table = new DataTable("Test_Table");
        String[] Columns = { "Id", "Navn", "Genre", "Desciption", "Location"};

        public ClientForm()
        {
            InitializeComponent();
            //this.dataGridView1.Rows.Add("1", "StarWars", "Sci-Fi", "Space", "Stuen");
            //this.dataGridView1.Rows.Add("2", "Narnia", "Fantasy", "noget", "Soveværelse");
            //this.dataGridView1.Rows.Add("3", "Rush Hour", "Action", "ting", "Stuen");
            FilmGrid.Columns.Clear(); // fjerner alle columns fra vores datagridview fordi den automatisk adder dem der i Datatablet.

            foreach (String s in Columns)
            {
                table.Columns.Add(s);
            }

            table.Rows.Add("1", "StarWars", "Sci-Fi", "Space", "Stuen");
            table.Rows.Add("2", "Narnia", "Fantasy", "noget", "Soveværelse");
            table.Rows.Add("3", "Rush Hour", "Action", "ting", "Stuen");
            FilmGrid.DataSource = table;
        }

        //Event til Search funktionen
        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    bool found = false;
            //    foreach (DataGridViewRow row in FilmGrid.Rows)
            //    {
            //        if (row.Cells["Column1"].Value.Equals(SearchBox.Text) || row.Cells["Column2"].Value.Equals(SearchBox.Text) ||
            //            row.Cells["Column3"].Value.Equals(SearchBox.Text) || row.Cells["Column4"].Value.Equals(SearchBox.Text) ||
            //            row.Cells["Column5"].Value.Equals(SearchBox.Text))
            //        {
            //            //Ord fundet
            //            FilmGrid.ClearSelection(); //Afvælger den valgte celle
            //            row.Selected = true; //vælger rowet med den søgte celle
            //            MessageBox.Show(SearchBox.Text + " Found");
            //            found = true;
            //            break;
            //        }
            //    }

            //    //Ord ikke fundet
            //    if (!found)
            //    {
            //        MessageBox.Show(SearchBox.Text + " Not found");
            //    }
            //    SearchBox.Text = ""; 
            //}
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpform_Client help = new Helpform_Client();
            help.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Edit_Client edit = new Edit_Client(FilmGrid.SelectedCells);
                edit.ShowDialog();
                //dataGridView1.SelectedCells[0].Value.ToString()
            }
            catch { }
        }

        //Henter den nye cell value fra Edit_Client Formen
        public void changer(String text)
        {
            FilmGrid.SelectedCells[0].Value = text;
        }

        public DataTable DataTable
        {
            get { return table; }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
        }
    }
}
