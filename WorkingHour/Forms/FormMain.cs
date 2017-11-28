using System;
using System.Diagnostics;
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
            LoadProjectComboBox();

            #region Form Events

            StaticAssets.OriginalWindowSize = Size;
            Deactivate += FormDeactivate;
            Activated += FormActivated;
            LoadSavedDraft();

            #endregion
        }

        #region Variables

        public bool DisableDeactivateOperation { get; set; }

        #endregion

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
#if DEBUG
            Trace.WriteLine(activeWindowTitle);
#endif
            return StaticAssets.ForbiddinApps.Any(q => activeWindowTitle.IndexOf(q, StringComparison.InvariantCultureIgnoreCase) > -1);
        }

        private void SetLabelDurationText()
        {
            labelDuration.Text = $@"{StaticAssets.Duration.Hours:00}:{StaticAssets.Duration.Minutes:00}:{StaticAssets.Duration.Seconds:00}";
        }
        private void SetLabelStartFromText()
        {
            labelStartFrom.Text = $@"{StaticAssets.StartDateTime:yyyy/MM/dd hh:mm:ss}";
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
            DraftService.Clear();
        }

        private void TimerWorkingTick(object sender, EventArgs e)
        {
            buttonReset.Enabled = StaticAssets.Duration > TimeSpan.MinValue;
            if (!StaticAssets.AddSecondToDuration || IsForbiddinWindowActive()) return;
            StaticAssets.Duration = StaticAssets.Duration.Add(new TimeSpan(0, 0, 0, 1));
#if DEBUG
            StaticAssets.Duration = StaticAssets.Duration.Add(new TimeSpan(0, 0, 5, 0));
#endif
            SetLabelDurationText();
            DraftService.Save(new DraftModel
            {
                StartDateTime = StaticAssets.StartDateTime,
                Duration = StaticAssets.Duration
            });
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
            buttonStop.Enabled = _isTimerStarted;
            comboBoxProjects.Enabled = buttonSaveTime.Enabled = !_isTimerStarted;
        }

        private void PublicActionsInButtonClick()
        {
            DisableDeactivateOperation = true;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartTimers();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            PublicActionsInButtonClick();
            if (MessageBox.Show(this, @"Are you sure to stop timer?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            StopTimers();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            PublicActionsInButtonClick();
            if (MessageBox.Show(this, @"Are you sure to reset timer?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            StaticAssets.Duration = new TimeSpan(0, 0, 0, 0);
            labelDuration.Text = "00:00:00";
            labelStartFrom.Text = "";
            DraftService.Clear();
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            DisableDeactivateOperation = true;
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
            if (!(comboBoxProjects.SelectedItem is ComboBoxItem project)) return;
            PublicActionsInButtonClick();
            try
            {
                TimeService.Save(new TimeModel
                {
                    ProjectId = int.Parse(project.Value.ToString()),
                    Duration = StaticAssets.Duration,
                    StopDateTime = StaticAssets.StopDateTime,
                    StartDateTime = StaticAssets.StartDateTime
                });
                ShowSuccessMessage("Time saved successfully");
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
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
        }

        #endregion
    }
}
