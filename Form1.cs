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

            // Check if the thumbnail should be downloaded
            bool downloadThumbnail = thumbnailCheckbox.Checked;

            // Call the download method with the selected file type and thumbnail option
            download.DownloadAsync(urlBox.Text, progressBar, fileType);
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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string latestVersion = release.tag_name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
            urlListBox.Text = string.Empty;
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
            if (control is Button)
            {
                control.BackColor = Color.Transparent;
                control.ForeColor = Color.Black;
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

    }
}