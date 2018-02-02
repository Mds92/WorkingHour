using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WorkingHour.Assets;
using WorkingHour.Data.Models;
using WorkingHour.Data.Services;
using WorkingHour.Forms;

namespace WorkingHour
{
    public partial class FormMain : FormBase
    {
        public FormMain()
        {
            InitializeComponent();

#if !DEBUG
            TopMost = true;
#endif
            LoadProjectComboBox();

            #region Form Events

            StaticAssets.OriginalWindowSize = Size;
            Deactivate += FormDeactivate;
            Activated += FormActivated;
            LoadSavedDraft();
            KeyLogger.Start(KeyDownAction);

            #endregion
        }

        #region Variables

        public bool DisableDeactivateOperation { get; set; }

        #endregion

        #region Utility

        private void UpdateLabelIdleText()
        {
            Invoke(new MethodInvoker(delegate
            {
                labelIdle.Invoke(new MethodInvoker(delegate
                {
                    labelIdle.Text = $@"{StaticAssets.IdleTime.Hours:00}:{StaticAssets.IdleTime.Minutes:00}:{StaticAssets.IdleTime.Seconds:00}";
                }));
            }));
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        private string GetCaptionOfActiveWindow()
        {
            var strTitle = string.Empty;
            var handle = GetForegroundWindow();
            // Obtain the length of the text   
            var intLength = GetWindowTextLength(handle) + 1;
            var stringBuilder = new StringBuilder(intLength);
            if (GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                strTitle = stringBuilder.ToString();
            }
            return strTitle;
        }

        private bool IsForbiddinWindowActive()
        {
            var activeWindowTitle = GetCaptionOfActiveWindow();
            return StaticAssets.ForbiddinApps.Any(q => activeWindowTitle.IndexOf(q, StringComparison.InvariantCultureIgnoreCase) > -1);
        }

        private void SetLabelDurationText()
        {
            var labelString = $@"{StaticAssets.Duration.Hours:00}:{StaticAssets.Duration.Minutes:00}:{StaticAssets.Duration.Seconds:00}";
            labelDuration.Text = toolStripMenuItemTime.Text = notifyIcon.Text = labelString;
        }
        private void SetLabelStartFromText()
        {
            labelStartFrom.Text = StaticAssets.StartDateTime.ToStandardString();
        }

        #endregion

        #region Timer

        private bool _isTimerStarted;

        private void StartTimers()
        {
            if (StaticAssets.Duration <= new TimeSpan(0, 0, 0, 0)) StaticAssets.StartDateTime = DateTime.Now;
            SetLabelStartFromText();
            timerWorking.Start();
            timerIdle.Start();
            timerBackup.Start();
            _isTimerStarted = true;
            ChangeButtonStatus();
        }
        private void StopTimers()
        {
            StaticAssets.StopDateTime = DateTime.Now;
            timerWorking.Stop();
            _isTimerStarted = false;
            timerIdle.Stop();
            ChangeButtonStatus();
        }

        private void TimerWorkingTick(object sender, EventArgs e)
        {
            buttonReset.Enabled = StaticAssets.Duration > TimeSpan.MinValue;
            if (StaticAssets.IdleTime > Constants.MinTimeSpanToIdentifyIdle || IsForbiddinWindowActive()) return;
            StaticAssets.Duration = StaticAssets.Duration.Add(new TimeSpan(0, 0, 0, 1));
#if DEBUG
            StaticAssets.Duration = StaticAssets.Duration.Add(new TimeSpan(0, 0, 10, 0));
#endif
            SetLabelDurationText();
        }

        private void TimerIdleTick(object sender, EventArgs e)
        {
#if DEBUG

            StaticAssets.IdleTime =
                StaticAssets.LatestCursorPosition == Cursor.Position
                    ? StaticAssets.IdleTime.Add(new TimeSpan(0, 0, 0, 30))
                    : new TimeSpan(0, 0, 0, 0);
#else
            StaticAssets.IdleTime =
                StaticAssets.LatestCursorPosition == Cursor.Position
                ? StaticAssets.IdleTime.Add(new TimeSpan(0, 0, 0, 1))
                : new TimeSpan(0, 0, 0, 0);
#endif

            UpdateLabelIdleText();
            StaticAssets.LatestCursorPosition = Cursor.Position;
        }

        private TimeSpan _backupTimeSpan = new TimeSpan(0, 0, 0, 0);
        private void TimerBackup_Tick(object sender, EventArgs e)
        {
            _backupTimeSpan = _backupTimeSpan.Add(new TimeSpan(0, 0, 0, 1));
            if (!(_backupTimeSpan.TotalMinutes > 10)) return;
            DraftService.Save(new DraftModel
            {
                StartDateTime = StaticAssets.StartDateTime,
                Duration = StaticAssets.Duration
            });
            _backupTimeSpan = new TimeSpan(0, 0, 0, 0);
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
                    Value = project.Id.ToString()
                });
            }
        }

        #endregion

        #region Buttons

        private void ChangeButtonStatus()
        {
            buttonProjects.Enabled = buttonSettings.Enabled = buttonStart.Enabled = toolStripMenuItemStart.Enabled = !_isTimerStarted;
            buttonStop.Enabled = toolStripMenuItemStop.Enabled = _isTimerStarted;
            comboBoxProjects.Enabled = buttonSaveTime.Enabled = !_isTimerStarted;
            buttonReset.Enabled = StaticAssets.Duration > TimeSpan.MinValue;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartTimers();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            DisableDeactivateOperation = true;
            if (MessageBox.Show(this, @"Are you sure to stop timer?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            DraftService.Save(new DraftModel
            {
                StartDateTime = StaticAssets.StartDateTime,
                Duration = StaticAssets.Duration
            });
            StopTimers();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            DisableDeactivateOperation = true;
            if (MessageBox.Show(this, @"Are you sure to reset timer?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            StaticAssets.Duration = new TimeSpan(0, 0, 0, 0);
            labelDuration.Text = "00:00:00";
            toolStripMenuItemTime.Text = "00:00:00";
            labelStartFrom.Text = "";
            if (_isTimerStarted)
            {
                StaticAssets.StartDateTime = DateTime.Now;
                labelStartFrom.Text = StaticAssets.StartDateTime.ToStandardString();
            }
            DraftService.Clear();
        }

        private void ButtonProjects_Click(object sender, EventArgs e)
        {
            DisableDeactivateOperation = true;
            var formProjects = new FormProjects();
            formProjects.Closed += FormProjects_Closed;
            formProjects.ShowDialog(this);
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            DisableDeactivateOperation = true;
            var form = new FormSettings();
            form.ShowDialog(this);
        }

        private void FormProjects_Closed(object sender, EventArgs e)
        {
            LoadProjectComboBox();
        }

        private void ButtonSaveTime_Click(object sender, EventArgs e)
        {
            if (!(comboBoxProjects.SelectedItem is ComboBoxItem project)) return;
            DisableDeactivateOperation = true;
            var projectId = project.Value;
            var form = new FormSave(projectId);
            form.ShowDialog(this);
        }

        private void ButtonSystemTray_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
            Hide();
        }

        #endregion

        #region Form

        private void FormDeactivate(object sender, EventArgs e)
        {
            if (DisableDeactivateOperation) return;
            FormBorderStyle = FormBorderStyle.None;
            Size = new Size(270, 70);
        }

        private void FormActivated(object sender, EventArgs e)
        {
            if (DisableDeactivateOperation)
            {
                DisableDeactivateOperation = false;
                return;
            }
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Size = StaticAssets.OriginalWindowSize;
        }

        private void LoadSavedDraft()
        {
            var draftModel = DraftService.GetDraftModel();
            if (draftModel == null) return;
            if (draftModel.StartDateTime > DateTime.MinValue)
            {
                StaticAssets.StartDateTime = draftModel.StartDateTime;
                SetLabelStartFromText();
            }
            if (draftModel.Duration > TimeSpan.MinValue)
            {
                StaticAssets.Duration = draftModel.Duration;
                SetLabelDurationText();
            }
            ChangeButtonStatus();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            KeyLogger.Stop();
        }

        private void KeyDownAction(Keys key)
        {
            StaticAssets.IdleTime = new TimeSpan(0, 0, 0, 0);
            UpdateLabelIdleText();
        }

        #endregion

        #region Notify Icon

        private void NotifyIcon_MouseDoubleClick(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            Show();
        }

        private void ToolStripMenuItemStart_Click(object sender, EventArgs e)
        {
            if (_isTimerStarted) return;
            StartTimers();
        }

        private void ToolStripMenuItemStop_Click(object sender, EventArgs e)
        {
            if (!_isTimerStarted) return;
            StopTimers();
        }

        #endregion
    }
}
