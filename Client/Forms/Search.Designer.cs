namespace Client.Forms
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FilmsFound = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FilterList = new System.Windows.Forms.ListBox();
            this.FilterGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnBox = new System.Windows.Forms.ComboBox();
            this.CaseSensetiveCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TextToCompare = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ExcludeCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludeCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterNameTextBox = new System.Windows.Forms.TextBox();
            this.FilterNameLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.RemoveFilter = new System.Windows.Forms.Button();
            this.SaveFilter = new System.Windows.Forms.Button();
            this.EditFilter = new System.Windows.Forms.Button();
            this.CheckProgress = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilmsFound)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.FilterGroup.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FilmsFound);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 238);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Found Films";
            // 
            // FilmsFound
            // 
            this.FilmsFound.AllowUserToAddRows = false;
            this.FilmsFound.AllowUserToDeleteRows = false;
            this.FilmsFound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilmsFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilmsFound.Location = new System.Drawing.Point(3, 16);
            this.FilmsFound.Name = "FilmsFound";
            this.FilmsFound.ReadOnly = true;
            this.FilmsFound.Size = new System.Drawing.Size(546, 219);
            this.FilmsFound.TabIndex = 20;
            this.FilmsFound.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilmsFound_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FilterList);
            this.groupBox2.Location = new System.Drawing.Point(560, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 238);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Applied Filters";
            // 
            // FilterList
            // 
            this.FilterList.FormattingEnabled = true;
            this.FilterList.Location = new System.Drawing.Point(3, 16);
            this.FilterList.Name = "FilterList";
            this.FilterList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FilterList.Size = new System.Drawing.Size(139, 212);
            this.FilterList.TabIndex = 7;
            this.FilterList.SelectedIndexChanged += new System.EventHandler(this.FilterList_SelectedIndexChanged);
            // 
            // FilterGroup
            // 
            this.FilterGroup.Controls.Add(this.label1);
            this.FilterGroup.Controls.Add(this.ColumnBox);
            this.FilterGroup.Controls.Add(this.CaseSensetiveCheckBox);
            this.FilterGroup.Controls.Add(this.groupBox5);
            this.FilterGroup.Controls.Add(this.groupBox3);
            this.FilterGroup.Controls.Add(this.FilterNameTextBox);
            this.FilterGroup.Controls.Add(this.FilterNameLabel);
            this.FilterGroup.Location = new System.Drawing.Point(5, 246);
            this.FilterGroup.Name = "FilterGroup";
            this.FilterGroup.Size = new System.Drawing.Size(505, 173);
            this.FilterGroup.TabIndex = 11;
            this.FilterGroup.TabStop = false;
            this.FilterGroup.Text = "New/edit Filter";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Applied To";
            // 
            // ColumnBox
            // 
            this.ColumnBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnBox.FormattingEnabled = true;
            this.ColumnBox.Location = new System.Drawing.Point(6, 146);
            this.ColumnBox.Name = "ColumnBox";
            this.ColumnBox.Size = new System.Drawing.Size(121, 21);
            this.ColumnBox.TabIndex = 12;
            this.ColumnBox.SelectedIndexChanged += new System.EventHandler(this.ColumnBox_SelectedIndexChanged);
            // 
            // CaseSensetiveCheckBox
            // 
            this.CaseSensetiveCheckBox.AutoSize = true;
            this.CaseSensetiveCheckBox.Location = new System.Drawing.Point(9, 42);
            this.CaseSensetiveCheckBox.Name = "CaseSensetiveCheckBox";
            this.CaseSensetiveCheckBox.Size = new System.Drawing.Size(100, 17);
            this.CaseSensetiveCheckBox.TabIndex = 17;
            this.CaseSensetiveCheckBox.Text = "Case Sensetive";
            this.CaseSensetiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TextToCompare);
            this.groupBox5.Location = new System.Drawing.Point(301, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 150);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Text to Compare";
            // 
            // TextToCompare
            // 
            this.TextToCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextToCompare.Location = new System.Drawing.Point(3, 16);
            this.TextToCompare.Name = "TextToCompare";
            this.TextToCompare.Size = new System.Drawing.Size(239, 131);
            this.TextToCompare.TabIndex = 10;
            this.TextToCompare.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ExcludeCheckBox);
            this.groupBox3.Controls.Add(this.IncludeCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(9, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(72, 66);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter Type";
            // 
            // ExcludeCheckBox
            // 
            this.ExcludeCheckBox.AutoSize = true;
            this.ExcludeCheckBox.Location = new System.Drawing.Point(6, 39);
            this.ExcludeCheckBox.Name = "ExcludeCheckBox";
            this.ExcludeCheckBox.Size = new System.Drawing.Size(64, 17);
            this.ExcludeCheckBox.TabIndex = 16;
            this.ExcludeCheckBox.Text = "Exclude";
            this.ExcludeCheckBox.UseVisualStyleBackColor = true;
            this.ExcludeCheckBox.CheckedChanged += new System.EventHandler(this.ExcludeCheckBox_CheckedChanged);
            // 
            // IncludeCheckBox
            // 
            this.IncludeCheckBox.AutoSize = true;
            this.IncludeCheckBox.Location = new System.Drawing.Point(6, 19);
            this.IncludeCheckBox.Name = "IncludeCheckBox";
            this.IncludeCheckBox.Size = new System.Drawing.Size(61, 17);
            this.IncludeCheckBox.TabIndex = 15;
            this.IncludeCheckBox.Text = "Include";
            this.IncludeCheckBox.UseVisualStyleBackColor = true;
            this.IncludeCheckBox.CheckedChanged += new System.EventHandler(this.IncludeCheckBox_CheckedChanged);
            // 
            // FilterNameTextBox
            // 
            this.FilterNameTextBox.Location = new System.Drawing.Point(72, 16);
            this.FilterNameTextBox.Name = "FilterNameTextBox";
            this.FilterNameTextBox.Size = new System.Drawing.Size(99, 20);
            this.FilterNameTextBox.TabIndex = 19;
            this.FilterNameTextBox.TextChanged += new System.EventHandler(this.FilterNameTextBox_TextChanged);
            // 
            // FilterNameLabel
            // 
            this.FilterNameLabel.AutoSize = true;
            this.FilterNameLabel.Location = new System.Drawing.Point(6, 19);
            this.FilterNameLabel.Name = "FilterNameLabel";
            this.FilterNameLabel.Size = new System.Drawing.Size(60, 13);
            this.FilterNameLabel.TabIndex = 18;
            this.FilterNameLabel.Text = "Filter Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Cancel);
            this.groupBox4.Controls.Add(this.SearchButton);
            this.groupBox4.Controls.Add(this.RemoveFilter);
            this.groupBox4.Controls.Add(this.SaveFilter);
            this.groupBox4.Controls.Add(this.EditFilter);
            this.groupBox4.Location = new System.Drawing.Point(563, 246);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(139, 173);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(9, 135);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(121, 23);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(9, 106);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(121, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // RemoveFilter
            // 
            this.RemoveFilter.Enabled = false;
            this.RemoveFilter.Location = new System.Drawing.Point(9, 77);
            this.RemoveFilter.Name = "RemoveFilter";
            this.RemoveFilter.Size = new System.Drawing.Size(124, 23);
            this.RemoveFilter.TabIndex = 3;
            this.RemoveFilter.Text = "Remove Filter";
            this.RemoveFilter.UseVisualStyleBackColor = true;
            this.RemoveFilter.Click += new System.EventHandler(this.RemoveFilter_Click);
            // 
            // SaveFilter
            // 
            this.SaveFilter.Enabled = false;
            this.SaveFilter.Location = new System.Drawing.Point(9, 48);
            this.SaveFilter.Name = "SaveFilter";
            this.SaveFilter.Size = new System.Drawing.Size(124, 23);
            this.SaveFilter.TabIndex = 4;
            this.SaveFilter.Text = "Save Filter";
            this.SaveFilter.UseVisualStyleBackColor = true;
            this.SaveFilter.Click += new System.EventHandler(this.SaveFilter_Click);
            // 
            // EditFilter
            // 
            this.EditFilter.Enabled = false;
            this.EditFilter.Location = new System.Drawing.Point(9, 19);
            this.EditFilter.Name = "EditFilter";
            this.EditFilter.Size = new System.Drawing.Size(124, 23);
            this.EditFilter.TabIndex = 5;
            this.EditFilter.Text = "Edit Filter";
            this.EditFilter.UseVisualStyleBackColor = true;
            this.EditFilter.Click += new System.EventHandler(this.EditFilter_Click);
            // 
            // CheckProgress
            // 
            this.CheckProgress.Location = new System.Drawing.Point(5, 419);
            this.CheckProgress.Name = "CheckProgress";
            this.CheckProgress.Size = new System.Drawing.Size(696, 23);
            this.CheckProgress.TabIndex = 4;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 445);
            this.Controls.Add(this.CheckProgress);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.FilterGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilmsFound)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.FilterGroup.ResumeLayout(false);
            this.FilterGroup.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView FilmsFound;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox FilterList;
        private System.Windows.Forms.GroupBox FilterGroup;
        private System.Windows.Forms.Label FilterNameLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button RemoveFilter;
        private System.Windows.Forms.Button SaveFilter;
        private System.Windows.Forms.Button EditFilter;
        private System.Windows.Forms.TextBox FilterNameTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ExcludeCheckBox;
        private System.Windows.Forms.CheckBox IncludeCheckBox;
        private System.Windows.Forms.CheckBox CaseSensetiveCheckBox;
        private System.Windows.Forms.RichTextBox TextToCompare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ColumnBox;
        private System.Windows.Forms.ProgressBar CheckProgress;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button Cancel;
    }
}