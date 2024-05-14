using MediaToolkit.Model;
using MediaToolkit;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;


namespace YoutubeToMP3
{
    public partial class Form1 : Form
    {
        Downloads download = new Downloads();
        public Form1()
        {
            InitializeComponent();
              progressBar.Value = 0;
           
        }

        private async void downloadButton_ClickAsync(object sender, EventArgs e)
        {
            download.DownloadAsync(urlBox.Text, progressBar);
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

        }
    }
}