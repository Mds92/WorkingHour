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
            this.maskedTextBoxId = new System.Windows.Forms.MaskedTextBox();
            this.listViewProjects = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTotalDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(531, 386);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageProjects
            // 
            this.tabPageProjects.Controls.Add(this.maskedTextBoxId);
            this.tabPageProjects.Controls.Add(this.listViewProjects);
            this.tabPageProjects.Controls.Add(this.buttonSubmit);
            this.tabPageProjects.Controls.Add(this.textBoxTitle);
            this.tabPageProjects.Location = new System.Drawing.Point(4, 22);
            this.tabPageProjects.Name = "tabPageProjects";
            this.tabPageProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjects.Size = new System.Drawing.Size(523, 360);
            this.tabPageProjects.TabIndex = 0;
            this.tabPageProjects.Text = "Projects";
            this.tabPageProjects.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxId
            // 
            this.maskedTextBoxId.Location = new System.Drawing.Point(8, 9);
            this.maskedTextBoxId.Mask = "00000";
            this.maskedTextBoxId.Name = "maskedTextBoxId";
            this.maskedTextBoxId.Size = new System.Drawing.Size(76, 20);
            this.maskedTextBoxId.TabIndex = 4;
            this.maskedTextBoxId.ValidatingType = typeof(int);
            // 
            // listViewProjects
            // 
            this.listViewProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderTitle,
            this.columnHeaderTotalDuration});
            this.listViewProjects.Location = new System.Drawing.Point(7, 35);
            this.listViewProjects.Name = "listViewProjects";
            this.listViewProjects.Size = new System.Drawing.Size(507, 322);
            this.listViewProjects.TabIndex = 3;
            this.listViewProjects.UseCompatibleStateImageBehavior = false;
            this.listViewProjects.VirtualMode = true;
            this.listViewProjects.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ListViewProjects_RetrieveVirtualItem);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 100;
            // 
            // columnHeaderTotalDuration
            // 
            this.columnHeaderTotalDuration.Text = "Total Duration";
            this.columnHeaderTotalDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTotalDuration.Width = 100;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(439, 6);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(90, 9);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(343, 20);
            this.textBoxTitle.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(523, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 386);
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.ListView listViewProjects;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderTotalDuration;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxId;
    }
}