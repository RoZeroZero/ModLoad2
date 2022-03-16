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
            string strVersions;
            while ((strVersions = reader.ReadLine()) != null)
            {
                string[] str = strVersions.Split(new char[] { '@' });
                NameBox.Items.Add(str[0].TrimEnd(' '));
            }
            DescriptionBox.Cursor = Cursors.WaitCursor;
            reader.Close();
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
                string strVersions;
                while ((strVersions = reader.ReadLine()) != null)
                {
                    string[] str = strVersions.Split(new char[] { '@' });
                    DescriptionBox.Text = str[1];
                }
                reader.Close();
            }
        }
        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Bar.Maximum = (int)e.TotalBytesToReceive / 100;
            Bar.Value = (int)e.BytesReceived / 100 == (int)e.TotalBytesToReceive / 100 ? 0 : (int)e.BytesReceived / 100;
        }
        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (Directory.Exists(pathSelected + "\\.minecraft\\versions" + pathModpack)) { Directory.Delete(pathSelected + pathModpack); }
            else 
            {
                label3.Text = "Extracting";
                ZipFile.ExtractToDirectory(pathModpack+".zip", pathSelected);
                label3.Text = "Description";
            }            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
