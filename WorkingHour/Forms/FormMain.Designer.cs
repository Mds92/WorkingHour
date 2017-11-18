namespace WorkingHour
{
    partial class FormMain
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
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.timerWorking = new System.Windows.Forms.Timer(this.components);
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelStartFrom = new System.Windows.Forms.Label();
            this.labelIdle = new System.Windows.Forms.Label();
            this.timerIdle = new System.Windows.Forms.Timer(this.components);
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.buttonSaveTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.labelTime.Location = new System.Drawing.Point(-2, -3);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(284, 73);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "00:00:00";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Location = new System.Drawing.Point(12, 105);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStop.Enabled = false;
            this.buttonStop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStop.Location = new System.Drawing.Point(411, 105);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(45, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // timerWorking
            // 
            this.timerWorking.Interval = 1000;
            this.timerWorking.Tick += new System.EventHandler(this.TimerWorkingTick);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackgroundImage = global::WorkingHour.Properties.Resources.cogwheel_outline_24;
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSettings.Location = new System.Drawing.Point(424, 9);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(32, 32);
            this.buttonSettings.TabIndex = 6;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.Control;
            this.buttonReset.Enabled = false;
            this.buttonReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonReset.Location = new System.Drawing.Point(360, 105);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(45, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // labelStartFrom
            // 
            this.labelStartFrom.AutoSize = true;
            this.labelStartFrom.Location = new System.Drawing.Point(14, 73);
            this.labelStartFrom.Name = "labelStartFrom";
            this.labelStartFrom.Size = new System.Drawing.Size(52, 13);
            this.labelStartFrom.TabIndex = 1;
            this.labelStartFrom.Text = "StartFrom";
            // 
            // labelIdle
            // 
            this.labelIdle.AutoSize = true;
            this.labelIdle.ForeColor = System.Drawing.Color.DarkRed;
            this.labelIdle.Location = new System.Drawing.Point(184, 73);
            this.labelIdle.Name = "labelIdle";
            this.labelIdle.Size = new System.Drawing.Size(49, 13);
            this.labelIdle.TabIndex = 0;
            this.labelIdle.Text = "00:00:00";
            // 
            // timerIdle
            // 
            this.timerIdle.Interval = 1000;
            this.timerIdle.Tick += new System.EventHandler(this.TimerIdleTick);
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(309, 71);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(96, 21);
            this.comboBoxProjects.TabIndex = 7;
            // 
            // buttonSaveTime
            // 
            this.buttonSaveTime.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSaveTime.Enabled = false;
            this.buttonSaveTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSaveTime.Location = new System.Drawing.Point(411, 70);
            this.buttonSaveTime.Name = "buttonSaveTime";
            this.buttonSaveTime.Size = new System.Drawing.Size(45, 23);
            this.buttonSaveTime.TabIndex = 8;
            this.buttonSaveTime.Text = "Save";
            this.buttonSaveTime.UseVisualStyleBackColor = false;
            this.buttonSaveTime.Click += new System.EventHandler(this.ButtonSaveTime_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 131);
            this.Controls.Add(this.buttonSaveTime);
            this.Controls.Add(this.comboBoxProjects);
            this.Controls.Add(this.labelIdle);
            this.Controls.Add(this.labelStartFrom);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelTime);
            this.Name = "FormMain";
            this.Text = "Working Hour";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Timer timerWorking;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelStartFrom;
        private System.Windows.Forms.Label labelIdle;
        private System.Windows.Forms.Timer timerIdle;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.Button buttonSaveTime;
    }
}

