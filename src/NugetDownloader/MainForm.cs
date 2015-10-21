using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace NugetDownloader
{
    public partial class MainForm : Form
    {
        private Random rand = new Random();
        int _limitPercent; //1%
        private int counter = 0;
        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        private static CancellationTokenSource CTS;

        public MainForm()
        {
            InitializeComponent();

            CTS = new CancellationTokenSource();
        }



        private async void btnStartDownload_Click(object sender, EventArgs e)
        {
            if(CTS.IsCancellationRequested) CTS = new CancellationTokenSource();

            var delay = rand.Next((int)numMinSleepTime.Value, (int)numMaxSleepTime.Value);

            await SeedDelay(delay, CTS);

            _limitPercent = rand.Next((int)numMinLimit.Value, (int)numMaxLimit.Value);
            lblLimitPercent.Text = string.Format(@"/ {0}%", _limitPercent);


            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = new Uri(textBox1.Text);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Restart();

                try
                {
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, @"D:\nuget.test");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            lblCounter.Text = (++counter).ToString();
        }


        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            labelPerc.Text = e.ProgressPercentage + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));

            if (_limitPercent <= e.ProgressPercentage)
            {
                webClient.CancelAsync();
            }
        }


        private async Task SeedDelay(int delay, CancellationTokenSource cts)
        {
            while (delay-- > 0 && !cts.Token.IsCancellationRequested)
            {
                await Task.Delay(1000);

                lblDelay.Invoke(new Action(() =>
                {
                    lblDelay.Text = "Delay: " + delay;
                }));
            }
        }


        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();


            lblStatus.Text = e.Cancelled ? "Download has been canceled." : "Download completed!";


            if (!CTS.IsCancellationRequested)
            {
                btnStartDownload_Click(sender, e);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                CTS.Cancel();
                webClient.CancelAsync();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void numMinLimit_ValueChanged(object sender, EventArgs e)
        {
            if (numMinLimit.Value > numMaxLimit.Value)
                numMaxLimit.Value = numMinLimit.Value;
        }

        private void numMaxLimit_ValueChanged(object sender, EventArgs e)
        {
            if (numMinLimit.Value > numMaxLimit.Value)
                numMinLimit.Value = numMaxLimit.Value;
        }

        private void numMaxSleepTime_ValueChanged(object sender, EventArgs e)
        {
            if (numMinSleepTime.Value > numMaxSleepTime.Value)
                numMinSleepTime.Value = numMaxSleepTime.Value;
        }

        private void numMinSleepTime_ValueChanged(object sender, EventArgs e)
        {
            if (numMinSleepTime.Value > numMaxSleepTime.Value)
                numMaxSleepTime.Value = numMinSleepTime.Value;
        }
    }
}
