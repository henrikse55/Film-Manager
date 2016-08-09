using System;
using Client.Forms;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace Client
{
    public partial class ClientForm : Form
    {
        DataTable table = new DataTable("Test_Table");
        String[] Columns = { "Id", "Name", "Genre", "Description", "Location"};

        public ClientForm()
        {
            InitializeComponent();
            FilmGrid.Columns.Clear(); // fjerner alle columns fra vores datagridview fordi den automatisk adder dem der i Datatablet.

            foreach (String s in Columns)
            {
                table.Columns.Add(s);
            }

            FilmGrid.DataSource = table;

            
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
                Editor edit = new Editor(FilmGrid);
                edit.ShowDialog();
            }
            catch { throw; }
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

        public void AddData(Byte[] xml)
        {
            BinaryWriter writer = new BinaryWriter(File.Open("Data.xml", FileMode.Create));
            writer.Write(xml, 0, xml.Length);
            writer.Flush();
            writer.Close();

            table.TableName = "Temp";
            FileStream stream = new FileStream("Data.xml", FileMode.Open);
            table.ReadXml(stream);

            RefreshGrid();
        }

        private delegate void RefreshGridCallBack();
        public void RefreshGrid()
        {
            if (FilmGrid.InvokeRequired)
            {
                RefreshGridCallBack callback = new RefreshGridCallBack(RefreshGrid);
                FilmGrid.Invoke(callback);
            }else
            {
                Console.WriteLine("Updates");
                FilmGrid.DataSource = null;
                FilmGrid.DataSource = table;
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            FilmGrid.VirtualMode = true;
            Program.Network.Send(Program.CreateNetworkMessage("SendData"));
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Network.shutdown();
        }
    }
}
