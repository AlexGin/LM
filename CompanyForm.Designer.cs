namespace LM
{
    partial class CompanyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyForm));
            this.toolStripCmpn = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnShowKeys = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemShowKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCmpn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripCmpn
            // 
            this.toolStripCmpn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnEdit,
            this.toolStripBtnSave,
            this.toolStripSeparator1,
            this.toolStripBtnShowKeys});
            this.toolStripCmpn.Location = new System.Drawing.Point(0, 0);
            this.toolStripCmpn.Name = "toolStripCmpn";
            this.toolStripCmpn.Size = new System.Drawing.Size(522, 25);
            this.toolStripCmpn.TabIndex = 0;
            this.toolStripCmpn.Text = "toolStrip1";
            // 
            // toolStripBtnEdit
            // 
            this.toolStripBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEdit.Image")));
            this.toolStripBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEdit.Name = "toolStripBtnEdit";
            this.toolStripBtnEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnEdit.Text = "Редактировать";
            this.toolStripBtnEdit.Click += new System.EventHandler(this.OnClickEditCompany);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnSave.Text = "Сохранить";
            this.toolStripBtnSave.Click += new System.EventHandler(this.OnClickSaveCompany);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnShowKeys
            // 
            this.toolStripBtnShowKeys.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnShowKeys.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnShowKeys.Image")));
            this.toolStripBtnShowKeys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnShowKeys.Name = "toolStripBtnShowKeys";
            this.toolStripBtnShowKeys.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnShowKeys.Text = "Показать список ключей организации";
            this.toolStripBtnShowKeys.Click += new System.EventHandler(this.OnClickKeysForCompany);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(522, 236);
            this.dataGridView1.TabIndex = 1;
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "dbo.SelectCommand1";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "dbo.InsertCommand1";
            this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.VarChar, 0, "CompanyName"),
            new System.Data.SqlClient.SqlParameter("@DocumentNumber", System.Data.SqlDbType.VarChar, 0, "DocumentNumber"),
            new System.Data.SqlClient.SqlParameter("@LimitOfKeys", System.Data.SqlDbType.Int, 0, "LimitOfKeys")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = "dbo.UpdateCommand1";
            this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.VarChar, 0, "CompanyName"),
            new System.Data.SqlClient.SqlParameter("@DocumentNumber", System.Data.SqlDbType.VarChar, 0, "DocumentNumber"),
            new System.Data.SqlClient.SqlParameter("@LimitOfKeys", System.Data.SqlDbType.Int, 0, "LimitOfKeys"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentNumber", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_LimitOfKeys", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LimitOfKeys", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, "ID")});
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "dbo.DeleteCommand1";
            this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_DocumentNumber", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DocumentNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_LimitOfKeys", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LimitOfKeys", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SelectCommand1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
                        new System.Data.Common.DataColumnMapping("DocumentNumber", "DocumentNumber"),
                        new System.Data.Common.DataColumnMapping("LimitOfKeys", "LimitOfKeys")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=AlexGin-PC;Initial Catalog=LicenseManager;Persist Security Info=True;" +
    "User ID=sa";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemSave,
            this.toolStripMenuItem1,
            this.toolStripMenuItemShowKeys});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 76);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(212, 22);
            this.toolStripMenuItemEdit.Text = "Редактировать";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.OnClickEditCompany);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(212, 22);
            this.toolStripMenuItemSave.Text = "Сохранить";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.OnClickSaveCompany);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // toolStripMenuItemShowKeys
            // 
            this.toolStripMenuItemShowKeys.Name = "toolStripMenuItemShowKeys";
            this.toolStripMenuItemShowKeys.Size = new System.Drawing.Size(212, 22);
            this.toolStripMenuItemShowKeys.Text = "Показать список ключей";
            this.toolStripMenuItemShowKeys.Click += new System.EventHandler(this.OnClickKeysForCompany);
            // 
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 261);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStripCmpn);
            this.Name = "CompanyForm";
            this.Text = "Организации";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnCompanyClosed);
            this.Load += new System.EventHandler(this.OnLoadCompany);
            this.toolStripCmpn.ResumeLayout(false);
            this.toolStripCmpn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripCmpn;
        private System.Windows.Forms.ToolStripButton toolStripBtnEdit;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnShowKeys;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowKeys;

    }
}