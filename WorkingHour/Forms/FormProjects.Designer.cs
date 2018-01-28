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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageProjects = new System.Windows.Forms.TabPage();
            this.buttonProjectCancel = new System.Windows.Forms.Button();
            this.buttonProjectNew = new System.Windows.Forms.Button();
            this.buttonDeleteProject = new System.Windows.Forms.Button();
            this.labelTimeInitialDuration = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.maskedTextBoxProjectInitialTimeDuration = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxProjectId = new System.Windows.Forms.MaskedTextBox();
            this.listViewProjects = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderInitialDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTotalDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonProjectSubmit = new System.Windows.Forms.Button();
            this.textBoxProjectTitle = new System.Windows.Forms.TextBox();
            this.tabPageTimes = new System.Windows.Forms.TabPage();
            this.textBoxTimeDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBoxTimeStopDateTime = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBoxTimeStartDateTime = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBoxTimeDuration = new System.Windows.Forms.MaskedTextBox();
            this.buttonTimeCancel = new System.Windows.Forms.Button();
            this.buttonTimeNew = new System.Windows.Forms.Button();
            this.buttonDeleteTime = new System.Windows.Forms.Button();
            this.buttonTimeSubmit = new System.Windows.Forms.Button();
            this.buttonExportData = new System.Windows.Forms.Button();
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.labelProjects = new System.Windows.Forms.Label();
            this.listViewTimes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageDataBase = new System.Windows.Forms.TabPage();
            this.buttonMerge = new System.Windows.Forms.Button();
            this.labelMegingInfo = new System.Windows.Forms.Label();
            this.labelProjectNumber = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSelectDataBase = new System.Windows.Forms.Button();
            this.textBoxDatabaseFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogForXml = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageProjects.SuspendLayout();
            this.tabPageTimes.SuspendLayout();
            this.tabPageDataBase.SuspendLayout();
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
            this.tabControl.Controls.Add(this.tabPageDataBase);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(884, 461);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageProjects
            // 
            this.tabPageProjects.Controls.Add(this.buttonProjectCancel);
            this.tabPageProjects.Controls.Add(this.buttonProjectNew);
            this.tabPageProjects.Controls.Add(this.buttonDeleteProject);
            this.tabPageProjects.Controls.Add(this.labelTimeInitialDuration);
            this.tabPageProjects.Controls.Add(this.labelTitle);
            this.tabPageProjects.Controls.Add(this.labelId);
            this.tabPageProjects.Controls.Add(this.maskedTextBoxProjectInitialTimeDuration);
            this.tabPageProjects.Controls.Add(this.maskedTextBoxProjectId);
            this.tabPageProjects.Controls.Add(this.listViewProjects);
            this.tabPageProjects.Controls.Add(this.buttonProjectSubmit);
            this.tabPageProjects.Controls.Add(this.textBoxProjectTitle);
            this.tabPageProjects.Location = new System.Drawing.Point(4, 25);
            this.tabPageProjects.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageProjects.Name = "tabPageProjects";
            this.tabPageProjects.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageProjects.Size = new System.Drawing.Size(876, 432);
            this.tabPageProjects.TabIndex = 0;
            this.tabPageProjects.Text = "Projects";
            this.tabPageProjects.UseVisualStyleBackColor = true;
            this.tabPageProjects.Enter += new System.EventHandler(this.TabPageProjects_Enter);
            // 
            // buttonProjectCancel
            // 
            this.buttonProjectCancel.BackgroundImage = global::WorkingHour.Properties.Resources.ic_cancel_black_24dp_1x;
            this.buttonProjectCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonProjectCancel.Location = new System.Drawing.Point(691, 11);
            this.buttonProjectCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonProjectCancel.Name = "buttonProjectCancel";
            this.buttonProjectCancel.Size = new System.Drawing.Size(24, 24);
            this.buttonProjectCancel.TabIndex = 10;
            this.toolTip1.SetToolTip(this.buttonProjectCancel, "Cancel");
            this.buttonProjectCancel.UseVisualStyleBackColor = true;
            this.buttonProjectCancel.Visible = false;
            this.buttonProjectCancel.Click += new System.EventHandler(this.ButtonProjectCancel_Click);
            // 
            // buttonProjectNew
            // 
            this.buttonProjectNew.BackgroundImage = global::WorkingHour.Properties.Resources.ic_add_black_24dp_1x;
            this.buttonProjectNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonProjectNew.Location = new System.Drawing.Point(659, 11);
            this.buttonProjectNew.Margin = new System.Windows.Forms.Padding(4);
            this.buttonProjectNew.Name = "buttonProjectNew";
            this.buttonProjectNew.Size = new System.Drawing.Size(24, 24);
            this.buttonProjectNew.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonProjectNew, "New");
            this.buttonProjectNew.UseVisualStyleBackColor = true;
            this.buttonProjectNew.Visible = false;
            this.buttonProjectNew.Click += new System.EventHandler(this.ButtonProjectNew_Click);
            // 
            // buttonDeleteProject
            // 
            this.buttonDeleteProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonDeleteProject.BackgroundImage = global::WorkingHour.Properties.Resources.ic_clear_black_24dp_1x;
            this.buttonDeleteProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDeleteProject.Location = new System.Drawing.Point(797, 11);
            this.buttonDeleteProject.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteProject.Name = "buttonDeleteProject";
            this.buttonDeleteProject.Size = new System.Drawing.Size(24, 24);
            this.buttonDeleteProject.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonDeleteProject, "Delete");
            this.buttonDeleteProject.UseVisualStyleBackColor = false;
            this.buttonDeleteProject.Visible = false;
            this.buttonDeleteProject.Click += new System.EventHandler(this.ButtonProjectDelete_Click);
            // 
            // labelTimeInitialDuration
            // 
            this.labelTimeInitialDuration.AutoSize = true;
            this.labelTimeInitialDuration.Location = new System.Drawing.Point(395, 15);
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
            this.labelId.Location = new System.Drawing.Point(19, 14);
            this.labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(23, 17);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id:";
            // 
            // maskedTextBoxProjectInitialTimeDuration
            // 
            this.maskedTextBoxProjectInitialTimeDuration.Enabled = false;
            this.maskedTextBoxProjectInitialTimeDuration.Location = new System.Drawing.Point(540, 12);
            this.maskedTextBoxProjectInitialTimeDuration.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxProjectInitialTimeDuration.Mask = "0000:00:00";
            this.maskedTextBoxProjectInitialTimeDuration.Name = "maskedTextBoxProjectInitialTimeDuration";
            this.maskedTextBoxProjectInitialTimeDuration.Size = new System.Drawing.Size(99, 23);
            this.maskedTextBoxProjectInitialTimeDuration.TabIndex = 3;
            this.maskedTextBoxProjectInitialTimeDuration.Text = "00000000";
            this.maskedTextBoxProjectInitialTimeDuration.ValidatingType = typeof(int);
            // 
            // maskedTextBoxProjectId
            // 
            this.maskedTextBoxProjectId.Enabled = false;
            this.maskedTextBoxProjectId.Location = new System.Drawing.Point(48, 11);
            this.maskedTextBoxProjectId.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxProjectId.Mask = "00000";
            this.maskedTextBoxProjectId.Name = "maskedTextBoxProjectId";
            this.maskedTextBoxProjectId.Size = new System.Drawing.Size(54, 23);
            this.maskedTextBoxProjectId.TabIndex = 1;
            this.maskedTextBoxProjectId.ValidatingType = typeof(int);
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
            this.listViewProjects.Location = new System.Drawing.Point(4, 43);
            this.listViewProjects.Margin = new System.Windows.Forms.Padding(4);
            this.listViewProjects.Name = "listViewProjects";
            this.listViewProjects.Size = new System.Drawing.Size(868, 385);
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
            this.columnHeaderInitialDuration.Width = 148;
            // 
            // columnHeaderTotalDuration
            // 
            this.columnHeaderTotalDuration.Text = "Total Duration";
            this.columnHeaderTotalDuration.Width = 158;
            // 
            // buttonProjectSubmit
            // 
            this.buttonProjectSubmit.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonProjectSubmit.BackgroundImage = global::WorkingHour.Properties.Resources.ic_done_black_24dp_1x;
            this.buttonProjectSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonProjectSubmit.Location = new System.Drawing.Point(844, 10);
            this.buttonProjectSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonProjectSubmit.Name = "buttonProjectSubmit";
            this.buttonProjectSubmit.Size = new System.Drawing.Size(24, 24);
            this.buttonProjectSubmit.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonProjectSubmit, "Submit");
            this.buttonProjectSubmit.UseVisualStyleBackColor = false;
            this.buttonProjectSubmit.Visible = false;
            this.buttonProjectSubmit.Click += new System.EventHandler(this.ButtonProjectSubmit_Click);
            // 
            // textBoxProjectTitle
            // 
            this.textBoxProjectTitle.Enabled = false;
            this.textBoxProjectTitle.Location = new System.Drawing.Point(173, 11);
            this.textBoxProjectTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxProjectTitle.Name = "textBoxProjectTitle";
            this.textBoxProjectTitle.Size = new System.Drawing.Size(204, 23);
            this.textBoxProjectTitle.TabIndex = 2;
            // 
            // tabPageTimes
            // 
            this.tabPageTimes.Controls.Add(this.textBoxTimeDescription);
            this.tabPageTimes.Controls.Add(this.label4);
            this.tabPageTimes.Controls.Add(this.maskedTextBoxTimeStopDateTime);
            this.tabPageTimes.Controls.Add(this.label3);
            this.tabPageTimes.Controls.Add(this.maskedTextBoxTimeStartDateTime);
            this.tabPageTimes.Controls.Add(this.label1);
            this.tabPageTimes.Controls.Add(this.label2);
            this.tabPageTimes.Controls.Add(this.maskedTextBoxTimeDuration);
            this.tabPageTimes.Controls.Add(this.buttonTimeCancel);
            this.tabPageTimes.Controls.Add(this.buttonTimeNew);
            this.tabPageTimes.Controls.Add(this.buttonDeleteTime);
            this.tabPageTimes.Controls.Add(this.buttonTimeSubmit);
            this.tabPageTimes.Controls.Add(this.buttonExportData);
            this.tabPageTimes.Controls.Add(this.comboBoxProjects);
            this.tabPageTimes.Controls.Add(this.labelProjects);
            this.tabPageTimes.Controls.Add(this.listViewTimes);
            this.tabPageTimes.Location = new System.Drawing.Point(4, 25);
            this.tabPageTimes.Name = "tabPageTimes";
            this.tabPageTimes.Size = new System.Drawing.Size(876, 432);
            this.tabPageTimes.TabIndex = 1;
            this.tabPageTimes.Text = "Times";
            this.tabPageTimes.UseVisualStyleBackColor = true;
            this.tabPageTimes.Enter += new System.EventHandler(this.TabPageTimes_Enter);
            // 
            // textBoxTimeDescription
            // 
            this.textBoxTimeDescription.Enabled = false;
            this.textBoxTimeDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTimeDescription.Location = new System.Drawing.Point(90, 73);
            this.textBoxTimeDescription.Multiline = true;
            this.textBoxTimeDescription.Name = "textBoxTimeDescription";
            this.textBoxTimeDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTimeDescription.Size = new System.Drawing.Size(777, 47);
            this.textBoxTimeDescription.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Description:";
            // 
            // maskedTextBoxTimeStopDateTime
            // 
            this.maskedTextBoxTimeStopDateTime.Enabled = false;
            this.maskedTextBoxTimeStopDateTime.Location = new System.Drawing.Point(539, 39);
            this.maskedTextBoxTimeStopDateTime.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxTimeStopDateTime.Mask = "0000-00-00   00:00:00";
            this.maskedTextBoxTimeStopDateTime.Name = "maskedTextBoxTimeStopDateTime";
            this.maskedTextBoxTimeStopDateTime.Size = new System.Drawing.Size(133, 23);
            this.maskedTextBoxTimeStopDateTime.TabIndex = 5;
            this.maskedTextBoxTimeStopDateTime.Text = "00000000000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Stop Date Time:";
            // 
            // maskedTextBoxTimeStartDateTime
            // 
            this.maskedTextBoxTimeStartDateTime.Enabled = false;
            this.maskedTextBoxTimeStartDateTime.Location = new System.Drawing.Point(279, 39);
            this.maskedTextBoxTimeStartDateTime.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxTimeStartDateTime.Mask = "0000-00-00   00:00:00";
            this.maskedTextBoxTimeStartDateTime.Name = "maskedTextBoxTimeStartDateTime";
            this.maskedTextBoxTimeStartDateTime.Size = new System.Drawing.Size(133, 23);
            this.maskedTextBoxTimeStartDateTime.TabIndex = 4;
            this.maskedTextBoxTimeStartDateTime.Text = "00000000000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Duration:";
            // 
            // maskedTextBoxTimeDuration
            // 
            this.maskedTextBoxTimeDuration.Enabled = false;
            this.maskedTextBoxTimeDuration.Location = new System.Drawing.Point(76, 39);
            this.maskedTextBoxTimeDuration.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxTimeDuration.Mask = "0000:00:00";
            this.maskedTextBoxTimeDuration.Name = "maskedTextBoxTimeDuration";
            this.maskedTextBoxTimeDuration.Size = new System.Drawing.Size(77, 23);
            this.maskedTextBoxTimeDuration.TabIndex = 3;
            this.maskedTextBoxTimeDuration.Text = "00000000";
            this.maskedTextBoxTimeDuration.ValidatingType = typeof(int);
            // 
            // buttonTimeCancel
            // 
            this.buttonTimeCancel.BackgroundImage = global::WorkingHour.Properties.Resources.ic_cancel_black_24dp_1x;
            this.buttonTimeCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTimeCancel.Location = new System.Drawing.Point(747, 38);
            this.buttonTimeCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTimeCancel.Name = "buttonTimeCancel";
            this.buttonTimeCancel.Size = new System.Drawing.Size(24, 24);
            this.buttonTimeCancel.TabIndex = 7;
            this.toolTip1.SetToolTip(this.buttonTimeCancel, "Cancel");
            this.buttonTimeCancel.UseVisualStyleBackColor = true;
            this.buttonTimeCancel.Visible = false;
            this.buttonTimeCancel.Click += new System.EventHandler(this.ButtonTimeCancel_Click);
            // 
            // buttonTimeNew
            // 
            this.buttonTimeNew.BackgroundImage = global::WorkingHour.Properties.Resources.ic_add_black_24dp_1x;
            this.buttonTimeNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTimeNew.Location = new System.Drawing.Point(715, 38);
            this.buttonTimeNew.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTimeNew.Name = "buttonTimeNew";
            this.buttonTimeNew.Size = new System.Drawing.Size(24, 24);
            this.buttonTimeNew.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonTimeNew, "New");
            this.buttonTimeNew.UseVisualStyleBackColor = true;
            this.buttonTimeNew.Visible = false;
            this.buttonTimeNew.Click += new System.EventHandler(this.ButtonTimeNew_Click);
            // 
            // buttonDeleteTime
            // 
            this.buttonDeleteTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonDeleteTime.BackgroundImage = global::WorkingHour.Properties.Resources.ic_clear_black_24dp_1x;
            this.buttonDeleteTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDeleteTime.Location = new System.Drawing.Point(812, 39);
            this.buttonDeleteTime.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteTime.Name = "buttonDeleteTime";
            this.buttonDeleteTime.Size = new System.Drawing.Size(24, 24);
            this.buttonDeleteTime.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonDeleteTime, "Delete");
            this.buttonDeleteTime.UseVisualStyleBackColor = false;
            this.buttonDeleteTime.Visible = false;
            this.buttonDeleteTime.Click += new System.EventHandler(this.ButtonTimeDelete_Click);
            // 
            // buttonTimeSubmit
            // 
            this.buttonTimeSubmit.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonTimeSubmit.BackgroundImage = global::WorkingHour.Properties.Resources.ic_done_black_24dp_1x;
            this.buttonTimeSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTimeSubmit.Location = new System.Drawing.Point(846, 39);
            this.buttonTimeSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTimeSubmit.Name = "buttonTimeSubmit";
            this.buttonTimeSubmit.Size = new System.Drawing.Size(24, 24);
            this.buttonTimeSubmit.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonTimeSubmit, "Submit");
            this.buttonTimeSubmit.UseVisualStyleBackColor = false;
            this.buttonTimeSubmit.Visible = false;
            this.buttonTimeSubmit.Click += new System.EventHandler(this.ButtonTimeSubmit_Click);
            // 
            // buttonExportData
            // 
            this.buttonExportData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonExportData.Location = new System.Drawing.Point(304, 5);
            this.buttonExportData.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExportData.Name = "buttonExportData";
            this.buttonExportData.Size = new System.Drawing.Size(59, 28);
            this.buttonExportData.TabIndex = 2;
            this.buttonExportData.Text = "Export";
            this.buttonExportData.UseVisualStyleBackColor = true;
            this.buttonExportData.Click += new System.EventHandler(this.ButtonExportData_Click);
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(76, 7);
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
            this.columnHeader5,
            this.columnHeader6});
            this.listViewTimes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listViewTimes.FullRowSelect = true;
            this.listViewTimes.GridLines = true;
            this.listViewTimes.HideSelection = false;
            this.listViewTimes.Location = new System.Drawing.Point(0, 127);
            this.listViewTimes.Margin = new System.Windows.Forms.Padding(4);
            this.listViewTimes.Name = "listViewTimes";
            this.listViewTimes.Size = new System.Drawing.Size(876, 305);
            this.listViewTimes.TabIndex = 11;
            this.listViewTimes.UseCompatibleStateImageBehavior = false;
            this.listViewTimes.View = System.Windows.Forms.View.Details;
            this.listViewTimes.SelectedIndexChanged += new System.EventHandler(this.ListViewTimes_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 50;
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
            // columnHeader6
            // 
            this.columnHeader6.Text = "Description";
            this.columnHeader6.Width = 186;
            // 
            // tabPageDataBase
            // 
            this.tabPageDataBase.Controls.Add(this.buttonMerge);
            this.tabPageDataBase.Controls.Add(this.labelMegingInfo);
            this.tabPageDataBase.Controls.Add(this.labelProjectNumber);
            this.tabPageDataBase.Controls.Add(this.label7);
            this.tabPageDataBase.Controls.Add(this.label6);
            this.tabPageDataBase.Controls.Add(this.buttonSelectDataBase);
            this.tabPageDataBase.Controls.Add(this.textBoxDatabaseFilePath);
            this.tabPageDataBase.Controls.Add(this.label5);
            this.tabPageDataBase.Location = new System.Drawing.Point(4, 25);
            this.tabPageDataBase.Name = "tabPageDataBase";
            this.tabPageDataBase.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataBase.Size = new System.Drawing.Size(876, 432);
            this.tabPageDataBase.TabIndex = 2;
            this.tabPageDataBase.Text = "Merge";
            this.tabPageDataBase.UseVisualStyleBackColor = true;
            // 
            // buttonMerge
            // 
            this.buttonMerge.BackColor = System.Drawing.Color.Red;
            this.buttonMerge.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMerge.Location = new System.Drawing.Point(746, 123);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(75, 31);
            this.buttonMerge.TabIndex = 0;
            this.buttonMerge.Text = "Merge";
            this.buttonMerge.UseVisualStyleBackColor = false;
            this.buttonMerge.Visible = false;
            this.buttonMerge.Click += new System.EventHandler(this.ButtonMerge_Click);
            // 
            // labelMegingInfo
            // 
            this.labelMegingInfo.AutoSize = true;
            this.labelMegingInfo.ForeColor = System.Drawing.Color.Blue;
            this.labelMegingInfo.Location = new System.Drawing.Point(14, 123);
            this.labelMegingInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMegingInfo.Name = "labelMegingInfo";
            this.labelMegingInfo.Size = new System.Drawing.Size(86, 17);
            this.labelMegingInfo.TabIndex = 0;
            this.labelMegingInfo.Text = "Merging info";
            // 
            // labelProjectNumber
            // 
            this.labelProjectNumber.AutoSize = true;
            this.labelProjectNumber.Location = new System.Drawing.Point(139, 83);
            this.labelProjectNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProjectNumber.Name = "labelProjectNumber";
            this.labelProjectNumber.Size = new System.Drawing.Size(32, 17);
            this.labelProjectNumber.TabIndex = 0;
            this.labelProjectNumber.Text = "000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 82);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Project Numbers:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(287, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Merging two database, base on Project Name";
            // 
            // buttonSelectDataBase
            // 
            this.buttonSelectDataBase.Location = new System.Drawing.Point(826, 39);
            this.buttonSelectDataBase.Name = "buttonSelectDataBase";
            this.buttonSelectDataBase.Size = new System.Drawing.Size(28, 23);
            this.buttonSelectDataBase.TabIndex = 2;
            this.buttonSelectDataBase.Text = "...";
            this.toolTip1.SetToolTip(this.buttonSelectDataBase, "Select Database File");
            this.buttonSelectDataBase.UseVisualStyleBackColor = true;
            this.buttonSelectDataBase.Click += new System.EventHandler(this.ButtonSelectDataBase_Click);
            // 
            // textBoxDatabaseFilePath
            // 
            this.textBoxDatabaseFilePath.Location = new System.Drawing.Point(119, 39);
            this.textBoxDatabaseFilePath.Name = "textBoxDatabaseFilePath";
            this.textBoxDatabaseFilePath.Size = new System.Drawing.Size(702, 23);
            this.textBoxDatabaseFilePath.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Database Path:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "exportData";
            this.saveFileDialog1.Filter = "Excel file|*.xlsx";
            // 
            // openFileDialogForXml
            // 
            this.openFileDialogForXml.FileName = "openFileDialog1";
            this.openFileDialogForXml.Filter = "Xml File|*.xml";
            // 
            // FormProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "FormProjects";
            this.Text = "Projects";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageProjects.ResumeLayout(false);
            this.tabPageProjects.PerformLayout();
            this.tabPageTimes.ResumeLayout(false);
            this.tabPageTimes.PerformLayout();
            this.tabPageDataBase.ResumeLayout(false);
            this.tabPageDataBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageProjects;
        private System.Windows.Forms.Button buttonProjectSubmit;
        private System.Windows.Forms.TextBox textBoxProjectTitle;
        private System.Windows.Forms.ListView listViewProjects;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderTotalDuration;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxProjectId;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxProjectInitialTimeDuration;
        private System.Windows.Forms.Label labelTimeInitialDuration;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.ColumnHeader columnHeaderInitialDuration;
        private System.Windows.Forms.Button buttonDeleteProject;
        private System.Windows.Forms.Button buttonProjectNew;
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
        private System.Windows.Forms.Button buttonExportData;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonProjectCancel;
        private System.Windows.Forms.Button buttonTimeCancel;
        private System.Windows.Forms.Button buttonTimeNew;
        private System.Windows.Forms.Button buttonDeleteTime;
        private System.Windows.Forms.Button buttonTimeSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTimeDuration;
        private System.Windows.Forms.TextBox textBoxTimeDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTimeStopDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTimeStartDateTime;
        private System.Windows.Forms.TabPage tabPageDataBase;
        private System.Windows.Forms.Button buttonSelectDataBase;
        private System.Windows.Forms.TextBox textBoxDatabaseFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialogForXml;
        private System.Windows.Forms.Label labelMegingInfo;
        private System.Windows.Forms.Label labelProjectNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonMerge;
    }
}