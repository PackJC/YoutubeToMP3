using MediaToolkit.Model;
using MediaToolkit;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void downloadButton_ClickAsync(object sender, EventArgs e)
        {
            progressBar.Value = 0;

            // Check if the URL TextBox is empty or null
            if (string.IsNullOrWhiteSpace(urlBox.Text))
            {
                MessageBox.Show("Please enter a YouTube URL.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validate if the URL is a YouTube URL
            try
            {
                var uri = new Uri(urlBox.Text);
                var host = uri.Host.ToLower();
                if (!host.Contains("youtube.com") && !host.Contains("youtu.be"))
                {
                    MessageBox.Show("Please enter a valid YouTube URL.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid YouTube URL.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Initialize YoutubeExplode client and fetch video metadata
            var youtube = new YoutubeClient();
            var videoId = YoutubeExplode.Videos.VideoId.Parse(urlBox.Text);
            var video = await youtube.Videos.GetAsync(videoId);
            var videoTitle = video.Title;

            // Sanitize the video title to be a valid filename
            var invalidChars = Path.GetInvalidFileNameChars();
            var safeFileName = string.Join("_", videoTitle.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries)).Trim();

            // Use SaveFileDialog to ask the user where to save the MP3 file
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "MP3 Files|*.mp3";
                saveFileDialog.Title = "Save MP3 File";
                saveFileDialog.FileName = safeFileName; // Suggest a filename

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Process the URL and download the video
                    try
                    {
                        // Get the stream manifest and select the best muxed stream (audio + video)
                        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
                        var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

                        // Temporarily download the video
                        var videoPath = Path.Combine(Path.GetTempPath(), $"{videoId}.mp4");

                        // Initialize the progress bar
                        progressBar.Value = 0;
                        progressBar.Maximum = 100;

                        // Create an instance of IProgress<double> to report progress
                        var progressHandler = new Progress<double>(progress =>
                        {
                            // Update progress bar on the UI thread
                            Invoke((MethodInvoker)delegate
                            {
                                progressBar.Value = (int)(progress * 100);
                            });
                        });

                        // Download the video with progress reporting
                        await youtube.Videos.Streams.DownloadAsync(streamInfo, videoPath, progressHandler);

                        // Convert to MP3 using MediaToolkit
                        var inputFile = new MediaFile { Filename = videoPath };
                        var outputFile = new MediaFile { Filename = saveFileDialog.FileName };

                        using (var engine = new Engine())
                        {
                            engine.GetMetadata(inputFile);
                            engine.Convert(inputFile, outputFile);
                        }

                        // Clean up the temporary video file
                        File.Delete(videoPath);

                        // Update UI and show completion message
                        MessageBox.Show("Download complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        urlBox.Text = string.Empty;
                        progressBar.Value = 0; // Reset progress bar after completion

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        progressBar.Value = 0; // Reset progress bar in case of error
                    }
                }
            }




        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            urlBox.Clear();
            progressBar.Value = 0;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutBox1();
            aboutForm.Show();

        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}