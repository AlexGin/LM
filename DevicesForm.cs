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
    public partial class DevicesForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private BindingSource _bs;
        private DataSet _dsDevices;
        private Dictionary<int, string> _dictCompanyNames;
        private List<string> _listCompanyNames; // Using as dataSource for DataGridViewComboBoxColumn (colCombo)
        private LMMainForm _mainForm;
        public DevicesForm(LMMainForm mainForm)
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
                log.ErrorFormat("DevicesForm.DevicesForm - {0}", ex.Message);   
            }
        }

        private void OnLoadDevices(object sender, EventArgs e)
        {
            try
            {
                _dictCompanyNames = new Dictionary<int,string>();
                _listCompanyNames = new List<string>();
                LMMainForm.PrepareDictionary(_dictCompanyNames, _listCompanyNames);

                DataTable tTable = new DataTable("tblDevices");
                
                DataColumn clID = new DataColumn("ID", typeof(int));
                DataColumn clIDCOMPANY = new DataColumn("IDCOMPANY", typeof(int));
                DataColumn clCompanyName = new DataColumn("CompanyName",  typeof(string)); // Column for replace
                DataColumn clCodeOfKey = new DataColumn("CodeOfKey", typeof(string));
                DataColumn clFNameOfOwner = new DataColumn("FNameOfOwner", typeof(string));
                DataColumn clPositionOfOwner = new DataColumn("PositionOfOwner", typeof(string));
               
                tTable.Columns.Add(clID);
                tTable.Columns.Add(clIDCOMPANY);
                tTable.Columns.Add(clCompanyName);
                tTable.Columns.Add(clCodeOfKey);
                tTable.Columns.Add(clFNameOfOwner);
                tTable.Columns.Add(clPositionOfOwner);

                _dsDevices = new DataSet("dsDevices");
                _dsDevices.Tables.Add(tTable);
                
                _bs = new BindingSource(_dsDevices, "tblDevices");

                dataGridView2.DataSource = _bs;
                sqlDataAdapter1.Fill(_dsDevices, "tblDevices");
                
                // see:
                // https://social.msdn.microsoft.com/Forums/windows/en-US/abb7be97-0a44-4e18-98bf-687a723645a9/combo-box-inside-datagridview-using-datatable?forum=winformsdatacontrols

                DataGridViewComboBoxColumn colCombo = new DataGridViewComboBoxColumn();
                {
                    colCombo.DataPropertyName = "CompanyName";
                    colCombo.HeaderText = "ComboBoxColumn";
                    colCombo.DropDownWidth = 250;
                    colCombo.Width = 90;
                    colCombo.MaxDropDownItems = _listCompanyNames.Count;
                    colCombo.FlatStyle = FlatStyle.Flat;
                    colCombo.DataSource = _listCompanyNames; 
                    // colCombo.ValueMember = "CompanyName";
                    // colCombo.DisplayMember = colCombo.ValueMember;
                    colCombo.ValueType = typeof(string);
                }
                dataGridView2.Columns.Remove("CompanyName");
                dataGridView2.Columns.Insert(2, colCombo);
                               
                foreach (DataRow dr in tTable.Rows)
                {
                    string strIdCompany = dr["IDCOMPANY"].ToString();
                    int iCompanyId = Convert.ToInt32(strIdCompany);
                    dr["CompanyName"] = _dictCompanyNames[iCompanyId];                   
                }
                // Rename 'HeaderText' ONLY via dataGridView!!!
                // DO NOT using dataSet/dataTable for this action!!!
                int iIndex = 0;
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    switch (iIndex)
                    {
                        case 0: column.Width = 45;
                            column.HeaderText = "N п/п";
                            break;
                        case 1: column.Visible = false; // Hide "IDCOMPANY" column                          
                            break;
                        case 2: column.Width = 175;
                            column.HeaderText = "Название организации";
                            break;
                        case 3: column.Width = 65;
                            column.HeaderText = "Код устройства";
                            break;
                        case 4: column.Width = 135;
                            column.HeaderText = "Фамилия владельца";
                            break;
                        case 5: column.Width = 135;
                            column.HeaderText = "Должность владельца";
                            break;
                    }
                    iIndex++;
                } 
                dataGridView2.ReadOnly = true;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.RowHeadersVisible = false;

                toolStripBtnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("DevicesForm.OnLoadDevices - {0}", ex.Message);
            }
        }
        
        private void OnClickEditDevices(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.ReadOnly)
                {
                    LMMainForm.PrepareDictionary(_dictCompanyNames, _listCompanyNames);

                    dataGridView2.ReadOnly = false;
                    dataGridView2.AllowUserToAddRows = true;
                    dataGridView2.RowHeadersVisible = true;

                    toolStripBtnEdit.Enabled = false;
                    toolStripBtnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("DevicesForm.OnClickEditDevices - {0}", ex.Message);
            }
        }

        private void OnClickSaveDevices(object sender, EventArgs e)
        {
            try
            {
                if (!dataGridView2.ReadOnly)
                {   
                    sqlDataAdapter1.Update(_dsDevices, "tblDevices");

                    dataGridView2.ReadOnly = true;
                    dataGridView2.AllowUserToAddRows = false;
                    dataGridView2.RowHeadersVisible = false;

                    toolStripBtnEdit.Enabled = true;
                    toolStripBtnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("DevicesForm.OnClickSaveDevices - {0}", ex.Message);
            }
        }

        private void OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex >= 0)
                {
                    int iRow = e.RowIndex;
                    int iCol = e.ColumnIndex;
                    if (2 == iCol) // Column with combo-box (DataGridViewComboBoxColumn colCombo)
                    {
                        DataGridViewCell cell = dataGridView2.Rows[iRow].Cells[iCol];
                        string str = cell.Value.ToString();
                        int iKey = 0;
                        foreach (KeyValuePair<int, string> kvp in this._dictCompanyNames)
                        {
                            if (kvp.Value == str)
                            {
                                iKey = kvp.Key;
                                break;
                            }
                        }
                        if (iKey != 0)
                        {
                            dataGridView2.Rows[iRow].Cells[1].Value = iKey; // Cells[1]: index '1' - index of "IDCOMPANY"
                            dataGridView2.UpdateCellValue(1, iRow);
                            dataGridView2.UpdateCellValue(iCol, iRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("DevicesForm.OnCellValueChanged - {0}", ex.Message);
            }
        }

        private void OnClickKeyDevice(object sender, EventArgs e)
        {
            try
            {
                int iSelRow = dataGridView2.CurrentCell.RowIndex;
                string strIDDevice = dataGridView2.Rows[iSelRow].Cells[0].Value.ToString();
                int iIDDevice = Convert.ToInt32(strIDDevice);
                _mainForm.ShowKeysForDevice(iIDDevice);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("CompanyForm.OnClickKeyDevice - {0}", ex.Message);
            }
        }

        private void OnDeviceClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.DevicesFormClosed();
        }
    }
}
