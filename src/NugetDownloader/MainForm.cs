using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NugetDownloader
{
    public partial class MainForm : Form
    {
        private int LimitPercent { get; set; } //1%
        private int Counter { get; set; }
        private WebClient WebClient { get; set; } // Our WebClient that will be doing the downloading for us
        private Stopwatch Sw { get; } = new Stopwatch(); // The stopwatch which we will be using to calculate the download speed
        private Random Rand { get; } = new Random();
        private CancellationTokenSource Cts { get; set; } = new CancellationTokenSource();

        public MainForm()
        {
            InitializeComponent();
            Cts.Cancel();

            numMinLimit.ValueChanged += (s, e) =>
            {
                if (numMinLimit.Value > numMaxLimit.Value)
                    numMaxLimit.Value = numMinLimit.Value;
            };

            numMaxLimit.ValueChanged += (s, e) =>
            {
                if (numMinLimit.Value > numMaxLimit.Value)
                    numMinLimit.Value = numMaxLimit.Value;
            };

            numMaxSleepTime.ValueChanged += (s, e) =>
            {
                if (numMinSleepTime.Value > numMaxSleepTime.Value)
                    numMinSleepTime.Value = numMaxSleepTime.Value;
            };

            numMinSleepTime.ValueChanged += (s, e) =>
            {
                if (numMinSleepTime.Value > numMaxSleepTime.Value)
                    numMaxSleepTime.Value = numMinSleepTime.Value;
            };
        }


        private async void btnStartDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cts.IsCancellationRequested) // Start
                {
                    Cts = new CancellationTokenSource();
                    Cts.Token.Register(() =>
                    {
                        lblStatus.Text = @"Cancelled";
                        btnStartStop.Text = @"Start";
                    }, true);
                    await Start();
                }
                else // Stop
                {
                    Cts?.Cancel();
                    WebClient?.CancelAsync();
                }
            }
            catch (Exception exp)
            {
                Cts?.Cancel();
                lblStatus.Text = exp.Message;
            }
        }

        private async Task Start()
        {
            var temp = Path.GetTempFileName();
            btnStartStop.SetPropertyValue(x => x.Text, @"Stop");

            var delay = Rand.Next((int)numMinSleepTime.Value, (int)numMaxSleepTime.Value);
            await SeedDelay(delay, Cts);

            LimitPercent = Rand.Next((int)numMinLimit.Value, (int)numMaxLimit.Value);
            lblLimitPercent.SetPropertyValue(x => x.Text, $@"/ {LimitPercent}%");

            using (WebClient = new WebClient())
            {
                WebClient.DownloadFileCompleted += Completed;
                WebClient.DownloadProgressChanged += ProgressChanged;

                // The variable that will be holding the url address (making sure it starts with http://)
                var url = new Uri(txtUrl.Text);

                // Start the stopwatch which we will be using to calculate the download speed
                Sw.Restart();

                try
                {
                    // Start downloading the file
                    WebClient.DownloadFileAsync(url, temp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            lblCounter.Text = (++Counter).ToString();
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            labelSpeed.SetPropertyValue(x => x.Text, $@"{(e.BytesReceived / 1024d / Sw.Elapsed.TotalSeconds):0.00} kb/s");

            // Update the progressbar percentage only when the value is not the same.
            progressBar.SetPropertyValue(x => x.Value, e.ProgressPercentage);

            // Show the percentage on our label.
            labelPerc.SetPropertyValue(x => x.Text, $@"{e.ProgressPercentage}%");

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.SetPropertyValue(x => x.Text,
                $@"{(e.BytesReceived / 1024d / 1024d):0.00} MB's / {(e.TotalBytesToReceive / 1024d / 1024d):0.00} MB's");

            if (LimitPercent <= e.ProgressPercentage)
                WebClient.CancelAsync();
        }

        private async Task SeedDelay(int delay, CancellationTokenSource cts)
        {
            while (delay-- > 0 && !cts.Token.IsCancellationRequested)
            {
                await Task.Delay(1000);
                lblDelay.SetPropertyValue(x => x.Text, $@"Delay: {delay}");
            }
        }

        // The event that will trigger when the WebClient is completed
        private async void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            Sw.Reset();
            lblStatus.SetPropertyValue(x => x.Text, @"Download Completed");

            if (!Cts.IsCancellationRequested)
                await Start();
        }
    }
}