using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LM
{
    public partial class CompanyForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BindingSource _bs;
        private DataSet _dsCompany;

        private LMMainForm _mainForm;
        public CompanyForm(LMMainForm mainForm)
        {
            try
            {
                _mainForm = mainForm;
                InitializeComponent();
                this.sqlSelectCommand1.Connection = _mainForm.SqlConnection;
                this.sqlInsertCommand1.Connection = _mainForm.SqlConnection;
                this.sqlUpdateCommand1.Connection = _mainForm.SqlConnection;
                this.sqlDeleteCommand1.Connection = _mainForm.SqlConnection;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CompanyForm.CompanyForm - {0}", ex.Message);   
            }
        }

        private void OnLoadCompany(object sender, EventArgs e)
        {
            try
            {
                DataTable tTable = new DataTable("tblCompany");
                /* Adding these data-columns is NOT NECESSARY (columns added aumomatically during - dataAdapter.Fill)
                DataColumn clID = new DataColumn("ID", typeof(int));
                DataColumn clCompanyName = new DataColumn("CompanyName", typeof(string));
                DataColumn clDocumentNumber = new DataColumn("DocumentNumber", typeof(string));
                DataColumn clLimitOfKeys = new DataColumn("LimitOfKeys", typeof(int));
               
                tTable.Columns.Add(clID);
                tTable.Columns.Add(clCompanyName);
                tTable.Columns.Add(clDocumentNumber);
                tTable.Columns.Add(clLimitOfKeys);  */            

                _dsCompany = new DataSet("dsCompany");
                _dsCompany.Tables.Add(tTable);

                _bs = new BindingSource(_dsCompany, "tblCompany");

                dataGridView1.DataSource = _bs;
                sqlDataAdapter1.Fill(_dsCompany, "tblCompany");

                // Rename 'HeaderText' ONLY via dataGridView!!!
                // DO NOT using dataSet/dataTable for this action!!!
                int iIndex = 0;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    switch (iIndex)
                    {
                        case 0: column.Width = 45; 
                            column.HeaderText = "N п/п"; 
                            break;
                        case 1: column.Width = 237;
                            column.HeaderText = "Название";
                            break;
                        case 2: column.Width = 90;
                            column.HeaderText = "N договора";
                            break;
                        case 3: column.Width = 110;
                            column.HeaderText = "Лимит ключей";
                            break;                        
                    }                    
                    iIndex++;
                }
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersVisible = false;

                toolStripBtnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CompanyForm.OnLoadCompany - {0}", ex.Message);
            }
        }

        private void OnClickEditCompany(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.ReadOnly)
                {
                    dataGridView1.ReadOnly = false;
                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.RowHeadersVisible = true;

                    toolStripBtnEdit.Enabled = false;
                    toolStripBtnSave.Enabled = true;
                }                
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CompanyForm.OnClickEditCompany - {0}", ex.Message);
            }
        }

        private void OnClickSaveCompany(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView1.ReadOnly)
                {   // Create testing record:
                    // DataTable dt = _dsCompany.Tables["tblCompany"]; 
                    // DataRow dr = dt.NewRow();
                    // dr.BeginEdit();
                       //   dr["ID"] = 100;
                    // dr["CompanyName"] = "Братья и К"; 
                    // dr["DocumentNumber"] = "FF-1537";
                    // dr["LimitOfKeys"] = 33; 
                    // dr.EndEdit();

                    // dt.Rows.Add(dr);

                    sqlDataAdapter1.Update(_dsCompany, "tblCompany");

                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.RowHeadersVisible = false;

                    toolStripBtnEdit.Enabled = true;
                    toolStripBtnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CompanyForm.OnClickSaveCompany - {0}", ex.Message);
            }
        }

        private void OnClickKeysForCompany(object sender, EventArgs e)
        {
            try
            {
                int iSelRow = dataGridView1.CurrentCell.RowIndex;
                string strIDCompany = dataGridView1.Rows[iSelRow].Cells[0].Value.ToString();
                int iIDCompany = Convert.ToInt32(strIDCompany);
                _mainForm.ShowKeysForCompany(iIDCompany);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CompanyForm.OnClickKeysForCompany - {0}", ex.Message);
            }
        }

        private void OnCompanyClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.CompanyFormClosed();
        }
    }
}
