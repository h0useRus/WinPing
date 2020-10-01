namespace NSW.WinPing
{
    partial class WinPing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinPing));
            this.label1 = new System.Windows.Forms.Label();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP1 = new System.Windows.Forms.TextBox();
            this.txtIP2 = new System.Windows.Forms.TextBox();
            this.txtIP3 = new System.Windows.Forms.TextBox();
            this.txtIP4 = new System.Windows.Forms.TextBox();
            this.lblPing = new System.Windows.Forms.Label();
            this.lbLog = new NSW.WinPing.DoubleBufferedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTTL = new System.Windows.Forms.TextBox();
            this.pingWorker = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.nudGood = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudBad = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudLog = new System.Windows.Forms.NumericUpDown();
            this.cbFileLog = new System.Windows.Forms.CheckBox();
            this.nudBuffer = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuffer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:";
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(50, 13);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(165, 20);
            this.txtHostName.TabIndex = 1;
            this.txtHostName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHostName_KeyUp);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(338, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(77, 67);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP:";
            // 
            // txtIP1
            // 
            this.txtIP1.Location = new System.Drawing.Point(46, 91);
            this.txtIP1.Name = "txtIP1";
            this.txtIP1.ReadOnly = true;
            this.txtIP1.Size = new System.Drawing.Size(40, 20);
            this.txtIP1.TabIndex = 5;
            // 
            // txtIP2
            // 
            this.txtIP2.Location = new System.Drawing.Point(92, 91);
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.ReadOnly = true;
            this.txtIP2.Size = new System.Drawing.Size(40, 20);
            this.txtIP2.TabIndex = 6;
            // 
            // txtIP3
            // 
            this.txtIP3.Location = new System.Drawing.Point(138, 91);
            this.txtIP3.Name = "txtIP3";
            this.txtIP3.ReadOnly = true;
            this.txtIP3.Size = new System.Drawing.Size(40, 20);
            this.txtIP3.TabIndex = 7;
            // 
            // txtIP4
            // 
            this.txtIP4.Location = new System.Drawing.Point(184, 91);
            this.txtIP4.Name = "txtIP4";
            this.txtIP4.ReadOnly = true;
            this.txtIP4.Size = new System.Drawing.Size(40, 20);
            this.txtIP4.TabIndex = 8;
            // 
            // lblPing
            // 
            this.lblPing.BackColor = System.Drawing.Color.White;
            this.lblPing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPing.Location = new System.Drawing.Point(334, 91);
            this.lblPing.Name = "lblPing";
            this.lblPing.Size = new System.Drawing.Size(81, 20);
            this.lblPing.TabIndex = 9;
            this.lblPing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.BackColor = System.Drawing.Color.Black;
            this.lbLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLog.ForeColor = System.Drawing.Color.White;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.IntegralHeight = false;
            this.lbLog.Location = new System.Drawing.Point(15, 119);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(400, 294);
            this.lbLog.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "TimeOut:";
            // 
            // nudTimeOut
            // 
            this.nudTimeOut.Location = new System.Drawing.Point(270, 39);
            this.nudTimeOut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeOut.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTimeOut.Name = "nudTimeOut";
            this.nudTimeOut.Size = new System.Drawing.Size(62, 20);
            this.nudTimeOut.TabIndex = 12;
            this.nudTimeOut.ThousandsSeparator = true;
            this.nudTimeOut.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "TTL:";
            // 
            // txtTTL
            // 
            this.txtTTL.Location = new System.Drawing.Point(266, 91);
            this.txtTTL.Name = "txtTTL";
            this.txtTTL.ReadOnly = true;
            this.txtTTL.Size = new System.Drawing.Size(62, 20);
            this.txtTTL.TabIndex = 14;
            // 
            // pingWorker
            // 
            this.pingWorker.WorkerReportsProgress = true;
            this.pingWorker.WorkerSupportsCancellation = true;
            this.pingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pingWorker_DoWork);
            this.pingWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.pingWorker_ProgressChanged);
            this.pingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.pingWorker_RunWorkerCompleted);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "NSW WinPing";
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // nudGood
            // 
            this.nudGood.Location = new System.Drawing.Point(50, 39);
            this.nudGood.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGood.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGood.Name = "nudGood";
            this.nudGood.Size = new System.Drawing.Size(62, 20);
            this.nudGood.TabIndex = 15;
            this.nudGood.ThousandsSeparator = true;
            this.nudGood.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudGood.ValueChanged += new System.EventHandler(this.nudGood_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(8, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Good:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(118, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Bad:";
            // 
            // nudBad
            // 
            this.nudBad.Location = new System.Drawing.Point(153, 39);
            this.nudBad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudBad.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBad.Name = "nudBad";
            this.nudBad.Size = new System.Drawing.Size(62, 20);
            this.nudBad.TabIndex = 18;
            this.nudBad.ThousandsSeparator = true;
            this.nudBad.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudBad.ValueChanged += new System.EventHandler(this.nudBad_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Log if ping more than:";
            // 
            // nudLog
            // 
            this.nudLog.Location = new System.Drawing.Point(153, 64);
            this.nudLog.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLog.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLog.Name = "nudLog";
            this.nudLog.Size = new System.Drawing.Size(62, 20);
            this.nudLog.TabIndex = 20;
            this.nudLog.ThousandsSeparator = true;
            this.nudLog.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // cbFileLog
            // 
            this.cbFileLog.AutoSize = true;
            this.cbFileLog.Location = new System.Drawing.Point(233, 66);
            this.cbFileLog.Name = "cbFileLog";
            this.cbFileLog.Size = new System.Drawing.Size(93, 17);
            this.cbFileLog.TabIndex = 21;
            this.cbFileLog.Text = "No file logging";
            this.cbFileLog.UseVisualStyleBackColor = true;
            // 
            // nudBuffer
            // 
            this.nudBuffer.Location = new System.Drawing.Point(270, 14);
            this.nudBuffer.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.nudBuffer.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudBuffer.Name = "nudBuffer";
            this.nudBuffer.Size = new System.Drawing.Size(62, 20);
            this.nudBuffer.TabIndex = 23;
            this.nudBuffer.ThousandsSeparator = true;
            this.nudBuffer.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Buffer:";
            // 
            // WinPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 427);
            this.Controls.Add(this.nudBuffer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbFileLog);
            this.Controls.Add(this.nudLog);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudBad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudGood);
            this.Controls.Add(this.txtTTL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudTimeOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.lblPing);
            this.Controls.Add(this.txtIP4);
            this.Controls.Add(this.txtIP3);
            this.Controls.Add(this.txtIP2);
            this.Controls.Add(this.txtIP1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtHostName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(443, 1000);
            this.MinimumSize = new System.Drawing.Size(443, 183);
            this.Name = "WinPing";
            this.Text = "NSW WinPing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinPing_FormClosing);
            this.Resize += new System.EventHandler(this.WinPing_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuffer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP1;
        private System.Windows.Forms.TextBox txtIP2;
        private System.Windows.Forms.TextBox txtIP3;
        private System.Windows.Forms.TextBox txtIP4;
        private System.Windows.Forms.Label lblPing;
        private DoubleBufferedListBox lbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTimeOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTTL;
        private System.ComponentModel.BackgroundWorker pingWorker;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.NumericUpDown nudGood;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudBad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudLog;
        private System.Windows.Forms.CheckBox cbFileLog;
        private System.Windows.Forms.NumericUpDown nudBuffer;
        private System.Windows.Forms.Label label8;
    }
}

