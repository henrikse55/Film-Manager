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
            search.ShowDialog();
        }

        public void AddData(Byte[] xml)
        {
            NullGrid();
            table.Clear();
            BinaryWriter writer = new BinaryWriter(File.Open("Data.xml", FileMode.Create));
            writer.Write(xml, 0, xml.Length);
            writer.Flush();
            writer.Close();

            table.TableName = "Temp";
            FileStream stream = new FileStream("Data.xml", FileMode.Open);
            table.ReadXml(stream);
            stream.Flush();
            stream.Close();
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
                
                FilmGrid.DataSource = table;
            }
        }

        public void NullGrid()
        {
            if (FilmGrid.InvokeRequired)
            {
                RefreshGridCallBack callback = new RefreshGridCallBack(NullGrid);
                FilmGrid.Invoke(callback);
            }
            else
            {

                FilmGrid.DataSource = null;
            }
        }

        private delegate void SetValueCallBack(object o);
        public void SetProgressMax(object o)
        {
            if (Progress.InvokeRequired)
            {
                SetValueCallBack callBack = new SetValueCallBack(SetProgressMax);
                Progress.Invoke(callBack, o);
            }else
            {
                Console.WriteLine("Updateting");
                Progress.Maximum = (int)o;
            }
        }

        public void SetProgressValue(object o)
        {
            if (Progress.InvokeRequired)
            {
                SetValueCallBack callBack = new SetValueCallBack(SetProgressValue);
                Progress.Invoke(callBack, o);
            }
            else
            {
                Progress.Value = (int)o;
            }
        }

        public void IncrementProgress(object o)
        {
            if (Progress.InvokeRequired)
            {
                SetValueCallBack callBack = new SetValueCallBack(IncrementProgress);
                Progress.Invoke(callBack, o);
            }
            else
            {
                Progress.Increment((int)o);
            }
        }

        public void HideProgress(object o)
        {
            if (Progress.InvokeRequired)
            {
                SetValueCallBack callBack = new SetValueCallBack(HideProgress);
                Progress.Invoke(callBack, o);
            }
            else
            {
                Progress.Visible= (bool)o;
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Program.Network.Send(Program.CreateNetworkMessage("SendData"));
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Network.shutdown();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFilm film = new AddFilm();
            film.ShowDialog();
        }
    }
}
