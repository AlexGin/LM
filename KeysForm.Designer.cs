namespace LM
{
    partial class KeysForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeysForm));
            this.toolStripKeys = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnKeyGener = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnKeyGenChild = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnKeyHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnKeyDelete = new System.Windows.Forms.ToolStripButton();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemKeyGener = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGeyGenChild = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemKeyHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripKeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripKeys
            // 
            this.toolStripKeys.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnKeyGener,
            this.toolStripBtnKeyGenChild,
            this.toolStripSeparator1,
            this.toolStripBtnKeyHistory,
            this.toolStripSeparator2,
            this.toolStripBtnKeyDelete});
            this.toolStripKeys.Location = new System.Drawing.Point(0, 0);
            this.toolStripKeys.Name = "toolStripKeys";
            this.toolStripKeys.Size = new System.Drawing.Size(959, 25);
            this.toolStripKeys.TabIndex = 0;
            this.toolStripKeys.Text = "toolStrip1";
            // 
            // toolStripBtnKeyGener
            // 
            this.toolStripBtnKeyGener.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnKeyGener.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnKeyGener.Image")));
            this.toolStripBtnKeyGener.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnKeyGener.Name = "toolStripBtnKeyGener";
            this.toolStripBtnKeyGener.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnKeyGener.Text = "Генерация ключа (начального)";
            this.toolStripBtnKeyGener.Click += new System.EventHandler(this.OnClickKeyGenerator);
            // 
            // toolStripBtnKeyGenChild
            // 
            this.toolStripBtnKeyGenChild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnKeyGenChild.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnKeyGenChild.Image")));
            this.toolStripBtnKeyGenChild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnKeyGenChild.Name = "toolStripBtnKeyGenChild";
            this.toolStripBtnKeyGenChild.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnKeyGenChild.Text = "Продление срока (генерировать повторный)";
            this.toolStripBtnKeyGenChild.Click += new System.EventHandler(this.OnClickKeyGenerChild);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnKeyHistory
            // 
            this.toolStripBtnKeyHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnKeyHistory.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnKeyHistory.Image")));
            this.toolStripBtnKeyHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnKeyHistory.Name = "toolStripBtnKeyHistory";
            this.toolStripBtnKeyHistory.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnKeyHistory.Text = "История ключа";
            this.toolStripBtnKeyHistory.Click += new System.EventHandler(this.OnClickKeyHistory);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnKeyDelete
            // 
            this.toolStripBtnKeyDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnKeyDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnKeyDelete.Image")));
            this.toolStripBtnKeyDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnKeyDelete.Name = "toolStripBtnKeyDelete";
            this.toolStripBtnKeyDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnKeyDelete.Text = "Удалить";
            this.toolStripBtnKeyDelete.Click += new System.EventHandler(this.OnClickKeyDelete);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.ContextMenuStrip = this.contextMenuStrip3;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 25);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(959, 252);
            this.dataGridView3.TabIndex = 1;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemKeyGener,
            this.toolStripMenuItemGeyGenChild,
            this.toolStripMenuItem1,
            this.toolStripMenuItemKeyHistory,
            this.toolStripMenuItem2,
            this.toolStripMenuItemDelete});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(323, 104);
            // 
            // toolStripMenuItemKeyGener
            // 
            this.toolStripMenuItemKeyGener.Name = "toolStripMenuItemKeyGener";
            this.toolStripMenuItemKeyGener.Size = new System.Drawing.Size(322, 22);
            this.toolStripMenuItemKeyGener.Text = "Генерация ключа (начального)";
            this.toolStripMenuItemKeyGener.Click += new System.EventHandler(this.OnClickKeyGenerator);
            // 
            // toolStripMenuItemGeyGenChild
            // 
            this.toolStripMenuItemGeyGenChild.Name = "toolStripMenuItemGeyGenChild";
            this.toolStripMenuItemGeyGenChild.Size = new System.Drawing.Size(322, 22);
            this.toolStripMenuItemGeyGenChild.Text = "Продление срока (генерировать повторный)";
            this.toolStripMenuItemGeyGenChild.Click += new System.EventHandler(this.OnClickKeyGenerChild);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(319, 6);
            // 
            // toolStripMenuItemKeyHistory
            // 
            this.toolStripMenuItemKeyHistory.Name = "toolStripMenuItemKeyHistory";
            this.toolStripMenuItemKeyHistory.Size = new System.Drawing.Size(322, 22);
            this.toolStripMenuItemKeyHistory.Text = "История ключа";
            this.toolStripMenuItemKeyHistory.Click += new System.EventHandler(this.OnClickKeyHistory);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(319, 6);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(322, 22);
            this.toolStripMenuItemDelete.Text = "Удалить";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.OnClickKeyDelete);
            // 
            // KeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 277);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.toolStripKeys);
            this.Name = "KeysForm";
            this.Text = "Ключи";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnKeysClosed);
            this.Load += new System.EventHandler(this.OnLoadKeys);
            this.toolStripKeys.ResumeLayout(false);
            this.toolStripKeys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripKeys;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.ToolStripButton toolStripBtnKeyGener;
        private System.Windows.Forms.ToolStripButton toolStripBtnKeyGenChild;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnKeyDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemKeyGener;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGeyGenChild;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripButton toolStripBtnKeyHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemKeyHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}