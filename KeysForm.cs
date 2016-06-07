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
    public partial class KeysForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BindingSource _bs;
        private DataSet _dsKeys;

        private Dictionary<int, string> _dictCompanyNames;
        private List<string> _listCompanyNames; // Using as dataSource for DataGridViewComboBoxColumn (colCombo)

        private Dictionary<int, List<string>> _dictDeviceCodes; // Key - as IDCOMPANY (in the dbo.Devices)
        private Dictionary<int, string> _dictCodes; // Key - as ID (in the dbo.Devices)

        private KeyFilter _keyFilter;
        private LMMainForm _mainForm;
        public KeysForm(LMMainForm mainForm, KeyFilter keyFilter=null)
        {
            try
            {
                _keyFilter = keyFilter;
                _mainForm = mainForm;
                InitializeComponent();                
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.KeysForm - {0}", ex.Message);
            }
        }

        private void OnLoadKeys(object sender, EventArgs e)
        {
            try
            {
                _dictCompanyNames = new Dictionary<int, string>();
                _listCompanyNames = new List<string>();
                LMMainForm.PrepareDictionary(_dictCompanyNames, _listCompanyNames);

                _dictDeviceCodes = new Dictionary<int, List<string>>();
                _dictCodes = new Dictionary<int, string>();
                PrepareDeviceCodes(_dictDeviceCodes, _dictCodes);

                DataTable tTable = new DataTable("tblKeys");

                DataColumn clID = new DataColumn("ID", typeof(int));
                DataColumn clIDCOMPANY = new DataColumn("IDCOMPANY", typeof(int));
                DataColumn clCompanyName = new DataColumn("CompanyName", typeof(string)); 
                DataColumn clIDDEVICE = new DataColumn("IDDEVICE", typeof(int));
                DataColumn clDeviceCode = new DataColumn("DeviceCode", typeof(string)); 
                DataColumn clIDPARENTKEY = new DataColumn("IDPARENTKEY", typeof(int));
                DataColumn clSecondKey = new DataColumn("SecondKey", typeof(string));
                DataColumn clValueOfKey = new DataColumn("ValueOfKey", typeof(string));
                DataColumn clStartDate = new DataColumn("StartDate", typeof(System.DateTime));
                DataColumn clEndDate = new DataColumn("EndDate", typeof(System.DateTime));
                DataColumn clValidCheckBox = new DataColumn("ValidCheckBox", typeof(bool)); // Column for replace
                DataColumn clFlagOfTest = new DataColumn("FlagOfTest", typeof(short));
                DataColumn clTestCheckBox = new DataColumn("TestCheckBox", typeof(bool)); // Column for replace
                DataColumn clIssueDate = new DataColumn("IssueDate", typeof(System.DateTime));
                DataColumn clFNameOfOwner = new DataColumn("FNameOfOwner", typeof(string));
                DataColumn clPositionOfOwner = new DataColumn("PositionOfOwner", typeof(string));
                
                tTable.Columns.Add(clID);
                tTable.Columns.Add(clIDCOMPANY);
                tTable.Columns.Add(clCompanyName);
                tTable.Columns.Add(clIDDEVICE);
                tTable.Columns.Add(clDeviceCode);
                tTable.Columns.Add(clIDPARENTKEY);
                tTable.Columns.Add(clSecondKey);
                tTable.Columns.Add(clValueOfKey);
                tTable.Columns.Add(clStartDate);
                tTable.Columns.Add(clEndDate);
                tTable.Columns.Add(clValidCheckBox);
                tTable.Columns.Add(clFlagOfTest);
                tTable.Columns.Add(clTestCheckBox);
                tTable.Columns.Add(clIssueDate);
                tTable.Columns.Add(clFNameOfOwner);
                tTable.Columns.Add(clPositionOfOwner);

                _dsKeys = new DataSet("dsKeys");
                _dsKeys.Tables.Add(tTable);

                _bs = new BindingSource(_dsKeys, "tblKeys");

                dataGridView3.DataSource = _bs;
                RefreshKeysGrid(true, _keyFilter);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.OnLoadKeys - {0}", ex.Message);
            }
        }

        private void FillKeysTable(DataTable tTable, KeyFilter kfr=null)
        {
            try
            {   /*
                string strSQL = "SELECT Keys.ID, Devices.IDCOMPANY, Company.CompanyName, IDDEVICE, Devices.CodeOfKey as DeviceCode, IDPARENTKEY, ValueOfKey, " +
                    "StartDate, EndDate, FlagOfTest, IssueDate, Devices.FNameOfOwner, Devices.PositionOfOwner " +
                    "FROM Keys " +
                    "INNER JOIN Devices ON Keys.IDDEVICE = Devices.ID " +
                    "INNER JOIN Company ON Devices.IDCOMPANY = Company.ID"; 
                 
                SqlCommand cmd = new SqlCommand(strSQL, _mainForm.SqlConnection2); */ // It's also OK (if kfr==null)
                SqlCommand cmd = null;
                if (kfr != null)
                {
                    cmd = new SqlCommand("SP_SHOWKEYS2", _mainForm.SqlConnection2);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = kfr.IDKey;
                    cmd.Parameters.Add("@IDCOMPANY", SqlDbType.Int).Value = kfr.IDCompany;
                    cmd.Parameters.Add("@IDDEVICE", SqlDbType.Int).Value = kfr.IDDevice;
                    cmd.Parameters.Add("@IDPARENTKEY", SqlDbType.Int).Value = kfr.IDParentKey;
                    cmd.Parameters.Add("@VALIDKEY", SqlDbType.Int).Value = kfr.ValidKeyMode;
                    cmd.Parameters.Add("@FNameOfOwner", SqlDbType.VarChar, 128).Value = kfr.FNameOfOwner; 
                }
                else // if (kfr == null) - filter is not present:
                {
                    cmd = new SqlCommand("SP_SHOWKEYS1", _mainForm.SqlConnection2);
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int iKeysId = reader.GetInt32(0);
                    int iIDCompany = reader.GetInt32(1);
                    string strCompanyName = reader.GetString(2);
                    int iIDDevice = reader.GetInt32(3);
                    string strDeviceCode = reader.GetString(4);
                    int iIDParentKey = 0;
                    if (!reader.IsDBNull(5))
                        iIDParentKey = reader.GetInt32(5);
                    string strValueOfKey = reader.GetString(6);
                    DateTime dtStartDate = reader.GetDateTime(7);
                    DateTime dtEndDate = reader.GetDateTime(8);
                    short nFlagOfTest = reader.GetInt16(9);
                    bool bFlagOfTest = (bool)(1 == nFlagOfTest);
                    DateTime dtIssueDate = DateTime.MinValue;
                    if (!reader.IsDBNull(10))
                        dtIssueDate = reader.GetDateTime(10);
                    string strFNameOfOwner = reader.GetString(11);
                    string strPositionOfOwner = reader.GetString(12);
                    DateTime dtNow = DateTime.Now;
                    bool bValidKey = (bool)((dtStartDate <= dtNow) && (dtNow <= dtEndDate));

                    DataRow dr = tTable.NewRow();
                    dr.BeginEdit();
                    dr["ID"] = iKeysId;
                    dr["IDCOMPANY"] = iIDCompany;
                    dr["CompanyName"] = strCompanyName;
                    dr["IDDEVICE"] = iIDDevice;
                    dr["DeviceCode"] = strDeviceCode;
                    dr["IDPARENTKEY"] = iIDParentKey;
                    if (0 == iIDParentKey)
                        dr["SecondKey"] = "-";
                    else
                        dr["SecondKey"] = iIDParentKey.ToString();
                    dr["ValueOfKey"] = strValueOfKey;
                    dr["StartDate"] = dtStartDate;
                    dr["EndDate"] = dtEndDate;
                    dr["ValidCheckBox"] = bValidKey; 
                    dr["FlagOfTest"] = nFlagOfTest;                    
                    dr["TestCheckBox"] = bFlagOfTest;
                    dr["IssueDate"] = dtIssueDate;
                    dr["FNameOfOwner"] = strFNameOfOwner;
                    dr["PositionOfOwner"] = strPositionOfOwner;
                    dr.EndEdit();
                    tTable.Rows.Add(dr);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.RefreshKeysGrid - {0}", ex.Message);
            }
        }

        private void RefreshKeysGrid(bool bFirstPass, KeyFilter kfr)
        {
            try
            {
                DataTable tTable = _dsKeys.Tables["tblKeys"];
                // sqlDataAdapter1.Fill(_dsKeys, "tblKeys");
                FillKeysTable(tTable, kfr);
                
                if (bFirstPass)
                {
                    DataGridViewCheckBoxColumn columnCb1 = new DataGridViewCheckBoxColumn();
                    {
                        columnCb1.DataPropertyName = "ValidCheckBox";
                        columnCb1.HeaderText = "CheckBoxColumn1";
                        columnCb1.FlatStyle = FlatStyle.Standard;
                        // columnCb2.Width = 100;
                        columnCb1.ThreeState = true;
                        columnCb1.CellTemplate = new DataGridViewCheckBoxCell();
                        columnCb1.CellTemplate.Style.BackColor = Color.Beige;
                    }
                    dataGridView3.Columns.Remove("ValidCheckBox");
                    dataGridView3.Columns.Insert(10, columnCb1);

                    DataGridViewCheckBoxColumn columnCb2 = new DataGridViewCheckBoxColumn();
                    {
                        columnCb2.DataPropertyName = "TestCheckBox";
                        columnCb2.HeaderText = "CheckBoxColumn2";
                        columnCb2.FlatStyle = FlatStyle.Standard;
                        // columnCb2.Width = 100;
                        columnCb2.ThreeState = true;
                        columnCb2.CellTemplate = new DataGridViewCheckBoxCell();
                        columnCb2.CellTemplate.Style.BackColor = Color.Beige;
                    }
                    dataGridView3.Columns.Remove("TestCheckBox");
                    dataGridView3.Columns.Insert(12, columnCb2);
                }                

                // Rename 'HeaderText' ONLY via dataGridView!!!
                // DO NOT using dataSet/dataTable for this action!!!
                int iIndex = 0;
                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    switch (iIndex)
                    {
                        case 0: column.Width = 45;
                            column.HeaderText = "N п/п";
                            break;
                        case 1: column.Visible = false; // Hide "IDCOMPANY" column                          
                            break;
                        case 2: column.Width = 115;
                            column.HeaderText = "Название организации";
                            break;
                        case 3: column.Visible = false; // Hide "IDDEVICE" column                            
                            break;
                        case 4: column.Width = 65;
                            column.HeaderText = "Код устройства";
                            break;
                        case 5: column.Visible = false; // Hide "IDPARENTKEY" column                            
                            break;
                        case 6: column.Width = 70;
                            column.HeaderText = "Предшеств.";
                            break;
                        case 7: column.Width = 90;
                            column.HeaderText = "Значение ключа";
                            break;
                        case 8: column.Width = 75;
                            column.HeaderText = "Начальная дата";
                            break;
                        case 9: column.Width = 75;
                            column.HeaderText = "Конечная дата";
                            break;
                        case 10: column.Width = 75;
                            column.HeaderText = "Действует";
                            break;
                        case 11: column.Visible = false; // Hide "FlagOfTest" column                      
                            break;
                        case 12: column.Width = 75;
                            column.HeaderText = "Тестовый";
                            break;
                        case 13: column.Width = 75;
                            column.HeaderText = "Дата выпуска";
                            break;
                        case 14: column.Width = 95;
                            column.HeaderText = "Фамилия владельца";
                            break;
                        case 15: column.Width = 95;
                            column.HeaderText = "Должность владельца";
                            break;
                    }
                    iIndex++;
                }
                dataGridView3.ReadOnly = true;
                dataGridView3.AllowUserToAddRows = false;
                dataGridView3.RowHeadersVisible = false;

                // toolStripBtnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.RefreshKeysGrid - {0}", ex.Message);
            }
        }

        private int RetrieveIdDevice(string strCodeOfKey)
        {   
            try
            {                
                string strSQL = "SELECT ID FROM Devices WHERE CodeOfKey=@varCodeOfKey";

                SqlCommand sqlCom = new SqlCommand(strSQL, _mainForm.SqlConnection2);

                sqlCom.Parameters.Clear();
                sqlCom.Parameters.Add("@varCodeOfKey", SqlDbType.VarChar, 32).Value = strCodeOfKey; 

                object o = sqlCom.ExecuteScalar();
                int iResult = Convert.ToInt32(o);
                return iResult;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.RetrieveIdDevice - {0}", ex.Message);
                return (-1);
            }
        }

        private bool RetrieveCodeOfKey(int iIDDevice, ref string strCodeOfKey)
        {
            try
            {
                string strSQL = "SELECT CodeOfKey FROM Devices WHERE ID=@varID";

                SqlCommand sqlCom = new SqlCommand(strSQL, _mainForm.SqlConnection2);

                sqlCom.Parameters.Clear();
                sqlCom.Parameters.Add("@varID", SqlDbType.Int).Value = iIDDevice;

                object o = sqlCom.ExecuteScalar();
                strCodeOfKey = o.ToString();

                return true;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.RetrieveCodeOfKey - {0}", ex.Message);
                return false;
            }
        }
        
        private int PrepareDeviceCodes(Dictionary<int, List<string>> dict, Dictionary<int, string> dictCodes)
        {
            int iResult = 0;
            string strSQL = "SELECT ID, IDCOMPANY, CodeOfKey FROM Devices";
            SqlCommand cmd = new SqlCommand(strSQL, _mainForm.SqlConnection2);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int iId = reader.GetInt32(0);
                int iCompanyId = reader.GetInt32(1);
                string strCodeOfKey = reader.GetString(2);
                dictCodes[iId] = strCodeOfKey;

                if (!dict.ContainsKey(iCompanyId))
                {
                    dict.Add(iCompanyId, new List<string>());
                    dict[iCompanyId].Add(strCodeOfKey);
                }

                List<string> list = dict[iCompanyId];
                if (list != null)
                {
                    if (null == list.Find(x => x == strCodeOfKey)) // Add in list, if value is not exist 
                        list.Add(strCodeOfKey);
                }
                else // this branch - never call
                {
                    dict[iCompanyId] = new List<string>();
                    dict[iCompanyId].Add(strCodeOfKey);
                }                
                iResult++;
            }
            reader.Close();
            return iResult;
        }

        private void PrepareHistoryListByID(List<int> list, int iID, bool bDesc = false)
        {
            string strSQL;
            if (bDesc) // ORDER BY ID ASC"; // ORDER BY ID DESC";
                strSQL = "SELECT ID, IDPARENTKEY FROM Keys ORDER BY ID DESC";  
            else
                strSQL = "SELECT ID, IDPARENTKEY FROM Keys ORDER BY ID ASC";
            SqlCommand cmd = new SqlCommand(strSQL, _mainForm.SqlConnection2);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int iIDKey = reader.GetInt32(0); // Current key
                int iIDParentKey = 0;
                if (!reader.IsDBNull(1))
                    iIDParentKey = reader.GetInt32(1);
                if ((iID == iIDKey) || (iID == iIDParentKey))
                {
                    if (0 == list.Find(x => x == iIDKey))
                        if (iIDKey > 0)
                            list.Add(iIDKey);
                    if (0 == list.Find(x => x == iIDParentKey))
                        if (iIDParentKey > 0)
                            list.Add(iIDParentKey);                    
                }
                else
                {
                    if ( (0 != list.Find(x => x == iIDParentKey)) && (0 == list.Find(x => x == iIDKey)) )
                        if (iIDKey > 0)
                            list.Add(iIDKey);
                    if ( (0 != list.Find(x => x == iIDKey)) && (0 == list.Find(x => x == iIDParentKey)) )
                        if (iIDParentKey > 0)
                            list.Add(iIDParentKey);
                }
            }
            reader.Close();
        }
        
        private void OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {   // Button (in cell) clicked! See:
            // http://stackoverflow.com/questions/3577297/how-to-handle-click-event-in-button-column-in-datagridview
            try
            {            
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {   //TODO - Button Clicked - Execute Code Here  
                  
                    /* if (dataGridView3.ReadOnly)
                    {
                        string str = "Для изменения кода устройства - следует перейти в режим редактирования.";
                        MessageBox.Show(str, "License Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    } */ 
                    /* DataTable tTable = _dsKeys.Tables["tblKeys"];
                    DataRow dr = tTable.Rows[e.RowIndex];
                    string strCompanyName = dr["CompanyName"].ToString();
                    string strIdCompany = dr["IDCOMPANY"].ToString();
                    int iCompanyId = Convert.ToInt32(strIdCompany);
                    List<string> lst = this._dictDeviceCodes[iCompanyId];
                    DevCompSelectForm dsf = new DevCompSelectForm(strCompanyName, lst);
                    if (dsf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string str = dsf.Result;
                        int iRow = e.RowIndex;
                        int iCol = e.ColumnIndex;
                        dataGridView3.Rows[iRow].Cells[iCol].Value = str;
                        dataGridView3.UpdateCellValue(iCol, iRow);
                    } */ 
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.OnCellContentClick - {0}", ex.Message);
            }
        }

        private void OnClickKeyDelete(object sender, EventArgs e)
        {
            try
            {
                int iSelRow = dataGridView3.CurrentCell.RowIndex;
                string strID = dataGridView3.Rows[iSelRow].Cells[0].Value.ToString();
                int iID = Convert.ToInt32(strID);

                string strCompanyName = dataGridView3.Rows[iSelRow].Cells[2].Value.ToString();

                string strOut = string.Format("Удалить выбранный ключ для организации '{0}'?", strCompanyName);
                int iRes = (int)MessageBox.Show(strOut, "License Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (((int)DialogResult.Yes) != iRes)
                    return;

                DeleteKeyRecord(iID);

                DataTable tTable = _dsKeys.Tables["tblKeys"];
                tTable.Rows.Clear();

                RefreshKeysGrid(false, _keyFilter);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.OnClickKeyDelete - {0}", ex.Message);
            }
        }

        private void OnClickKeyHistory(object sender, EventArgs e)
        {
            try
            {
                int iSelRow = dataGridView3.CurrentCell.RowIndex;
                string strID = dataGridView3.Rows[iSelRow].Cells[0].Value.ToString();
                int iID = Convert.ToInt32(strID);

                List<int> list = new List<int>();
                PrepareHistoryListByID(list, iID); // Ascending
                PrepareHistoryListByID(list, iID, true); // Descending
                KeyHistoryForm history = new KeyHistoryForm(_mainForm, list);
                history.ShowDialog();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.OnClickKeyHistory - {0}", ex.Message);
            }
        }     

        private void OnClickKeyGenerChild(object sender, EventArgs e)
        {
            try
            {
                int iSelRow = dataGridView3.CurrentCell.RowIndex;
                string strParentKey = dataGridView3.Rows[iSelRow].Cells[0].Value.ToString();
                int iParentKey = Convert.ToInt32(strParentKey);

                string strCompanyId = dataGridView3.Rows[iSelRow].Cells[1].Value.ToString();
                int iCompanyId = Convert.ToInt32(strCompanyId);

                string strCompanyName = dataGridView3.Rows[iSelRow].Cells[2].Value.ToString();
                string strDeviceCode = dataGridView3.Rows[iSelRow].Cells[4].Value.ToString();

                LMMainForm.PrepareDictionary(_dictCompanyNames, _listCompanyNames);

                PrepareDeviceCodes(_dictDeviceCodes, _dictCodes);

                KeyGenPrepareForm kgpf = new KeyGenPrepareForm(_dictCompanyNames, _dictDeviceCodes, iParentKey);
                kgpf.IDCompany = iCompanyId;
                kgpf.ResultCompany = strCompanyName;
                kgpf.ResultDeviceCode = strDeviceCode;
                if (kgpf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Key generating:
                    // int iIDCompany = kgpf.IDCompany;                    
                    int iIDDevice = RetrieveIdDevice(strDeviceCode);

                    short nFlagOfTest = kgpf.TestKeyFlag ? ((short)1) : ((short)0);

                    Key k = new Key(iIDDevice);
                    k.ID = -1; // ID generate automatically
                    k.FlagOfTest = nFlagOfTest;
                    k.IssueDate = kgpf.DTIssueDate; // DateTime.Now; 
                    k.StartDate = kgpf.DTStartDate; // DateTime.Now; 
                    // TimeSpan ts = new TimeSpan(365, 0, 0, 0);
                    // DateTime dtEnd = DateTime.Now + ts;
                    k.EndDate = kgpf.DTEndDate; // dtEnd; 
                    k.IDParentKey = iParentKey;
                    k.KeyGenerate();

                    string s1 = "";
                    if (!ReasonStore(strCompanyName, ref s1, iParentKey))
                        return;

                    int iIDKey = InsertKeyRecord(k);
                    InsertKeyHistoryRecord(iIDKey, DateTime.Now, s1);
                    
                    DataTable tTable = _dsKeys.Tables["tblKeys"];
                    tTable.Rows.Clear();

                    RefreshKeysGrid(false, _keyFilter);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.OnClickKeyGenerChild - {0}", ex.Message);
            }
        }   

        private void OnClickKeyGenerator(object sender, EventArgs e)
        {
            try
            {
                LMMainForm.PrepareDictionary(_dictCompanyNames, _listCompanyNames);

                PrepareDeviceCodes(_dictDeviceCodes, _dictCodes);

                KeyGenPrepareForm kgpf = new KeyGenPrepareForm(_dictCompanyNames, _dictDeviceCodes);
                if (kgpf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Key generating:
                    int iIDCompany = kgpf.IDCompany;
                    string sCompanyName = kgpf.ResultCompany;

                    string strDeviceCode = kgpf.ResultDeviceCode;
                    int iIDDevice = RetrieveIdDevice(strDeviceCode);

                    short nFlagOfTest = kgpf.TestKeyFlag ? ((short)1) : ((short)0);
                    if (0 == nFlagOfTest)
                    {   // If it is NOT Test-key:
                        int iLimitOfKeys = LMMainForm.GetLimitOfKeys(iIDCompany);
                        int iExistKeys = RetrieveExistKeysForCompany(iIDCompany);
                        if (iExistKeys >= iLimitOfKeys)
                        {
                            string strCompanyName = kgpf.ResultCompany;
                            string strOut = 
                                string.Format("Превышение лимита ключей для компании '{0}'! Действие отменено!", strCompanyName);
                            MessageBox.Show(strOut, "License Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    Key k = new Key(iIDDevice);
                    k.ID = -1; // ID generate automatically
                    k.FlagOfTest = nFlagOfTest;
                    k.IssueDate = kgpf.DTIssueDate; // DateTime.Now; 
                    k.StartDate = kgpf.DTStartDate; // DateTime.Now; 
                    // TimeSpan ts = new TimeSpan(365, 0, 0, 0);
                    // DateTime dtEnd = DateTime.Now + ts;
                    k.EndDate = kgpf.DTEndDate; // dtEnd; 
                    k.KeyGenerate();

                    string s1 = "";
                    ReasonStore(sCompanyName, ref s1);

                    int iIDKey = InsertKeyRecord(k);
                    InsertKeyHistoryRecord(iIDKey, DateTime.Now, s1);

                    DataTable tTable = _dsKeys.Tables["tblKeys"];
                    tTable.Rows.Clear();

                    RefreshKeysGrid(false, _keyFilter);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.OnClickKeyGenerator - {0}", ex.Message);
            }
        }

        private bool ReasonStore(string strCompanyName, ref string strReason, int iIDKey=-1)
        {
            if (-1 != iIDKey)
            {
                ReasonKeyForm rkf = new ReasonKeyForm();
                if (rkf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string strReasonStore = string.Format("Генерация нового ключа компании '{0}' (взаман старого '{1}')",
                        strCompanyName, iIDKey);
                    _mainForm.HistoryWrite(strReasonStore);
                    _mainForm.HistoryWrite(rkf.TextOfReason);
                    strReason = rkf.TextOfReason;
                    return true;
                }
                MessageBox.Show("Генерация Ключа отменена", "License Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                string strReasonStore = string.Format("Генерация нового ключа компании '{0}')", strCompanyName);
                _mainForm.HistoryWrite(strReasonStore);
                return true;
            }
        }

        private bool DeleteKeyRecord(int iID)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SP_DELETEKEY", _mainForm.SqlConnection2);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = iID;

                int iCount = sqlCommand.ExecuteNonQuery();
                if (1 == iCount)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.DeleteKeyRecord - {0}", ex.Message);
                return false;
            }
        }

        private bool InsertKeyHistoryRecord(int iIDKey, DateTime dtDateOfAction, string strTextOfReason)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SP_INSERTHISTKEY", _mainForm.SqlConnection2);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("@IDKEY", SqlDbType.Int).Value = iIDKey;
                sqlCommand.Parameters.Add("@DateOfAction", SqlDbType.DateTime, 8).Value = dtDateOfAction;
                sqlCommand.Parameters.Add("@TextOfReason", SqlDbType.VarChar, 512).Value = strTextOfReason; 
                
                int iCount = sqlCommand.ExecuteNonQuery();
                if (1 == iCount)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.InsertKeyHistoryRecord - {0}", ex.Message);
                return false;
            }
        }

        private int InsertKeyRecord(Key key)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SP_INSERTKEY", _mainForm.SqlConnection2);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("@IDDEVICE", SqlDbType.Int).Value = key.IDDevice;
                sqlCommand.Parameters.Add("@IDPARENTKEY", SqlDbType.Int).Value = key.IDParentKey;
                sqlCommand.Parameters.Add("@ValueOfKey", SqlDbType.VarChar, 64).Value = key.ValueOfKey;
                sqlCommand.Parameters.Add("@StartDate", SqlDbType.DateTime, 8).Value = key.StartDate;
                sqlCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 8).Value = key.EndDate;
                sqlCommand.Parameters.Add("@FlagOfTest", SqlDbType.SmallInt).Value = key.FlagOfTest;
                sqlCommand.Parameters.Add("@IssueDate", SqlDbType.DateTime, 8).Value = key.IssueDate;

                object objRes = sqlCommand.ExecuteScalar();
                int iResult = Convert.ToInt32(objRes);
                return iResult; // Return new Keys.ID
                // see (OUTPUT Inserted.ID):
                // http://stackoverflow.com/questions/7917695/sql-server-return-value-after-insert
                // for "SP_INSERTKEY" in "LicenseManager" database
                // In OLD version:
                /* int iCount = sqlCommand.ExecuteNonQuery();
                if (1 == iCount)
                    return true;
                else
                    return false; */ 
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.InsertKeyRecord - {0}", ex.Message);
                return -1; // Error occur
            }
        }

        private int RetrieveExistKeysForCompany(int iIDCompany)
        {   // see: "ADO.NET CookBook" page 90: DataReaderRowCountForm.cs
            try
            {
                int iResult = -1; // Error flag
                SqlCommand cmd = new SqlCommand("SP_KEYSFORCOMPANY", _mainForm.SqlConnection2);
                                    
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@IDCOMPANY", SqlDbType.Int).Value = iIDCompany;
                cmd.Parameters.Add("@RowCount", SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();

                object objResult = cmd.Parameters["@RowCount"].Value;
                iResult = Convert.ToInt32(objResult);

                return iResult;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeysForm.RetrieveExistKeysForCompany - {0}", ex.Message);
                return -1; // Error flag
            }
        }

        private void OnKeysClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.KeysFormClosed();
        }                            
    }
}
