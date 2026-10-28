using MediaToolkit.Model;
using MediaToolkit;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeToMP3
{
    public class Downloads
    {
        private readonly YoutubeClient youtube = new YoutubeClient();

        // Returns true if the file was downloaded and converted successfully
        public async Task<bool> DownloadAsync(string url, ProgressBar progress, string fileType, bool showCompletionMessage = true)
        {
            // Check if the URL is empty or null
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a YouTube URL.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate if the URL is a YouTube video URL (playlist links with a v= parameter are fine)
            var videoId = YoutubeExplode.Videos.VideoId.TryParse(url.Trim());
            if (videoId == null)
            {
                MessageBox.Show("Please enter a valid YouTube video URL.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string? tempPath = null;
            try
            {
                // Fetch video metadata
                var video = await youtube.Videos.GetAsync(videoId.Value);

                // Sanitize the video title to be a valid filename
                var invalidChars = Path.GetInvalidFileNameChars();
                var safeFileName = string.Join("_", video.Title.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries)).Trim();

                // Ask the user where to save the file
                string outputPath;
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = $"{fileType.ToUpper()} Files|*.{fileType}";
                    saveFileDialog.Title = $"Save {fileType.ToUpper()} File";
                    saveFileDialog.FileName = safeFileName; // Suggest a filename

                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                    outputPath = Path.ChangeExtension(saveFileDialog.FileName, fileType);
                }

                // YouTube no longer serves muxed (audio + video) streams for most videos, so grab the best audio-only stream
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId.Value);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                // Temporarily download the audio
                tempPath = Path.Combine(Path.GetTempPath(), $"{videoId}.{streamInfo.Container.Name}");

                // Initialize the progress bar
                progress.Value = 0;
                progress.Maximum = 100;

                // Create an instance of IProgress<double> to report progress
                var progressHandler = new Progress<double>(val =>
                {
                    progress.Value = Math.Clamp((int)(val * 100), 0, 100);
                });

                // Download the audio with progress reporting
                await youtube.Videos.Streams.DownloadAsync(streamInfo, tempPath, progressHandler);

                // Convert to the selected format using MediaToolkit (off the UI thread so the window stays responsive)
                var inputFile = new MediaFile { Filename = tempPath };
                var outputFile = new MediaFile { Filename = outputPath };

                await Task.Run(() =>
                {
                    using (var engine = new Engine())
                    {
                        engine.GetMetadata(inputFile);
                        engine.Convert(inputFile, outputFile);
                    }
                });

                if (!File.Exists(outputPath))
                {
                    throw new IOException("Conversion failed, no output file was created.");
                }

                if (showCompletionMessage)
                {
                    MessageBox.Show("Download complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred downloading {url}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Clean up the temporary file
                if (tempPath != null && File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
                progress.Value = 0; // Reset progress bar
            }
        }

        public void ClearInfo(TextBox urlInput, ProgressBar progress)
        {
            urlInput.Clear();
            progress.Value = 0;
        }
    }
}
