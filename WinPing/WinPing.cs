using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using NSW.WinPing.Properties;
using NSW.WinPing.TaskBar;

namespace NSW.WinPing
{
    public partial class WinPing : Form
    {
        private const string OriginalTitle = "NSW WinPing";
        private const string RecentFile = "recent.acf";
        private string _titleTemplate;
        public WinPing()
        {
            InitializeComponent();
            lbLog.DrawMode = DrawMode.OwnerDrawFixed;
            lbLog.DrawItem += lbLog_DrawItem;
            Icon = notifyIcon.Icon = GetIcon(-1);
            nudGood.Value = PingSpectrum.Current.Good;
            nudBad.Value = PingSpectrum.Current.Bad;
            nudTimeOut.Value = PingSpectrum.Current.TimeOut;
            txtHostName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtHostName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            LoadRecent(collection);
            collection.CollectionChanged += CollectionOnCollectionChanged;
            txtHostName.AutoCompleteCustomSource = collection;
        }

        private void LoadRecent(AutoCompleteStringCollection collection)
        {
            if(File.Exists(RecentFile))
                using (var s = File.OpenText(RecentFile))
                {
                    collection.Add(s.ReadLine());
                }
        }

        private void SaveRecent(AutoCompleteStringCollection collection)
        {
            using (var s = File.CreateText(RecentFile))
            {
                foreach (var item in collection)
                {
                    s.WriteLine(item.ToString());
                }
                s.Flush();
            }
        }

        private void CollectionOnCollectionChanged(object sender, CollectionChangeEventArgs ccea)
        {
            if (ccea.Action == CollectionChangeAction.Add && ccea.Element!= null)
            {
                var source = new AutoCompleteStringCollection();
                LoadRecent(source);
                var element = ccea.Element.ToString();
                if (!source.Contains(element))
                    source.Add(ccea.Element.ToString());
                SaveRecent(source);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!pingWorker.IsBusy)
            {
                PingSpectrum.Current = new PingSpectrum
                {
                    Good = (long)nudGood.Value,
                    Bad = (long)nudBad.Value,
                    TimeOut = (long)nudTimeOut.Value
                };
                StartPinging(txtHostName.Text.Trim(), (int)PingSpectrum.Current.TimeOut);
            }
            else
                pingWorker.CancelAsync();
        }

        private void StartPinging(string hostName, int maxTimeOut)
        {
            btnStart.Text = "Stop";
            txtHostName.ReadOnly = true;
            nudBuffer.Enabled = nudGood.Enabled = nudBad.Enabled = nudTimeOut.Enabled = nudLog.Enabled = false;
            
            var pingData = PingHost(hostName, maxTimeOut, (int)nudBuffer.Value);
            if (pingData.Status == IPStatus.Unknown)
            {
                MessageBox.Show("Host '" + hostName + "' do not supporting ping service!");
                StopPinging();
            }
            else
            {
                _titleTemplate = "Ping '" + hostName + "' [{0}] - " + OriginalTitle;
                if (!txtHostName.AutoCompleteCustomSource.Contains(hostName))
                    txtHostName.AutoCompleteCustomSource.Add(hostName);
                var fileName = hostName + "_" + DateTime.Now.ToString("yyyyMMdd@HHmmss") + ".log";
                Logger.NoFileLog = cbFileLog.Checked;
                Logger.Start(fileName, lbLog);
                Logger.Log(null, "Start ping host '" + hostName + "'.", null, true);
                UpdatePingForm(pingData);
                pingWorker.RunWorkerAsync(new PingSettings { HostName = hostName, MaxTimeOut = maxTimeOut });
            }
        }

        private void UpdatePingForm(PingData pingData)
        {
            notifyIcon.Icon = GetIcon(pingData.Status == IPStatus.Success ? pingData.Time : 0);
            if (pingData.Address != null)
            {
                string[] ipParts = pingData.Address.ToString().Split('.');
                if (ipParts.Length == 4)
                {
                    txtIP1.Text = int.Parse(ipParts[0]).ToString("000");
                    txtIP2.Text = int.Parse(ipParts[1]).ToString("000");
                    txtIP3.Text = int.Parse(ipParts[2]).ToString("000");
                    txtIP4.Text = int.Parse(ipParts[3]).ToString("000");
                }
                txtTTL.Text = pingData.TTL.ToString();
            }
            if (notifyIcon.Visible && pingData.Status != IPStatus.Success)
            {
                notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                notifyIcon.BalloonTipTitle = Text;
                notifyIcon.BalloonTipText = "Ping error:" + Environment.NewLine + pingData.Message;
                notifyIcon.ShowBalloonTip(1000);
            }
            var lableText = pingData.Status == IPStatus.Success ? pingData.Time + " ms" : pingData.Status.ToString();
            notifyIcon.Text = Text = string.Format(_titleTemplate, lableText);
            lblPing.Text = lableText;
            lblPing.BackColor = pingData.Color;
            Logger.Log(pingData.TimeStamp, pingData.ToString(), pingData.Color, pingData.Status != IPStatus.Success || pingData.Time >= nudLog.Value );
            TaskBarProgress.SetProgressState(Handle, GetProgressState(pingData.Status == IPStatus.Success ? pingData.Time : 0));
            TaskBarProgress.SetProgressValue(Handle, 100, 100);
        }

        private ThumbnailProgressState GetProgressState(long time)
        {
            if(time==-1)
                return ThumbnailProgressState.NoProgress;
            if (time == 0)
                return ThumbnailProgressState.Error;
            if (time < PingSpectrum.Current.Good)
                return ThumbnailProgressState.Normal;
            return ThumbnailProgressState.Paused;
        }

        private Icon GetIcon(long time)
        {
            if (time == -1)
                return Resources.AppIco;
            if (time == 0)
                return Resources.CircleRed;
            if (time < PingSpectrum.Current.Good / 3)
                return Resources.CircleBlue;
            if (time < PingSpectrum.Current.Good)
                return Resources.CircleGreen;
            if (time < PingSpectrum.Current.Bad / 2)
                return Resources.CircleYellow;
            return Resources.CircleOrange;
        }

        private PingData PingHost(string hostName, int maxTimeOut, int bytesTosend)
        {
            try
            {
                var ping = new Ping();
                var packet = new byte[bytesTosend];
                var pingResult = ping.Send(hostName, maxTimeOut, packet);
                return new PingData(pingResult);
            }
            catch (Exception e)
            {
                return new PingData(e);
            }
        }

        private void StopPinging()
        {
            btnStart.Text = "Start";
            txtHostName.ReadOnly = false;
            nudBuffer.Enabled = nudGood.Enabled = nudBad.Enabled = nudTimeOut.Enabled = nudLog.Enabled = true;
            notifyIcon.Text = Text = OriginalTitle;
            notifyIcon.Icon = GetIcon(-1);
            TaskBarProgress.SetProgressState(Handle, GetProgressState(-1));
            Logger.Stop();
        }

        private void lbLog_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(e.Index<0) return;

            e.DrawBackground();

            var g = e.Graphics;
            var lb = (ListBox)sender;
            if (lb.Items[e.Index] is LogData item)
            {
                g.DrawString(item.ToString(), e.Font, new SolidBrush(item.Color), new PointF(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                g.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
            }

            e.DrawFocusRectangle();
        }

        private void WinPing_FormClosing(object sender, FormClosingEventArgs e)
        {
            pingWorker.CancelAsync();
        }

        private void pingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var settings = (PingSettings)e.Argument;
            while (!pingWorker.CancellationPending)
            {
                DateTime starTime = DateTime.Now;
                var pingData = PingHost(settings.HostName, settings.MaxTimeOut, (int)nudBuffer.Value);
                pingWorker.ReportProgress(100, pingData);
                if (pingData.Time > 0)
                {
                    settings.PingTotal += (ulong)pingData.Time;
                    settings.Attempts += 1;
                }
                var workTime = DateTime.Now - starTime;
                int sleepDelay = 1000 - workTime.Milliseconds;
                if (sleepDelay > 0)
                    Thread.Sleep(sleepDelay);
            }
            pingWorker.ReportProgress(100, settings);
        }

        private void pingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var pingData = e.UserState as PingData;
            if (pingData != null)
                UpdatePingForm(pingData);
            else
            {
                var s = e.UserState as PingSettings;
                var avg = s.Attempts > 0 ? s.PingTotal / s.Attempts : 0;
                Logger.Log(null, "Avg ping: " + avg + " ms.", Color.DeepPink, true);
                Logger.Log(null, "Stop ping host '" + s.HostName + "'.", null, true);
                lblPing.Text = s.Attempts > 0 ? avg + " ms" : "n/a";
                lblPing.BackColor = PingData.GetColor(s.Attempts > 0 ? (long)avg : -1);
            }
        }

        private void pingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StopPinging();
        }

        private void WinPing_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        class PingSettings
        {
            public string HostName { get; set; }
            public int MaxTimeOut { get; set; }
            public ulong Attempts { get; set; }
            public ulong PingTotal { get; set; }
        }

        private void txtHostName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnStart_Click(null, null);
            }
        }

        private void nudGood_ValueChanged(object sender, EventArgs e)
        {
            if (nudBad.Value < nudGood.Value)
                nudBad.Value = nudGood.Value;
            nudBad.Minimum = nudGood.Value;
        }

        private void nudBad_ValueChanged(object sender, EventArgs e)
        {
            if (nudTimeOut.Value < nudBad.Value)
                nudTimeOut.Value = nudBad.Value;
            nudTimeOut.Minimum = nudBad.Value;
        }

    }
}
