namespace YoutubeToMP3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            urlBox = new TextBox();
            downloadButton = new Button();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            helpToolStripMenuItem = new ToolStripMenuItem();
            darkModeToolStripMenuItem = new ToolStripMenuItem();
            checkForUpdateToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            progressBar = new ProgressBar();
            downloadSingleButton = new Button();
            clearButton = new Button();
            urlListBox = new ListBox();
            fileTypeLabel = new Label();
            mp3Radio = new RadioButton();
            opusRadio = new RadioButton();
            pictureBox2 = new PictureBox();
            toolTip1 = new ToolTip(components);
            aacRadio = new RadioButton();
            thumbnailCheckbox = new CheckBox();
            addButton = new Button();
            button1 = new Button();
            pictureBox3 = new PictureBox();
            fileBox = new TextBox();
            nameBox = new TextBox();
            YouTubelabel = new Label();
            nameLable = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // urlBox
            // 
            urlBox.BorderStyle = BorderStyle.FixedSingle;
            urlBox.Location = new Point(59, 303);
            urlBox.Margin = new Padding(4, 5, 4, 5);
            urlBox.Name = "urlBox";
            urlBox.Size = new Size(541, 31);
            urlBox.TabIndex = 3;
            urlBox.TextChanged += urlBox_TextChanged;
            // 
            // downloadButton
            // 
            downloadButton.BackColor = Color.Transparent;
            downloadButton.FlatAppearance.BorderSize = 0;
            downloadButton.FlatStyle = FlatStyle.Flat;
            downloadButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            downloadButton.Image = (Image)resources.GetObject("downloadButton.Image");
            downloadButton.Location = new Point(667, 343);
            downloadButton.Margin = new Padding(4, 5, 4, 5);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(150, 98);
            downloadButton.TabIndex = 2;
            toolTip1.SetToolTip(downloadButton, "Download All");
            downloadButton.UseVisualStyleBackColor = false;
            downloadButton.Click += downloadButton_ClickAsync;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 40);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(374, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "YouTubeToMP3");
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(826, 34);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkModeToolStripMenuItem, checkForUpdateToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.Image = (Image)resources.GetObject("helpToolStripMenuItem.Image");
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(40, 28);
            helpToolStripMenuItem.ToolTipText = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // darkModeToolStripMenuItem
            // 
            darkModeToolStripMenuItem.Image = (Image)resources.GetObject("darkModeToolStripMenuItem.Image");
            darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            darkModeToolStripMenuItem.Size = new Size(250, 34);
            darkModeToolStripMenuItem.Text = "Dark Mode";
            darkModeToolStripMenuItem.Click += darkModeToolStripMenuItem_Click;
            // 
            // checkForUpdateToolStripMenuItem
            // 
            checkForUpdateToolStripMenuItem.Image = (Image)resources.GetObject("checkForUpdateToolStripMenuItem.Image");
            checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            checkForUpdateToolStripMenuItem.Size = new Size(250, 34);
            checkForUpdateToolStripMenuItem.Text = "Check for update";
            checkForUpdateToolStripMenuItem.Click += checkForUpdateToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Image = (Image)resources.GetObject("aboutToolStripMenuItem.Image");
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(250, 34);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.White;
            progressBar.Location = new Point(17, 510);
            progressBar.Margin = new Padding(4, 5, 4, 5);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(800, 72);
            progressBar.TabIndex = 6;
            toolTip1.SetToolTip(progressBar, "Download Progress");
            // 
            // downloadSingleButton
            // 
            downloadSingleButton.BackColor = Color.Transparent;
            downloadSingleButton.FlatAppearance.BorderSize = 0;
            downloadSingleButton.FlatStyle = FlatStyle.Flat;
            downloadSingleButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            downloadSingleButton.Image = (Image)resources.GetObject("downloadSingleButton.Image");
            downloadSingleButton.Location = new Point(691, 262);
            downloadSingleButton.Margin = new Padding(4, 5, 4, 5);
            downloadSingleButton.Name = "downloadSingleButton";
            downloadSingleButton.Size = new Size(53, 71);
            downloadSingleButton.TabIndex = 7;
            toolTip1.SetToolTip(downloadSingleButton, "Download Single");
            downloadSingleButton.UseVisualStyleBackColor = false;
            downloadSingleButton.Click += downloadSingleButton_Click;
            // 
            // clearButton
            // 
            clearButton.BackColor = Color.Transparent;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            clearButton.Image = (Image)resources.GetObject("clearButton.Image");
            clearButton.Location = new Point(752, 262);
            clearButton.Margin = new Padding(4, 5, 4, 5);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(53, 71);
            clearButton.TabIndex = 8;
            toolTip1.SetToolTip(clearButton, "Clear");
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += button2_Click;
            // 
            // urlListBox
            // 
            urlListBox.FormattingEnabled = true;
            urlListBox.ItemHeight = 25;
            urlListBox.Location = new Point(17, 343);
            urlListBox.Margin = new Padding(4, 5, 4, 5);
            urlListBox.Name = "urlListBox";
            urlListBox.Size = new Size(627, 154);
            urlListBox.TabIndex = 9;
            toolTip1.SetToolTip(urlListBox, "List of URLs");
            // 
            // fileTypeLabel
            // 
            fileTypeLabel.AutoSize = true;
            fileTypeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileTypeLabel.Location = new Point(408, 66);
            fileTypeLabel.Margin = new Padding(4, 0, 4, 0);
            fileTypeLabel.Name = "fileTypeLabel";
            fileTypeLabel.Size = new Size(121, 32);
            fileTypeLabel.TabIndex = 10;
            fileTypeLabel.Text = "File Type :";
            // 
            // mp3Radio
            // 
            mp3Radio.AutoSize = true;
            mp3Radio.Checked = true;
            mp3Radio.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            mp3Radio.Location = new Point(534, 68);
            mp3Radio.Margin = new Padding(4, 5, 4, 5);
            mp3Radio.Name = "mp3Radio";
            mp3Radio.Size = new Size(81, 32);
            mp3Radio.TabIndex = 13;
            mp3Radio.TabStop = true;
            mp3Radio.Text = ".MP3";
            toolTip1.SetToolTip(mp3Radio, "MPEG-1 Audio Layer III");
            mp3Radio.UseVisualStyleBackColor = true;
            // 
            // opusRadio
            // 
            opusRadio.AutoSize = true;
            opusRadio.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            opusRadio.Location = new Point(633, 68);
            opusRadio.Margin = new Padding(4, 5, 4, 5);
            opusRadio.Name = "opusRadio";
            opusRadio.Size = new Size(84, 32);
            opusRadio.TabIndex = 14;
            opusRadio.Text = ".OGG";
            toolTip1.SetToolTip(opusRadio, "Ogg Vorbis");
            opusRadio.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(17, 300);
            pictureBox2.Margin = new Padding(4, 5, 4, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            toolTip1.SetToolTip(pictureBox2, "URL(s)");
            // 
            // aacRadio
            // 
            aacRadio.AutoSize = true;
            aacRadio.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            aacRadio.Location = new Point(723, 68);
            aacRadio.Margin = new Padding(4, 5, 4, 5);
            aacRadio.Name = "aacRadio";
            aacRadio.Size = new Size(79, 32);
            aacRadio.TabIndex = 16;
            aacRadio.Text = ".AAC";
            toolTip1.SetToolTip(aacRadio, "Advanced Audio Coding");
            aacRadio.UseVisualStyleBackColor = true;
            // 
            // thumbnailCheckbox
            // 
            thumbnailCheckbox.AutoSize = true;
            thumbnailCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            thumbnailCheckbox.Enabled = false;
            thumbnailCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            thumbnailCheckbox.Location = new Point(408, 128);
            thumbnailCheckbox.Margin = new Padding(4, 5, 4, 5);
            thumbnailCheckbox.Name = "thumbnailCheckbox";
            thumbnailCheckbox.Size = new Size(154, 36);
            thumbnailCheckbox.TabIndex = 18;
            thumbnailCheckbox.Text = "Thumbnail";
            toolTip1.SetToolTip(thumbnailCheckbox, "Thumbnail of Video");
            thumbnailCheckbox.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            addButton.BackColor = Color.Transparent;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Image = (Image)resources.GetObject("addButton.Image");
            addButton.Location = new Point(629, 262);
            addButton.Margin = new Padding(4, 5, 4, 5);
            addButton.Name = "addButton";
            addButton.Size = new Size(53, 71);
            addButton.TabIndex = 19;
            toolTip1.SetToolTip(addButton, "Add to list");
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(667, 452);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(150, 38);
            button1.TabIndex = 20;
            button1.Text = "Remove URL";
            toolTip1.SetToolTip(button1, "Remove Selected URL");
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(17, 227);
            pictureBox3.Margin = new Padding(4, 5, 4, 5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(34, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            toolTip1.SetToolTip(pictureBox3, "URL(s)");
            // 
            // fileBox
            // 
            fileBox.BorderStyle = BorderStyle.FixedSingle;
            fileBox.Location = new Point(59, 233);
            fileBox.Margin = new Padding(4, 5, 4, 5);
            fileBox.Name = "fileBox";
            fileBox.Size = new Size(317, 31);
            fileBox.TabIndex = 1;
            // 
            // nameBox
            // 
            nameBox.BorderStyle = BorderStyle.FixedSingle;
            nameBox.Location = new Point(384, 233);
            nameBox.Margin = new Padding(4, 5, 4, 5);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(216, 31);
            nameBox.TabIndex = 2;
            nameBox.TextChanged += textBox1_TextChanged;
            // 
            // YouTubelabel
            // 
            YouTubelabel.AutoSize = true;
            YouTubelabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            YouTubelabel.Location = new Point(59, 277);
            YouTubelabel.Margin = new Padding(4, 0, 4, 0);
            YouTubelabel.Name = "YouTubelabel";
            YouTubelabel.Size = new Size(167, 21);
            YouTubelabel.TabIndex = 22;
            YouTubelabel.Text = "YouTube Video Name :";
            // 
            // nameLable
            // 
            nameLable.AutoSize = true;
            nameLable.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            nameLable.Location = new Point(224, 277);
            nameLable.Margin = new Padding(4, 0, 4, 0);
            nameLable.Name = "nameLable";
            nameLable.Size = new Size(0, 21);
            nameLable.TabIndex = 23;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 573);
            Controls.Add(nameLable);
            Controls.Add(YouTubelabel);
            Controls.Add(nameBox);
            Controls.Add(fileBox);
            Controls.Add(pictureBox3);
            Controls.Add(button1);
            Controls.Add(addButton);
            Controls.Add(thumbnailCheckbox);
            Controls.Add(aacRadio);
            Controls.Add(pictureBox2);
            Controls.Add(opusRadio);
            Controls.Add(mp3Radio);
            Controls.Add(fileTypeLabel);
            Controls.Add(urlListBox);
            Controls.Add(clearButton);
            Controls.Add(downloadSingleButton);
            Controls.Add(progressBar);
            Controls.Add(pictureBox1);
            Controls.Add(downloadButton);
            Controls.Add(urlBox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MaximumSize = new Size(848, 629);
            MinimumSize = new Size(848, 629);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YouTube → MP3, OGG, AAC";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox urlBox;
        private Button downloadButton;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ProgressBar progressBar;
        private Button downloadSingleButton;
        private Button clearButton;
        private ListBox urlListBox;
        private Label fileTypeLabel;
        private RadioButton mp3Radio;
        private RadioButton opusRadio;
        private PictureBox pictureBox2;
        private ToolTip toolTip1;
        private RadioButton aacRadio;
        private CheckBox thumbnailCheckbox;
        private ToolStripMenuItem darkModeToolStripMenuItem;
        private Button addButton;
        private Button button1;
        private PictureBox pictureBox3;
        private TextBox fileBox;
        private TextBox nameBox;
        private Label YouTubelabel;
        private Label nameLable;
    }
}