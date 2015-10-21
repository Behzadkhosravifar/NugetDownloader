namespace NugetDownloader
{
    partial class MainForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartDownload = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelPerc = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLimitPercent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numMinSleepTime = new System.Windows.Forms.NumericUpDown();
            this.numMinLimit = new System.Windows.Forms.NumericUpDown();
            this.numMaxLimit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numMaxSleepTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numMinSleepTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSleepTime)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(371, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "\r\nhttps://www.nuget.org/api/v2/package/PackageID/PackageVersion";
            this.toolTip.SetToolTip(this.textBox1, "Sample: https://www.nuget.org/api/v2/package/NugetDownloader/2.1.3");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nuget Link:";
            // 
            // btnStartDownload
            // 
            this.btnStartDownload.Location = new System.Drawing.Point(15, 130);
            this.btnStartDownload.Name = "btnStartDownload";
            this.btnStartDownload.Size = new System.Drawing.Size(91, 32);
            this.btnStartDownload.TabIndex = 2;
            this.btnStartDownload.Text = "&Start Download";
            this.btnStartDownload.UseVisualStyleBackColor = true;
            this.btnStartDownload.Click += new System.EventHandler(this.btnStartDownload_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(395, 140);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(13, 13);
            this.lblCounter.TabIndex = 3;
            this.lblCounter.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Download Counter:";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(20, 96);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(13, 13);
            this.labelSpeed.TabIndex = 5;
            this.labelSpeed.Text = "0";
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.Location = new System.Drawing.Point(291, 96);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(80, 13);
            this.labelDownloaded.TabIndex = 6;
            this.labelDownloaded.Text = "0 Mb\'s / 0 Mb\'s";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(15, 54);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(356, 23);
            this.progressBar.TabIndex = 7;
            // 
            // labelPerc
            // 
            this.labelPerc.AutoSize = true;
            this.labelPerc.Location = new System.Drawing.Point(377, 58);
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(24, 13);
            this.labelPerc.TabIndex = 8;
            this.labelPerc.Text = "0 %";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(112, 130);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(91, 32);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Minisystem", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 260);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(98, 21);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status: ";
            this.toolTip.SetToolTip(this.lblStatus, "Download state");
            // 
            // lblLimitPercent
            // 
            this.lblLimitPercent.AutoSize = true;
            this.lblLimitPercent.Location = new System.Drawing.Point(407, 58);
            this.lblLimitPercent.Name = "lblLimitPercent";
            this.lblLimitPercent.Size = new System.Drawing.Size(29, 13);
            this.lblLimitPercent.TabIndex = 10;
            this.lblLimitPercent.Text = "/ 1%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Min Limit :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Min Sleep Time: ";
            // 
            // numMinSleepTime
            // 
            this.numMinSleepTime.Location = new System.Drawing.Point(112, 224);
            this.numMinSleepTime.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numMinSleepTime.Name = "numMinSleepTime";
            this.numMinSleepTime.Size = new System.Drawing.Size(62, 20);
            this.numMinSleepTime.TabIndex = 13;
            this.toolTip.SetToolTip(this.numMinSleepTime, "Minimum random sleep time between every download");
            this.numMinSleepTime.ValueChanged += new System.EventHandler(this.numMinSleepTime_ValueChanged);
            // 
            // numMinLimit
            // 
            this.numMinLimit.Location = new System.Drawing.Point(80, 184);
            this.numMinLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinLimit.Name = "numMinLimit";
            this.numMinLimit.Size = new System.Drawing.Size(62, 20);
            this.numMinLimit.TabIndex = 14;
            this.toolTip.SetToolTip(this.numMinLimit, "Minimum download random percent");
            this.numMinLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinLimit.ValueChanged += new System.EventHandler(this.numMinLimit_ValueChanged);
            // 
            // numMaxLimit
            // 
            this.numMaxLimit.Location = new System.Drawing.Point(389, 184);
            this.numMaxLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxLimit.Name = "numMaxLimit";
            this.numMaxLimit.Size = new System.Drawing.Size(62, 20);
            this.numMaxLimit.TabIndex = 14;
            this.toolTip.SetToolTip(this.numMaxLimit, "Maximum download random percent");
            this.numMaxLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxLimit.ValueChanged += new System.EventHandler(this.numMaxLimit_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Max Limit :";
            // 
            // numMaxSleepTime
            // 
            this.numMaxSleepTime.Location = new System.Drawing.Point(389, 224);
            this.numMaxSleepTime.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numMaxSleepTime.Name = "numMaxSleepTime";
            this.numMaxSleepTime.Size = new System.Drawing.Size(62, 20);
            this.numMaxSleepTime.TabIndex = 17;
            this.toolTip.SetToolTip(this.numMaxSleepTime, "Maximum random sleep time between every download");
            this.numMaxSleepTime.ValueChanged += new System.EventHandler(this.numMaxSleepTime_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Max Sleep Time: ";
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(134, 96);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(46, 13);
            this.lblDelay.TabIndex = 18;
            this.lblDelay.Text = "Delay: 0";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            this.toolTip.StripAmpersands = true;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 290);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.numMaxSleepTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numMaxLimit);
            this.Controls.Add(this.numMinLimit);
            this.Controls.Add(this.numMinSleepTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblLimitPercent);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.labelPerc);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStartDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Text = "Nuget Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.numMinSleepTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSleepTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartDownload;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelDownloaded;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelPerc;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLimitPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMinSleepTime;
        private System.Windows.Forms.NumericUpDown numMinLimit;
        private System.Windows.Forms.NumericUpDown numMaxLimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMaxSleepTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

