namespace LM
{
    partial class LMMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.tolStripMenuItemDevices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUserMan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCompany,
            this.tolStripMenuItemDevices,
            this.toolStripMenuItemKeys,
            this.toolStripMenuItemSearch,
            this.historyToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.toolStripMenuItemExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1021, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemCompany
            // 
            this.toolStripMenuItemCompany.Name = "toolStripMenuItemCompany";
            this.toolStripMenuItemCompany.Size = new System.Drawing.Size(92, 20);
            this.toolStripMenuItemCompany.Text = "Организации";
            this.toolStripMenuItemCompany.Click += new System.EventHandler(this.OnClickCompany);
            // 
            // tolStripMenuItemDevices
            // 
            this.tolStripMenuItemDevices.Name = "tolStripMenuItemDevices";
            this.tolStripMenuItemDevices.Size = new System.Drawing.Size(81, 20);
            this.tolStripMenuItemDevices.Text = "Устройства";
            this.tolStripMenuItemDevices.Click += new System.EventHandler(this.OnClickDevices);
            // 
            // toolStripMenuItemKeys
            // 
            this.toolStripMenuItemKeys.Name = "toolStripMenuItemKeys";
            this.toolStripMenuItemKeys.Size = new System.Drawing.Size(57, 20);
            this.toolStripMenuItemKeys.Text = "Ключи";
            this.toolStripMenuItemKeys.Click += new System.EventHandler(this.OnClickKeys);
            // 
            // toolStripMenuItemSearch
            // 
            this.toolStripMenuItemSearch.Name = "toolStripMenuItemSearch";
            this.toolStripMenuItemSearch.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItemSearch.Text = "Поиск";
            this.toolStripMenuItemSearch.Click += new System.EventHandler(this.OnClickSearch);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.historyToolStripMenuItem.Text = "История";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.OnClickHistory);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout,
            this.toolStripMenuItemUserMan});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(226, 22);
            this.toolStripMenuItemAbout.Text = "О Программе...";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.OnClickAbout);
            // 
            // toolStripMenuItemUserMan
            // 
            this.toolStripMenuItemUserMan.Name = "toolStripMenuItemUserMan";
            this.toolStripMenuItemUserMan.Size = new System.Drawing.Size(226, 22);
            this.toolStripMenuItemUserMan.Text = "Руководство Пользователя ";
            this.toolStripMenuItemUserMan.Click += new System.EventHandler(this.OnClickUserMan);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(53, 20);
            this.toolStripMenuItemExit.Text = "Выход";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.OnClickExit);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1021, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(122, 17);
            this.toolStripStatusLabel1.Text = "Нет соединения с БД";
            // 
            // LMMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 418);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LMMainForm";
            this.Text = "License Manager (2016)";
            this.Activated += new System.EventHandler(this.OnActivatedMainForm);
            this.Load += new System.EventHandler(this.OnLoadMainForm);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCompany;
        private System.Windows.Forms.ToolStripMenuItem tolStripMenuItemDevices;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemKeys;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUserMan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSearch;
    }
}

