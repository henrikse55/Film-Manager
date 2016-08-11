using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Client.Other;
using static System.Windows.Forms.ListBox;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client.Forms
{
    public partial class Search : Form
    {
        private List<Filter> filters = new List<Filter>();
        //private Dictionary<Filter, Brush> _filters = new Dictionary<Filter, Brush>();
        private DataTable FilmsInList = new DataTable("FilmsFound");
        private bool _EditFilter = false;

        public Search()
        {
            InitializeComponent();
            IncludeCheckBox.Checked = true;
            CaseSensetiveCheckBox.Checked = true;

            if (!Directory.Exists(@"Filters\"))
                Directory.CreateDirectory(@"Filters\");
        }

        private void IncludeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ExcludeCheckBox.Checked = !IncludeCheckBox.Checked;
        }

        private void ExcludeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IncludeCheckBox.Checked = !ExcludeCheckBox.Checked;
        }

        private void FilterNameTextBox_TextChanged(object sender, EventArgs e)
        {
            enableSaveButton();
        }

        public void enableSaveButton()
        {
           if (!String.IsNullOrWhiteSpace(FilterNameTextBox.Text) && ColumnBox.SelectedItem != null)
                SaveFilter.Enabled = true;
        }

        private void SaveFilter_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (Filter filter in filters)
            {
                if (filter.Name.Equals(FilterNameTextBox.Text))
                    flag = true;
            }

            if (flag == false)
            {
                CreateFilter();
            }
            else
            {
                if (!_EditFilter)
                {
                    var Opinon = MessageBox.Show("There is already a filter with that name \n would you like to replace it?", "Dublicate Found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    switch (Opinon)
                    {
                        case DialogResult.Yes:
                            CreateFilter();
                            break;
                    }
                }
                else
                {
                    CreateFilter();
                    _EditFilter = false;
                }
            }
        }

        public void CreateFilter()
        {
            for (int x = 0; x < filters.Count; x++)
            {
                Filter f = filters.ToArray()[x];
                for (int i = 0; i < FilterList.SelectedItems.Count; i++)
                {
                    String Name = FilterList.SelectedItems[i].ToString();
                    if (f.Name.Equals(Name))
                    {
                        filters.Remove(f);
                        FilterList.Items.Remove(FilterList.SelectedItems[i]);
                    }
                }
            }

            Filter filter = new Filter();
            filter.Name = FilterNameTextBox.Text;
            filter.filterOption = (IncludeCheckBox.Checked == true ? filterOption.Include : filterOption.Exclude);
            filter.isCaseSenestive = CaseSensetiveCheckBox.Checked;
            filter.ToApply = ColumnBox.SelectedItem.ToString();
            filter.Text = TextToCompare.Text;
            filters.Add(filter);
            FilterList.Items.Add(filter.Name);
            ResetFields();

            try
            {
                String FilterDir = @".\Filters\" + filter.Name;
                using (Stream stream = new FileStream(FilterDir, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None))
                {
                    BinaryFormatter formater = new BinaryFormatter();
                    formater.Serialize(stream, filter);
                    stream.Close();
                }
            }
            catch
            {
                
            }

        }

        private void ResetFields()
        {
            FilterNameTextBox.Text = "";
            IncludeCheckBox.Checked = true;
            ExcludeCheckBox.Checked = false;
            CaseSensetiveCheckBox.Checked = true;
            TextToCompare.Text = "";
            ColumnBox.SelectedIndex = 0;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            DataColumn[] columns = new DataColumn[Program.clientform.DataTable.Columns.Count];
            Program.clientform.DataTable.Columns.CopyTo(columns, 0);
            columns.ToList().ForEach(x => { ColumnBox.Items.Add(x.ColumnName); FilmsInList.Columns.Add(x.ColumnName); });
            FilmsFound.DataSource = FilmsInList;

            String FiltersDir = @".\Filters\";
            var files = Directory.GetFiles(FiltersDir);
            files.ToList().ForEach((Action<string>)(file => {
                using (Stream stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Filter Filter = (Filter)formatter.Deserialize(stream);
                    filters.Add(Filter);
                    this.FilterList.Items.Add(Filter.Name);
                }
            }));
            
        }

        private void FilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;
            EditFilter.Enabled = list.SelectedItems.Count == 1 ? true : false;
            RemoveFilter.Enabled = list.SelectedItems.Count > 0 ? true : false; 

        }

        private void updateFilms()
        {
            FilmsInList.Clear();
            DataTable films = Program.clientform.DataTable;
            films.AsEnumerable().ToList().ForEach(film =>
            {
                filters.ToList().ForEach(filter =>
                {
                    if(!filter.isDisabled)
                    switch (filter.filterOption)
                    {
                        case filterOption.Include:
                            if (filter.isCaseSenestive)
                            {
                                if (film.Field<String>(filter.ToApply).Contains(filter.Text))
                                {
                                    addToDataTable(film);
                                }
                            }
                            else
                            {
                                if (film.Field<String>(filter.ToApply).ToLower().Contains(filter.Text.ToLower()))
                                {
                                    addToDataTable(film);
                                }
                            }
                            break;

                        case filterOption.Exclude:
                            if (filter.isCaseSenestive)
                            {
                                if (!film.Field<String>(filter.ToApply).Contains(filter.Text))
                                {
                                    addToDataTable(film);
                                }
                            }
                            else
                            {
                                if (!film.Field<String>(filter.ToApply).ToLower().Contains(filter.Text.ToLower()))
                                {
                                    addToDataTable(film);
                                }
                            }
                            break;
                    }
                });
            });
        }

        private void addToDataTable(DataRow row)
        {
            DataRow rows = (from _row in FilmsInList.AsEnumerable() where _row.Field<String>("Id").Equals(row[0]) select _row).SingleOrDefault();
            if (rows == null)
                FilmsInList.ImportRow(row);

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            updateFilms();
        }

        private void RemoveFilter_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < filters.Count; x++)
            {
                Filter filter = filters.ToArray()[x];
                for (int i = 0; i < FilterList.SelectedItems.Count; i++)
                {
                    String Name = FilterList.SelectedItems[i].ToString();
                    if (filter.Name.Equals(Name))
                    {
                        filters.Remove(filter);
                        FilterList.Items.Remove(FilterList.SelectedItems[i]);
                        String dir = @".\Filters\" + Name;
                        File.Delete(dir);
                    }
                }
            }

            updateFilms();
        }

        private void EditFilter_Click(object sender, EventArgs e)
        {
            foreach (Filter filter in filters)
            {
                if (filter.Name.Equals(FilterList.SelectedItems[0]))
                {
                    FilterNameTextBox.Text = filter.Name;
                    IncludeCheckBox.Checked = filter.filterOption == filterOption.Include ? true : false;
                    ExcludeCheckBox.Checked = filter.filterOption == filterOption.Exclude ? true : false;
                    CaseSensetiveCheckBox.Checked = filter.isCaseSenestive;
                    ColumnBox.SelectedValue = filter.ToApply;
                    TextToCompare.Text = filter.Text;
                    _EditFilter = true;
                }
            }
        }

        private void ColumnBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableSaveButton();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FilmsFound_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Editor edit = new Editor(FilmsFound);
            edit.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filters.ToList().ForEach(filter =>
            {
                if (this.FilterList.SelectedItems.Count == 1)
                    if (filter.Name.Equals(FilterList.SelectedItems[0]))
                    {
                        filter.isDisabled = !filter.isDisabled;
                        FilterList.Invalidate();
                    }
            });
        }

        private void FilterList_DrawItem(object sender, DrawItemEventArgs e)
        {
            FilterList.ClearSelected();

            e.DrawBackground();
            var filter = filters[e.Index];
            Brush brush = !filter.isDisabled ? Brushes.DarkGreen : Brushes.Red;

            e.Graphics.DrawString(filter.Name, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }
    }
}
