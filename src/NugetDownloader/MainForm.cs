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
        private readonly Random _rand = new Random();
        int _limitPercent; //1%
        private int _counter;
        WebClient _webClient;               // Our WebClient that will be doing the downloading for us
        readonly Stopwatch _sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        private static CancellationTokenSource _cts;

        public MainForm()
        {
            InitializeComponent();

            _cts = new CancellationTokenSource();
        }



        private async void btnStartDownload_Click(object sender, EventArgs e)
        {
            if (_cts.IsCancellationRequested) _cts = new CancellationTokenSource();
            var temp = Path.GetTempFileName();

            var delay = _rand.Next((int)numMinSleepTime.Value, (int)numMaxSleepTime.Value);

            await SeedDelay(delay, _cts);

            _limitPercent = _rand.Next((int)numMinLimit.Value, (int)numMaxLimit.Value);
            lblLimitPercent.Text = $@"/ {_limitPercent}%";


            using (_webClient = new WebClient())
            {
                _webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                var url = new Uri(textBox1.Text);

                // Start the stopwatch which we will be using to calculate the download speed
                _sw.Restart();

                try
                {
                    // Start downloading the file
                    _webClient.DownloadFileAsync(url, temp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            lblCounter.Text = (++_counter).ToString();
        }


        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            labelSpeed.Text = $"{(e.BytesReceived / 1024d / _sw.Elapsed.TotalSeconds).ToString("0.00")} kb/s";

            // Update the progressbar percentage only when the value is not the same.
            progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            labelPerc.Text = e.ProgressPercentage + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text =
                $"{(e.BytesReceived / 1024d / 1024d).ToString("0.00")} MB's / {(e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")} MB's";

            if (_limitPercent <= e.ProgressPercentage)
            {
                _webClient.CancelAsync();
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
            _sw.Reset();


            lblStatus.Text = e.Cancelled ? "Download has been canceled." : "Download completed!";


            if (!_cts.IsCancellationRequested)
            {
                btnStartDownload_Click(sender, e);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _cts.Cancel();
                _webClient.CancelAsync();
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
