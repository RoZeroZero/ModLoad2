using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MinecraftDownloader_v2
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void Install_Click(object sender, EventArgs e)
        {

        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            GetVersions();
        }
        private void PathInsert_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string pathSelected = folderBrowserDialog1.SelectedPath;
            textBox1.Text = pathSelected;
        }
        private void GetVersions()
        {
            Uri pathMeta = new Uri("https://raw.github.com/RoZeroZero/modpacks-archives-meta/main/");
            string pathVersions = "versions.txt";
            WebClient client = new WebClient();
            client.DownloadFile((pathMeta+pathVersions), pathVersions);
            NameBox.Items.Clear();
            StreamReader reader = new StreamReader(pathVersions);
            string strVersions;
            while ((strVersions = reader.ReadLine()) != null)
            {
                string[] str = strVersions.Split(new char[] { '@' });
                NameBox.Items.Add(str[0]);
            }
            DescriptionBox.Cursor = Cursors.WaitCursor;
            reader.Close();
        }
        private void NameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DescriptionBox.Cursor = NameBox.SelectedIndex >= 0 ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
