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
            this.maskedTextBoxTimeDuration = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxId = new System.Windows.Forms.MaskedTextBox();
            this.listViewProjects = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTotalDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonSubmitProject = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTimeDuration = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageProjects);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(553, 411);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageProjects
            // 
            this.tabPageProjects.Controls.Add(this.labelTimeDuration);
            this.tabPageProjects.Controls.Add(this.labelTitle);
            this.tabPageProjects.Controls.Add(this.labelId);
            this.tabPageProjects.Controls.Add(this.maskedTextBoxTimeDuration);
            this.tabPageProjects.Controls.Add(this.maskedTextBoxId);
            this.tabPageProjects.Controls.Add(this.listViewProjects);
            this.tabPageProjects.Controls.Add(this.buttonSubmitProject);
            this.tabPageProjects.Controls.Add(this.textBoxTitle);
            this.tabPageProjects.Location = new System.Drawing.Point(4, 22);
            this.tabPageProjects.Name = "tabPageProjects";
            this.tabPageProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjects.Size = new System.Drawing.Size(545, 385);
            this.tabPageProjects.TabIndex = 0;
            this.tabPageProjects.Text = "Projects";
            this.tabPageProjects.UseVisualStyleBackColor = true;
            this.tabPageProjects.Enter += new System.EventHandler(this.tabPageProjects_Enter);
            // 
            // maskedTextBoxTimeDuration
            // 
            this.maskedTextBoxTimeDuration.Location = new System.Drawing.Point(387, 8);
            this.maskedTextBoxTimeDuration.Mask = "00:00:00";
            this.maskedTextBoxTimeDuration.Name = "maskedTextBoxTimeDuration";
            this.maskedTextBoxTimeDuration.Size = new System.Drawing.Size(56, 20);
            this.maskedTextBoxTimeDuration.TabIndex = 5;
            this.maskedTextBoxTimeDuration.ValidatingType = typeof(int);
            // 
            // maskedTextBoxId
            // 
            this.maskedTextBoxId.Location = new System.Drawing.Point(30, 8);
            this.maskedTextBoxId.Mask = "00000";
            this.maskedTextBoxId.Name = "maskedTextBoxId";
            this.maskedTextBoxId.Size = new System.Drawing.Size(41, 20);
            this.maskedTextBoxId.TabIndex = 1;
            this.maskedTextBoxId.ValidatingType = typeof(int);
            // 
            // listViewProjects
            // 
            this.listViewProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderTitle,
            this.columnHeaderDate,
            this.columnHeaderTotalDuration});
            this.listViewProjects.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listViewProjects.FullRowSelect = true;
            this.listViewProjects.GridLines = true;
            this.listViewProjects.HideSelection = false;
            this.listViewProjects.LargeImageList = this.imageList1;
            this.listViewProjects.Location = new System.Drawing.Point(3, 60);
            this.listViewProjects.Name = "listViewProjects";
            this.listViewProjects.Size = new System.Drawing.Size(539, 322);
            this.listViewProjects.SmallImageList = this.imageList1;
            this.listViewProjects.TabIndex = 4;
            this.listViewProjects.UseCompatibleStateImageBehavior = false;
            this.listViewProjects.View = System.Windows.Forms.View.Details;
            this.listViewProjects.SelectedIndexChanged += new System.EventHandler(this.listViewProjects_SelectedIndexChanged);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            this.columnHeaderId.Width = 57;
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 138;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Register Date";
            this.columnHeaderDate.Width = 166;
            // 
            // columnHeaderTotalDuration
            // 
            this.columnHeaderTotalDuration.Text = "Total Duration";
            this.columnHeaderTotalDuration.Width = 171;
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
            this.buttonSubmitProject.Location = new System.Drawing.Point(487, 8);
            this.buttonSubmitProject.Name = "buttonSubmitProject";
            this.buttonSubmitProject.Size = new System.Drawing.Size(48, 23);
            this.buttonSubmitProject.TabIndex = 3;
            this.buttonSubmitProject.Text = "Submit";
            this.buttonSubmitProject.UseVisualStyleBackColor = true;
            this.buttonSubmitProject.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(130, 9);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(154, 20);
            this.textBoxTitle.TabIndex = 2;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(8, 12);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(19, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(94, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(30, 13);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Title:";
            // 
            // labelTimeDuration
            // 
            this.labelTimeDuration.AutoSize = true;
            this.labelTimeDuration.Location = new System.Drawing.Point(307, 12);
            this.labelTimeDuration.Name = "labelTimeDuration";
            this.labelTimeDuration.Size = new System.Drawing.Size(76, 13);
            this.labelTimeDuration.TabIndex = 0;
            this.labelTimeDuration.Text = "Time Duration:";
            // 
            // FormProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 411);
            this.Controls.Add(this.tabControl);
            this.Name = "FormProjects";
            this.Text = "FormProjects";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageProjects.ResumeLayout(false);
            this.tabPageProjects.PerformLayout();
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
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTimeDuration;
        private System.Windows.Forms.Label labelTimeDuration;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelId;
    }
}