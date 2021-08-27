namespace WorkingHour.Forms
{
    partial class FormSettings
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
            this.textBoxBackupPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownRestTime = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDeleteBackupFilesOlderThanDays = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRestTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeleteBackupFilesOlderThanDays)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxBackupPath
            // 
            this.textBoxBackupPath.Location = new System.Drawing.Point(116, 49);
            this.textBoxBackupPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBackupPath.Name = "textBoxBackupPath";
            this.textBoxBackupPath.Size = new System.Drawing.Size(572, 22);
            this.textBoxBackupPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Path";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(624, 95);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(65, 28);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(697, 95);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 28);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(697, 47);
            this.buttonSelectFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(53, 28);
            this.buttonSelectFolder.TabIndex = 3;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.ButtonSelectFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rest minutes per hour";
            // 
            // numericUpDownRestTime
            // 
            this.numericUpDownRestTime.Location = new System.Drawing.Point(171, 9);
            this.numericUpDownRestTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownRestTime.Name = "numericUpDownRestTime";
            this.numericUpDownRestTime.Size = new System.Drawing.Size(68, 22);
            this.numericUpDownRestTime.TabIndex = 1;
            this.numericUpDownRestTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownDeleteBackupFilesOlderThanDays
            // 
            this.numericUpDownDeleteBackupFilesOlderThanDays.Location = new System.Drawing.Point(509, 9);
            this.numericUpDownDeleteBackupFilesOlderThanDays.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownDeleteBackupFilesOlderThanDays.Name = "numericUpDownDeleteBackupFilesOlderThanDays";
            this.numericUpDownDeleteBackupFilesOlderThanDays.Size = new System.Drawing.Size(68, 22);
            this.numericUpDownDeleteBackupFilesOlderThanDays.TabIndex = 7;
            this.numericUpDownDeleteBackupFilesOlderThanDays.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Delete backup files older than";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(585, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "days";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 138);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownDeleteBackupFilesOlderThanDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownRestTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBackupPath);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRestTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeleteBackupFilesOlderThanDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBackupPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownRestTime;
        private System.Windows.Forms.NumericUpDown numericUpDownDeleteBackupFilesOlderThanDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}