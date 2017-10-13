using System;
using System.Windows.Forms;
using WorkingHour.Assets;
using WorkingHour.Data.Models;
using WorkingHour.Forms;

namespace WorkingHour
{
    public partial class FormMain : FormBase
    {
        public FormMain()
        {
            InitializeComponent();

            LoadProjectComboBox();
        }

        #region Utility

        private void CheckCursorPosition()
        {
            Invoke(new MethodInvoker(delegate
            {
                StaticAssets.LatestCursorPositionChangeTime = StaticAssets.LatestCursorPosition == Cursor.Position
                    ? StaticAssets.LatestCursorPositionChangeTime.Add(new TimeSpan(0, 0, 0, 1))
                    : new TimeSpan(0, 0, 0, 0);

                StaticAssets.AddSecondToDuration = StaticAssets.LatestCursorPositionChangeTime < Constants.MinTimeSpanToIdentifyIdle;
                labelIdle.Invoke(new MethodInvoker(delegate
                {
                    labelIdle.Text = $@"{StaticAssets.LatestCursorPositionChangeTime.Hours:00}:{StaticAssets.LatestCursorPositionChangeTime.Minutes:00}:{StaticAssets.LatestCursorPositionChangeTime.Seconds:00}";
                }));
            }));
            StaticAssets.LatestCursorPosition = Cursor.Position;
        }

        #endregion

        #region Timer

        private bool _isTimerStarted;

        private void StartTimers()
        {
            StaticAssets.Start = DateTime.Now;
            labelStartFrom.Text = $@"{StaticAssets.Start:yyyy/MM/dd hh:mm:ss}";
            timerWorking.Start();
            timerIdle.Start();
            _isTimerStarted = true;
            ChangeButtonStatus();
        }
        private void StopTimers(bool pause)
        {
            timerWorking.Stop();
            _isTimerStarted = false;
            if (pause)
                timerIdle.Stop();
            ChangeButtonStatus();
        }

        private void TimerWorkingTick(object sender, EventArgs e)
        {
            if (StaticAssets.AddSecondToDuration)
                StaticAssets.Duration = StaticAssets.Duration.Add(new TimeSpan(0, 0, 0, 1));
            buttonReset.Enabled = StaticAssets.Duration > TimeSpan.MinValue;
            labelTime.Text = $@"{StaticAssets.Duration.Hours:00}:{StaticAssets.Duration.Minutes:00}:{StaticAssets.Duration.Seconds:00}";
        }

        private void TimerIdleTick(object sender, EventArgs e)
        {
            CheckCursorPosition();
        }

        #endregion

        #region Dropdown

        private void LoadProjectComboBox()
        {
            comboBoxProjects.Items.Clear();
            var projects = ProjectService.SelectAll();
            foreach (var project in projects)
            {
                comboBoxProjects.Items.Add(new ComboBoxItem
                {
                    Text = project.Title,
                    Value = project.Id
                });
            }
        }

        #endregion

        #region Buttons

        private void ChangeButtonStatus()
        {
            buttonSettings.Enabled = buttonStart.Enabled = !_isTimerStarted;
            buttonPause.Enabled = buttonStop.Enabled = _isTimerStarted;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartTimers();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, @"Are you sure to stop timer?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            StopTimers(false);
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, @"Are you sure to pause timer?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            StopTimers(true);
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, @"Are you sure to reset timer?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            StaticAssets.Duration = new TimeSpan(0, 0, 0, 0);
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            var formProjects = new FormProjects();
            formProjects.Closed += FormProjects_Closed;
            formProjects.ShowDialog(this);
        }

        private void FormProjects_Closed(object sender, EventArgs e)
        {
            LoadProjectComboBox();
        }

        private void ButtonSaveTime_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
