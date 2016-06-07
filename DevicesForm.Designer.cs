namespace LM
{
    partial class DevicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevicesForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnKeyDevice = new System.Windows.Forms.ToolStripButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemKeyDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnEdit,
            this.toolStripBtnSave,
            this.toolStripSeparator1,
            this.toolStripBtnKeyDevice});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(563, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnEdit
            // 
            this.toolStripBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnEdit.Image")));
            this.toolStripBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEdit.Name = "toolStripBtnEdit";
            this.toolStripBtnEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnEdit.Text = "Редактировать";
            this.toolStripBtnEdit.Click += new System.EventHandler(this.OnClickEditDevices);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnSave.Text = "Сохранить";
            this.toolStripBtnSave.Click += new System.EventHandler(this.OnClickSaveDevices);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripBtnKeyDevice
            // 
            this.toolStripBtnKeyDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnKeyDevice.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnKeyDevice.Image")));
            this.toolStripBtnKeyDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnKeyDevice.Name = "toolStripBtnKeyDevice";
            this.toolStripBtnKeyDevice.Size = new System.Drawing.Size(23, 22);
            this.toolStripBtnKeyDevice.Text = "Ключи для устройства";
            this.toolStripBtnKeyDevice.Click += new System.EventHandler(this.OnClickKeyDevice);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(563, 235);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellValueChanged);
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "dbo.SelectCommand2";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "dbo.InsertCommand2";
            this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IDCOMPANY", System.Data.SqlDbType.Int, 0, "IDCOMPANY"),
            new System.Data.SqlClient.SqlParameter("@CodeOfKey", System.Data.SqlDbType.VarChar, 0, "CodeOfKey"),
            new System.Data.SqlClient.SqlParameter("@FNameOfOwner", System.Data.SqlDbType.VarChar, 0, "FNameOfOwner"),
            new System.Data.SqlClient.SqlParameter("@PositionOfOwner", System.Data.SqlDbType.VarChar, 0, "PositionOfOwner")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = "dbo.UpdateCommand2";
            this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IDCOMPANY", System.Data.SqlDbType.Int, 0, "IDCOMPANY"),
            new System.Data.SqlClient.SqlParameter("@CodeOfKey", System.Data.SqlDbType.VarChar, 0, "CodeOfKey"),
            new System.Data.SqlClient.SqlParameter("@FNameOfOwner", System.Data.SqlDbType.VarChar, 0, "FNameOfOwner"),
            new System.Data.SqlClient.SqlParameter("@PositionOfOwner", System.Data.SqlDbType.VarChar, 0, "PositionOfOwner"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDCOMPANY", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDCOMPANY", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CodeOfKey", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CodeOfKey", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_FNameOfOwner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FNameOfOwner", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_FNameOfOwner", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FNameOfOwner", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PositionOfOwner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PositionOfOwner", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PositionOfOwner", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PositionOfOwner", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, "ID")});
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "dbo.DeleteCommand2";
            this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDCOMPANY", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDCOMPANY", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_CodeOfKey", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CodeOfKey", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_FNameOfOwner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FNameOfOwner", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_FNameOfOwner", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FNameOfOwner", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_PositionOfOwner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PositionOfOwner", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_PositionOfOwner", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PositionOfOwner", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SelectCommand2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDCOMPANY", "IDCOMPANY"),
                        new System.Data.Common.DataColumnMapping("CodeOfKey", "CodeOfKey"),
                        new System.Data.Common.DataColumnMapping("FNameOfOwner", "FNameOfOwner"),
                        new System.Data.Common.DataColumnMapping("PositionOfOwner", "PositionOfOwner")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "Data Source=localhost;Initial Catalog=LicenseManager;Persist Security Info=True;U" +
    "ser ID=sa";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemSave,
            this.toolStripMenuItem1,
            this.toolStripMenuItemKeyDevice});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(199, 76);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItemEdit.Text = "Редактировать";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.OnClickEditDevices);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItemSave.Text = "Сохранить";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.OnClickSaveDevices);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // toolStripMenuItemKeyDevice
            // 
            this.toolStripMenuItemKeyDevice.Name = "toolStripMenuItemKeyDevice";
            this.toolStripMenuItemKeyDevice.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItemKeyDevice.Text = "Ключи для устройства";
            this.toolStripMenuItemKeyDevice.Click += new System.EventHandler(this.OnClickKeyDevice);
            // 
            // DevicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 260);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DevicesForm";
            this.Text = "Устройства";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnDeviceClosed);
            this.Load += new System.EventHandler(this.OnLoadDevices);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripButton toolStripBtnEdit;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnKeyDevice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemKeyDevice;
    }
}