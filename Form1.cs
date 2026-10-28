using System.Diagnostics;
using MediaToolkit.Model;
using MediaToolkit;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using Newtonsoft.Json;
using System.Reflection;

namespace YoutubeToMP3
{
    public partial class Form1 : Form
    {
        private readonly Version _version = Assembly.GetExecutingAssembly().GetName().Version ?? new Version(1, 0);
        private string repoOwner = "PackJC"; // Replace with your GitHub username
        private string repoName = "YoutubeToMP3"; // Replace with your repository name
        string currentVersion;

        Downloads download = new Downloads();
        public Form1()
        {
            InitializeComponent();
            progressBar.Value = 0;
            currentVersion = _version.ToString();

        }

        private string GetSelectedFileType()
        {
            if (opusRadio.Checked)
            {
                return "ogg";
            }
            if (aacRadio.Checked)
            {
                return "aac";
            }
            return "mp3";
        }

        // Prevent starting another download while one is in progress
        private void SetBusy(bool busy)
        {
            downloadButton.Enabled = !busy;
            downloadSingleButton.Enabled = !busy;
            addButton.Enabled = !busy;
            button1.Enabled = !busy;
            clearButton.Enabled = !busy;
        }

        private async void downloadButton_ClickAsync(object sender, EventArgs e)
        {
            if (urlListBox.Items.Count == 0)
            {
                MessageBox.Show("Add at least one URL to the list first.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileType = GetSelectedFileType();
            List<string> urls = urlListBox.Items.Cast<object>().Select(item => item.ToString() ?? "").ToList();

            SetBusy(true);
            int succeeded = 0;
            try
            {
                foreach (var url in urls)
                {
                    if (await download.DownloadAsync(url, progressBar, fileType, showCompletionMessage: false))
                    {
                        succeeded++;
                    }
                }
            }
            finally
            {
                SetBusy(false);
            }

            MessageBox.Show($"{succeeded} of {urls.Count} downloads complete!", "Finished", MessageBoxButtons.OK,
                succeeded == urls.Count ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            download.ClearInfo(urlBox, progressBar);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutBox1();
            aboutForm.Show();

        }

        private async void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string latestReleaseUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/latest";

            try
            {
                string json;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("YoutubeToMP3"); // GitHub API requires a user-agent
                    json = await client.GetStringAsync(latestReleaseUrl);
                }

                var release = JsonConvert.DeserializeObject<dynamic>(json);
                string latestVersion = ((string)release!.tag_name).TrimStart('v', 'V');
                string? downloadUrl = release.assets.Count > 0 ? (string)release.assets[0].browser_download_url : (string)release.html_url;

                if (Version.TryParse(latestVersion, out var latest) && latest > Version.Parse(currentVersion))
                {
                    if (MessageBox.Show($"Update available: {latestVersion}\nDo you want to download it?", "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(downloadUrl!) { UseShellExecute = true });
                    }
                }
                else
                {
                    MessageBox.Show("Your application is up to date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not check for updates:\n{ex.Message}", "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            urlBox.Text = string.Empty;
            urlListBox.Items.Clear();
            thumbnailCheckbox.Checked = false;
            mp3Radio.Checked = true;
        }
        private bool isDarkMode = false;

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDarkMode)
            {
                ApplyLightMode();
                darkModeToolStripMenuItem.Text = "Dark Mode";
            }
            else
            {
                ApplyDarkMode();
                darkModeToolStripMenuItem.Text = "Light Mode";
            }

            isDarkMode = !isDarkMode;
        }

        private void ApplyDarkMode()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            foreach (Control control in this.Controls)
            {
                ApplyDarkModeToControl(control);
            }
        }

        private void ApplyLightMode()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            foreach (Control control in this.Controls)
            {
                ApplyLightModeToControl(control);
            }
        }
        private void ApplyDarkModeToControl(Control control)
        {
            if (control is Button button)
            {
                control.BackColor = Color.Transparent;
                control.ForeColor = Color.Black;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 58); // Darker shade for hover effect
                button.FlatAppearance.MouseDownBackColor = Color.FromArgb(65, 65, 68); // Even darker shade for click effect

            }
            else if (control is TextBox || control is ComboBox)
            {
                control.BackColor = Color.FromArgb(51, 51, 55);
                control.ForeColor = Color.White;
            }
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.FromArgb(45, 45, 48);
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(51, 51, 55);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 28);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            else if (control is ProgressBar progressBar)
            {
                progressBar.BackColor = Color.FromArgb(28, 28, 28);
                progressBar.ForeColor = Color.White;
                progressBar.Style = ProgressBarStyle.Continuous;

            }
            else
            {
                control.BackColor = Color.FromArgb(45, 45, 48);
                control.ForeColor = Color.White;
            }

            foreach (Control childControl in control.Controls)
            {
                ApplyDarkModeToControl(childControl);
            }
        }

        private void ApplyLightModeToControl(Control control)
        {
            if (control is Button button)
            {
                control.BackColor = Color.Transparent;
                control.ForeColor = Color.Black;

                button.FlatAppearance.MouseOverBackColor = Color.LightGray; // Darker shade for hover effect
                button.FlatAppearance.MouseDownBackColor = Color.Gray; // Even darker shade for click effect

            }
            else if (control is TextBox || control is ComboBox)
            {
                control.BackColor = Color.White;
                control.ForeColor = Color.Black;
            }
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.White;
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }
            else if (control is ProgressBar progressBar)
            {
                progressBar.BackColor = Color.White;
                progressBar.ForeColor = Color.Black;
                progressBar.Style = ProgressBarStyle.Continuous;
            }
            else
            {
                control.BackColor = Color.White;
                control.ForeColor = Color.Black;
            }

            foreach (Control childControl in control.Controls)
            {
                ApplyLightModeToControl(childControl);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Validate and add the URL from urlBox to urlListBox and clear urlBox
            string url = urlBox.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a YouTube URL.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate if the URL is a YouTube URL
            try
            {
                var uri = new Uri(url);
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

            // Add the valid URL to the urlListBox
            urlListBox.Items.Add(url);
            urlBox.Clear();

        }

        private async void downloadSingleButton_Click(object sender, EventArgs e)
        {
            string fileType = GetSelectedFileType();

            SetBusy(true);
            try
            {
                if (await download.DownloadAsync(urlBox.Text, progressBar, fileType))
                {
                    urlBox.Clear();
                }
            }
            finally
            {
                SetBusy(false);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if any item is selected
            if (urlListBox.SelectedIndex != -1)
            {
                urlListBox.Items.RemoveAt(urlListBox.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }

        }
    }
}