namespace MinecraftDownloader_v2
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Install = new System.Windows.Forms.Button();
            this.PathInsert = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.Bar = new System.Windows.Forms.ProgressBar();
            this.NameBox = new System.Windows.Forms.ListBox();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Install
            // 
            resources.ApplyResources(this.Install, "Install");
            this.Install.Name = "Install";
            this.Install.UseVisualStyleBackColor = true;
            this.Install.Click += new System.EventHandler(this.Install_Click);
            // 
            // PathInsert
            // 
            resources.ApplyResources(this.PathInsert, "PathInsert");
            this.PathInsert.Name = "PathInsert";
            this.PathInsert.UseVisualStyleBackColor = true;
            this.PathInsert.Click += new System.EventHandler(this.PathInsert_Click);
            // 
            // Refresh
            // 
            resources.ApplyResources(this.Refresh, "Refresh");
            this.Refresh.Name = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Bar
            // 
            resources.ApplyResources(this.Bar, "Bar");
            this.Bar.Name = "Bar";
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.SystemColors.Menu;
            this.NameBox.FormattingEnabled = true;
            resources.ApplyResources(this.NameBox, "NameBox");
            this.NameBox.Name = "NameBox";
            this.NameBox.SelectedIndexChanged += new System.EventHandler(this.NameBox_SelectedIndexChanged);
            // 
            // PathBox
            // 
            resources.ApplyResources(this.PathBox, "PathBox");
            this.PathBox.Name = "PathBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Name = "label1";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BackColor = System.Drawing.SystemColors.Menu;
            this.DescriptionBox.CausesValidation = false;
            this.DescriptionBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.DescriptionBox, "DescriptionBox");
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // MainWindow
            // 
            this.AcceptButton = this.Install;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.Bar);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.PathInsert);
            this.Controls.Add(this.Install);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Install;
        private System.Windows.Forms.Button PathInsert;

        private new System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.ProgressBar Bar;

        private System.Windows.Forms.ListBox NameBox;

        private System.Windows.Forms.TextBox PathBox;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Panel panel1;
    }
}

