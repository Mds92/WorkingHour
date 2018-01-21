namespace WorkingHour.Forms
{
    partial class FormProjects
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProjects));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageProjects = new System.Windows.Forms.TabPage();
            this.buttonExportData = new System.Windows.Forms.Button();
            this.buttonNewProject = new System.Windows.Forms.Button();
            this.buttonEditProject = new System.Windows.Forms.Button();
            this.buttonDeleteProject = new System.Windows.Forms.Button();
            this.labelTimeInitialDuration = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.maskedTextBoxInitialTimeDuration = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxId = new System.Windows.Forms.MaskedTextBox();
            this.listViewProjects = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderInitialDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTotalDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonSubmitProject = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.tabPageTimes = new System.Windows.Forms.TabPage();
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.labelProjects = new System.Windows.Forms.Label();
            this.listViewTimes = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageProjects.SuspendLayout();
            this.tabPageTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageProjects);
            this.tabControl.Controls.Add(this.tabPageTimes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(684, 321);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageProjects
            // 
            this.tabPageProjects.Controls.Add(this.buttonExportData);
            this.tabPageProjects.Controls.Add(this.buttonNewProject);
            this.tabPageProjects.Controls.Add(this.buttonEditProject);
            this.tabPageProjects.Controls.Add(this.buttonDeleteProject);
            this.tabPageProjects.Controls.Add(this.labelTimeInitialDuration);
            this.tabPageProjects.Controls.Add(this.labelTitle);
            this.tabPageProjects.Controls.Add(this.labelId);
            this.tabPageProjects.Controls.Add(this.maskedTextBoxInitialTimeDuration);
            this.tabPageProjects.Controls.Add(this.maskedTextBoxId);
            this.tabPageProjects.Controls.Add(this.listViewProjects);
            this.tabPageProjects.Controls.Add(this.buttonSubmitProject);
            this.tabPageProjects.Controls.Add(this.textBoxTitle);
            this.tabPageProjects.Location = new System.Drawing.Point(4, 25);
            this.tabPageProjects.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageProjects.Name = "tabPageProjects";
            this.tabPageProjects.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageProjects.Size = new System.Drawing.Size(676, 292);
            this.tabPageProjects.TabIndex = 0;
            this.tabPageProjects.Text = "Projects";
            this.tabPageProjects.UseVisualStyleBackColor = true;
            this.tabPageProjects.Enter += new System.EventHandler(this.TabPageProjects_Enter);
            // 
            // buttonExportData
            // 
            this.buttonExportData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonExportData.Location = new System.Drawing.Point(343, 38);
            this.buttonExportData.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExportData.Name = "buttonExportData";
            this.buttonExportData.Size = new System.Drawing.Size(59, 28);
            this.buttonExportData.TabIndex = 7;
            this.buttonExportData.Text = "Export";
            this.buttonExportData.UseVisualStyleBackColor = true;
            this.buttonExportData.Click += new System.EventHandler(this.ButtonExportData_Click);
            // 
            // buttonNewProject
            // 
            this.buttonNewProject.Location = new System.Drawing.Point(8, 38);
            this.buttonNewProject.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNewProject.Name = "buttonNewProject";
            this.buttonNewProject.Size = new System.Drawing.Size(45, 28);
            this.buttonNewProject.TabIndex = 4;
            this.buttonNewProject.Text = "New";
            this.buttonNewProject.UseVisualStyleBackColor = true;
            this.buttonNewProject.Click += new System.EventHandler(this.ButtonNewProject_Click);
            // 
            // buttonEditProject
            // 
            this.buttonEditProject.Enabled = false;
            this.buttonEditProject.Location = new System.Drawing.Point(57, 38);
            this.buttonEditProject.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEditProject.Name = "buttonEditProject";
            this.buttonEditProject.Size = new System.Drawing.Size(45, 28);
            this.buttonEditProject.TabIndex = 5;
            this.buttonEditProject.Text = "Edit";
            this.buttonEditProject.UseVisualStyleBackColor = true;
            this.buttonEditProject.Click += new System.EventHandler(this.ButtonEditProject_Click);
            // 
            // buttonDeleteProject
            // 
            this.buttonDeleteProject.Enabled = false;
            this.buttonDeleteProject.Location = new System.Drawing.Point(612, 38);
            this.buttonDeleteProject.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteProject.Name = "buttonDeleteProject";
            this.buttonDeleteProject.Size = new System.Drawing.Size(60, 28);
            this.buttonDeleteProject.TabIndex = 8;
            this.buttonDeleteProject.Text = "Delete";
            this.buttonDeleteProject.UseVisualStyleBackColor = true;
            this.buttonDeleteProject.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // labelTimeInitialDuration
            // 
            this.labelTimeInitialDuration.AutoSize = true;
            this.labelTimeInitialDuration.Location = new System.Drawing.Point(413, 15);
            this.labelTimeInitialDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeInitialDuration.Name = "labelTimeInitialDuration";
            this.labelTimeInitialDuration.Size = new System.Drawing.Size(137, 17);
            this.labelTimeInitialDuration.TabIndex = 0;
            this.labelTimeInitialDuration.Text = "Initial Time Duration:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(131, 14);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(39, 17);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title:";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(15, 14);
            this.labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(23, 17);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id:";
            // 
            // maskedTextBoxInitialTimeDuration
            // 
            this.maskedTextBoxInitialTimeDuration.Enabled = false;
            this.maskedTextBoxInitialTimeDuration.Location = new System.Drawing.Point(552, 12);
            this.maskedTextBoxInitialTimeDuration.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxInitialTimeDuration.Mask = "0000:00:00";
            this.maskedTextBoxInitialTimeDuration.Name = "maskedTextBoxInitialTimeDuration";
            this.maskedTextBoxInitialTimeDuration.Size = new System.Drawing.Size(99, 23);
            this.maskedTextBoxInitialTimeDuration.TabIndex = 3;
            this.maskedTextBoxInitialTimeDuration.Text = "00000000";
            this.maskedTextBoxInitialTimeDuration.ValidatingType = typeof(int);
            // 
            // maskedTextBoxId
            // 
            this.maskedTextBoxId.Enabled = false;
            this.maskedTextBoxId.Location = new System.Drawing.Point(40, 10);
            this.maskedTextBoxId.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxId.Mask = "00000";
            this.maskedTextBoxId.Name = "maskedTextBoxId";
            this.maskedTextBoxId.Size = new System.Drawing.Size(54, 23);
            this.maskedTextBoxId.TabIndex = 1;
            this.maskedTextBoxId.ValidatingType = typeof(int);
            // 
            // listViewProjects
            // 
            this.listViewProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderTitle,
            this.columnHeaderDate,
            this.columnHeaderInitialDuration,
            this.columnHeaderTotalDuration});
            this.listViewProjects.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listViewProjects.FullRowSelect = true;
            this.listViewProjects.GridLines = true;
            this.listViewProjects.HideSelection = false;
            this.listViewProjects.LargeImageList = this.imageList1;
            this.listViewProjects.Location = new System.Drawing.Point(4, 74);
            this.listViewProjects.Margin = new System.Windows.Forms.Padding(4);
            this.listViewProjects.Name = "listViewProjects";
            this.listViewProjects.Size = new System.Drawing.Size(668, 214);
            this.listViewProjects.SmallImageList = this.imageList1;
            this.listViewProjects.TabIndex = 9;
            this.listViewProjects.UseCompatibleStateImageBehavior = false;
            this.listViewProjects.View = System.Windows.Forms.View.Details;
            this.listViewProjects.SelectedIndexChanged += new System.EventHandler(this.ListViewProjects_SelectedIndexChanged);
            this.listViewProjects.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewProjects_MouseDoubleClick);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            this.columnHeaderId.Width = 57;
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 124;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Register Date";
            this.columnHeaderDate.Width = 240;
            // 
            // columnHeaderInitialDuration
            // 
            this.columnHeaderInitialDuration.Text = "Initial Duration";
            this.columnHeaderInitialDuration.Width = 110;
            // 
            // columnHeaderTotalDuration
            // 
            this.columnHeaderTotalDuration.Text = "Total Duration";
            this.columnHeaderTotalDuration.Width = 110;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cross-remove-sign.png");
            this.imageList1.Images.SetKeyName(1, "pencil-edit-button.png");
            // 
            // buttonSubmitProject
            // 
            this.buttonSubmitProject.Enabled = false;
            this.buttonSubmitProject.Location = new System.Drawing.Point(275, 38);
            this.buttonSubmitProject.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSubmitProject.Name = "buttonSubmitProject";
            this.buttonSubmitProject.Size = new System.Drawing.Size(64, 28);
            this.buttonSubmitProject.TabIndex = 6;
            this.buttonSubmitProject.Text = "Submit";
            this.buttonSubmitProject.UseVisualStyleBackColor = true;
            this.buttonSubmitProject.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.Location = new System.Drawing.Point(173, 11);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(204, 23);
            this.textBoxTitle.TabIndex = 2;
            // 
            // tabPageTimes
            // 
            this.tabPageTimes.Controls.Add(this.comboBoxProjects);
            this.tabPageTimes.Controls.Add(this.labelProjects);
            this.tabPageTimes.Controls.Add(this.listViewTimes);
            this.tabPageTimes.Location = new System.Drawing.Point(4, 25);
            this.tabPageTimes.Name = "tabPageTimes";
            this.tabPageTimes.Size = new System.Drawing.Size(676, 292);
            this.tabPageTimes.TabIndex = 1;
            this.tabPageTimes.Text = "Times";
            this.tabPageTimes.UseVisualStyleBackColor = true;
            this.tabPageTimes.Enter += new System.EventHandler(this.TabPageTimes_Enter);
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(79, 8);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(218, 24);
            this.comboBoxProjects.TabIndex = 1;
            this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProjects_SelectedIndexChanged);
            // 
            // labelProjects
            // 
            this.labelProjects.AutoSize = true;
            this.labelProjects.Location = new System.Drawing.Point(9, 11);
            this.labelProjects.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProjects.Name = "labelProjects";
            this.labelProjects.Size = new System.Drawing.Size(63, 17);
            this.labelProjects.TabIndex = 0;
            this.labelProjects.Text = "Projects:";
            // 
            // listViewTimes
            // 
            this.listViewTimes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewTimes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listViewTimes.FullRowSelect = true;
            this.listViewTimes.GridLines = true;
            this.listViewTimes.HideSelection = false;
            this.listViewTimes.LargeImageList = this.imageList1;
            this.listViewTimes.Location = new System.Drawing.Point(0, 39);
            this.listViewTimes.Margin = new System.Windows.Forms.Padding(4);
            this.listViewTimes.Name = "listViewTimes";
            this.listViewTimes.Size = new System.Drawing.Size(676, 253);
            this.listViewTimes.SmallImageList = this.imageList1;
            this.listViewTimes.TabIndex = 10;
            this.listViewTimes.UseCompatibleStateImageBehavior = false;
            this.listViewTimes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Duration";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Start Date Time";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Stop Date Time";
            this.columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Register Date Time";
            this.columnHeader5.Width = 150;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "exportData";
            this.saveFileDialog1.Filter = "Text file|*.txt";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 50;
            // 
            // FormProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 321);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProjects";
            this.Text = "Projects";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageProjects.ResumeLayout(false);
            this.tabPageProjects.PerformLayout();
            this.tabPageTimes.ResumeLayout(false);
            this.tabPageTimes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageProjects;
        private System.Windows.Forms.Button buttonSubmitProject;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.ListView listViewProjects;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderTotalDuration;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxId;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxInitialTimeDuration;
        private System.Windows.Forms.Label labelTimeInitialDuration;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.ColumnHeader columnHeaderInitialDuration;
        private System.Windows.Forms.Button buttonDeleteProject;
        private System.Windows.Forms.Button buttonNewProject;
        private System.Windows.Forms.Button buttonEditProject;
        private System.Windows.Forms.Button buttonExportData;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPageTimes;
        private System.Windows.Forms.ListView listViewTimes;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.Label labelProjects;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}