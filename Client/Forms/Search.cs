using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Client.Other;
using static System.Windows.Forms.ListBox;

namespace Client.Forms
{
    public partial class Search : Form
    {
        private List<Filter> filters = new List<Filter>();
        private DataTable FilmsInList = new DataTable("FilmsFound");
        private bool _EditFilter = false;

        public Search()
        {
            InitializeComponent();
            IncludeCheckBox.Checked = true;
            CaseSensetiveCheckBox.Checked = true;
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
                Filter filter = new Filter();
                filter.Name = FilterNameTextBox.Text;
                filter.filterOption = (IncludeCheckBox.Checked == true ? filterOption.Include : filterOption.Exclude);
                filter.isCaseSenestive = CaseSensetiveCheckBox.Checked;
                filter.ToApply = ColumnBox.SelectedItem.ToString();
                filter.Text = TextToCompare.Text;
                filters.Add(filter);
                FilterList.Items.Add(filter.Name);
                ResetFields();
            }
            else
            {
                if (!_EditFilter)
                {
                    var Opinon = MessageBox.Show("There is already a filter with that name \n would you like to replace it?", "Dublicate Found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    switch (Opinon)
                    {
                        case DialogResult.Yes:
                            for (int x = 0; x < filters.Count; x++)
                            {
                                Filter f = filters[x];
                                for (int i = 0; i < FilterList.SelectedItems.Count; i++)
                                {
                                    String Name = FilterList.SelectedItems[i].ToString();
                                    if (f.Name.Equals(Name))
                                    {
                                        filters.Remove(f);
                                        FilterList.Items.Remove(Name);
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
                            break;
                    }
                }
                else
                {
                    for (int x = 0; x < filters.Count; x++)
                    {
                        Filter f = filters[x];
                        for (int i = 0; i < FilterList.SelectedItems.Count; i++)
                        {
                            String Name = FilterList.SelectedItems[i].ToString();
                            if (f.Name.Equals(Name))
                            {
                                filters.Remove(f);
                                FilterList.Items.Remove(Name);
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
                    _EditFilter = false;
                }
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
            //CheckProgress.Maximum = films.Rows.Count;
            filters.ForEach(filter => {
                //CheckProgress.Value = 0;
                films.AsEnumerable().ToList().ForEach(film => {
                    //CheckProgress.Increment(1);
                    switch (filter.filterOption)
                    {
                        case filterOption.Include:
                            if (filter.isCaseSenestive){
                                if (film.Field<String>(filter.ToApply).Contains(filter.Text))
                                {
                                    FilmsInList.ImportRow(film);
                                }
                            }
                            else
                            {
                                if (film.Field<String>(filter.ToApply).ToLower().Contains(filter.Text.ToLower()))
                                {
                                    FilmsInList.ImportRow(film);
                                }
                            }
                            break;

                        case filterOption.Exclude:
                            if (filter.isCaseSenestive)
                            {
                                if (!film.Field<String>(filter.ToApply).Contains(filter.Text))
                                {
                                    FilmsInList.ImportRow(film);
                                }
                            }
                            else
                            {
                                if (!film.Field<String>(filter.ToApply).ToLower().Contains(filter.Text.ToLower()))
                                {
                                    FilmsInList.ImportRow(film);
                                }
                            }
                            break;
                    }
                });
            });
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            updateFilms();
        }

        private void RemoveFilter_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < filters.Count; x++)
            {
                Filter filter = filters[x];
                for (int i = 0; i < FilterList.SelectedItems.Count; i++)
                {
                    String Name = FilterList.SelectedItems[i].ToString();
                    if (filter.Name.Equals(Name))
                    {
                        filters.Remove(filter);
                        FilterList.Items.Remove(Name);
                    }
                }
            }

            updateFilms();
        }

        private void EditFilter_Click(object sender, EventArgs e)
        {
            foreach (Filter filter in filters)
            {
                if (filter.Name.Equals(FilterList.SelectedItem))
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
    }
}
