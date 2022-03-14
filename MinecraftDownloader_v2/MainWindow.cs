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
        private void Cancel_Click(object sender, EventArgs e)
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
            //Uri pathMeta = new Uri("https://wdfiles.ru/folder/8343/modpacks/meta");
            Uri pathMeta = new Uri("https://wdfiles.ru/f12966");
            string pathVersions = "versions.txt";
            WebClient client = new WebClient();
            client.DownloadFile(pathMeta, pathVersions);
            StreamReader reader = new StreamReader(pathVersions);
            string strVersions = reader.ReadToEnd();
            listBox1.Items.Clear();
            listBox1.Items.Add(strVersions);
            reader.Close();
        }
    }
}
