using System.Diagnostics;
using System.Net;
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
        private readonly Version _version = Assembly.GetExecutingAssembly().GetName().Version;
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

        private async void downloadButton_ClickAsync(object sender, EventArgs e)
        {
            string fileType = "";

            if (mp3Radio.Checked)
            {
                fileType = "mp3"; // Define your file type for radioButton1
            }
            else if (opusRadio.Checked)
            {
                fileType = "ogg"; // Define your file type for radioButton2
            }
            else if (aacRadio.Checked)
            {
                fileType = "aac"; // Define your file type for radioButton3
            }

            List<string> urls = new List<string>();
            foreach (var item in urlListBox.Items)
            {
                urls.Add(item.ToString());
            }

            int VideoNumber = -1;
            foreach (var url in urls)
            {
                VideoNumber++;
                await download.DownloadAsync(url, progressBar, fileType, VideoNumber, fileBox.Text, nameBox.Text);
            }

            MessageBox.Show("All downloads complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string latestReleaseUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/latest";
            string json;

            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("User-Agent", "request"); // GitHub API requires a user-agent
                json = wc.DownloadString(latestReleaseUrl);
            }

            var release = JsonConvert.DeserializeObject<dynamic>(json);
            string latestVersion = release.tag_name;
            string downloadUrl = release.assets[0].browser_download_url;

            if (Version.Parse(latestVersion) > Version.Parse(currentVersion))
            {
                if (MessageBox.Show($"Update available: {latestVersion}\nDo you want to download it?", "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(downloadUrl) { UseShellExecute = true });
                }
            }
            else
            {
                MessageBox.Show("Your application is up to date.");
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

        private void downloadSingleButton_Click(object sender, EventArgs e)
        {
            string fileType = "";

            if (mp3Radio.Checked)
            {
                fileType = "mp3"; // Define your file type for radioButton1
            }
            else if (opusRadio.Checked)
            {
                fileType = "ogg"; // Define your file type for radioButton2
            }
            else if (aacRadio.Checked)
            {
                fileType = "aac"; // Define your file type for radioButton3
            }

            // Check if the thumbnail should be downloaded
            bool downloadThumbnail = thumbnailCheckbox.Checked;

            // Call the download method with the selected file type and thumbnail option
            download.DownloadAsync(urlBox.Text, progressBar, fileType, 0, fileBox.Text, nameBox.Text);


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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}