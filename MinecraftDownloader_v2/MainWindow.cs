using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace MinecraftDownloader_v2
{
    public partial class MainWindow : Form
    {
        string pathSelected = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\versions";
        readonly string pathMain = "https://github.com/RoZeroZero/modpacks-archives-meta/raw/main/";
        readonly string pathVersions = "versions.txt";
        string pathModpack;
        string strVersions;

        public MainWindow() => InitializeComponent();
        private void MainWindow_Load(object sender, EventArgs e)
        {
            PathBox.Text = pathSelected;
        }
        private void Install_Click(object sender, EventArgs e)
        {
            if  (NameBox.SelectedIndex>=0)
            {
                pathModpack = (string)NameBox.SelectedItem;
                WebClient client = new WebClient();
                label3.Text = "Downloading...";
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(pathMain + pathModpack + ".zip"), pathModpack+".zip");
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            DescriptionBox.Text = "";
            WebClient client = new WebClient();
            client.DownloadFile(pathMain+pathVersions, pathVersions);
            NameBox.Items.Clear();
            StreamReader reader = new StreamReader(pathVersions);            
            while ((strVersions = reader.ReadLine()) != null)
            {
                string[] str = strVersions.Split(new char[] { '@' });
                NameBox.Items.Add(str[0]);
            }
            reader.Close();
            FlashWindow.Flash(this);
        }
        private void PathInsert_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.ApplicationData; ;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            pathSelected = folderBrowserDialog1.SelectedPath;
            PathBox.Text = pathSelected;
        }
        private void NameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NameBox.SelectedIndex != -1)
            {
                DescriptionBox.Cursor = NameBox.SelectedIndex >= 0 ? Cursors.Default : Cursors.WaitCursor;
                StreamReader reader = new StreamReader(pathVersions);
                while ((strVersions = reader.ReadLine()) != null)
                {
                    string[] str = strVersions.Split(new char[] { '@' });
                    if (str[0] == (string)NameBox.SelectedItem)
                    {
                        DescriptionBox.Text = str[1];
                    }
                }
                reader.Close();
            }
        }
        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            int totalBytes = (int)e.TotalBytesToReceive / 100;           
            int receivedBytes = (int)e.BytesReceived / 100;
            Bar.Maximum = totalBytes;
            Bar.Value = receivedBytes == totalBytes ? 0 : receivedBytes;
            TaskbarProgress.SetValue(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle, (receivedBytes == totalBytes ? 0 : receivedBytes), totalBytes);
        }
        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (Directory.Exists(pathSelected + "\\" + pathModpack)) 
            {
                label3.Text = "Directory exists. Deleting...";
                Directory.Delete(pathSelected + "\\" + pathModpack, true); 
            }
            ZipFile.ExtractToDirectory(pathModpack + ".zip", pathSelected);
            label3.Text = "Description";
            FlashWindow.Flash(this);
        }
    }
}
