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
    public partial class KeyHistoryForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BindingSource _bs;
        private DataSet _dsKeyHistory; 

        private LMMainForm _mainForm;
        private List<int>  _listHistKeys; // List of IDs 
        public KeyHistoryForm(LMMainForm mainForm, List<int> listHistKeys)
        {
            try
            {
                _mainForm = mainForm;
                _listHistKeys = listHistKeys;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyHistoryForm.KeyHistoryForm - {0}", ex.Message);
            }
        }

        private void OnLoadHistory(object sender, EventArgs e)
        {
            try
            {
                if (null == _listHistKeys)
                    this.Text = "Просмотр истории по всем ключам";

                DataTable tTable = new DataTable("tblKeyHistory");

                DataColumn clID = new DataColumn("ID", typeof(int));
                DataColumn clParentKey = new DataColumn("ParentKey", typeof(string));
                DataColumn clCompanyName = new DataColumn("CompanyName", typeof(string));
                DataColumn clFNameOfOwner = new DataColumn("FNameOfOwner", typeof(string));
                DataColumn clPositionOfOwner = new DataColumn("PositionOfOwner", typeof(string));
                DataColumn clDeviceCode = new DataColumn("DeviceCode", typeof(string));
                DataColumn clTimeSpan = new DataColumn("TimeSpan", typeof(TimeSpan));
                DataColumn clDateOfAction = new DataColumn("DateOfAction", typeof(System.DateTime));
                DataColumn clTextOfReason = new DataColumn("TextOfReason", typeof(string));

                tTable.Columns.Add(clID);
                tTable.Columns.Add(clParentKey);
                tTable.Columns.Add(clCompanyName);
                tTable.Columns.Add(clFNameOfOwner);
                tTable.Columns.Add(clPositionOfOwner);
                tTable.Columns.Add(clDeviceCode);
                tTable.Columns.Add(clTimeSpan);
                tTable.Columns.Add(clDateOfAction);
                tTable.Columns.Add(clTextOfReason);

                _dsKeyHistory = new DataSet("dsKeyHistory");
                _dsKeyHistory.Tables.Add(tTable);

                _bs = new BindingSource(_dsKeyHistory, "tblKeyHistory");

                dataGridView4.DataSource = _bs;

                RefreshKeyHistoryGrid();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyHistoryForm.OnLoadHistory - {0}", ex.Message);
            }
        }

        private void RefreshKeyHistoryGrid()
        {
            try
            {
                DataTable tTable = _dsKeyHistory.Tables["tblKeyHistory"];
                if (null != this._listHistKeys)
                {
                    foreach (int iID in this._listHistKeys)
                    {
                        int iIDParent = 0;
                        string sCmpName = ""; // CompanyName
                        string sFNO = ""; // FNameOfOwner
                        string sPO = ""; // PositionOfOwner
                        string sDC = ""; // DeviceCode
                        TimeSpan ts = new TimeSpan();
                        DateTime dt = new DateTime();
                        string sText = "";
                        FillKeyHistLine(iID, ref iIDParent, ref sCmpName, ref sFNO, ref sPO, ref sDC, ref ts, ref dt, ref sText);

                        DataRow dr = tTable.NewRow();
                        dr.BeginEdit();
                        dr["ID"] = iID;
                        dr["ParentKey"] = (iIDParent == 0) ? "-" : iIDParent.ToString();
                        dr["CompanyName"] = sCmpName;
                        dr["FNameOfOwner"] = sFNO;
                        dr["PositionOfOwner"] = sPO;
                        dr["DeviceCode"] = sDC;
                        dr["TimeSpan"] = ts;
                        dr["DateOfAction"] = dt;
                        dr["TextOfReason"] = sText;
                        dr.EndEdit();
                        tTable.Rows.Add(dr);
                    }
                }
                else // if (null == this._listHistKeys)
                {
                    SqlCommand cmd = new SqlCommand("SP_SHOWKEYHISTORY", _mainForm.SqlConnection2);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = -1; // Show all records of history

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int iID = reader.GetInt32(0);
                        int iIDParentKey = 0;
                        if (!reader.IsDBNull(1))
                            iIDParentKey = reader.GetInt32(1);

                        string sCompanyName = reader.GetString(2);
                        string sFNameOfOwner = reader.GetString(3);
                        string sPosOfOwner = reader.GetString(4);
                        string sDevCode = reader.GetString(5);
                        DateTime dtStart = reader.GetDateTime(6);
                        DateTime dtEnd = reader.GetDateTime(7);
                        TimeSpan ts = dtEnd - dtStart;
                        DateTime dt = reader.GetDateTime(8);
                        string sText = reader.GetString(9);

                        DataRow dr = tTable.NewRow();
                        dr.BeginEdit();
                        dr["ID"] = iID;                        
                        dr["ParentKey"] = (iIDParentKey == 0) ? "-" : iIDParentKey.ToString();
                        dr["CompanyName"] = sCompanyName;
                        dr["FNameOfOwner"] = sFNameOfOwner;
                        dr["PositionOfOwner"] = sPosOfOwner;
                        dr["DeviceCode"] = sDevCode;
                        dr["TimeSpan"] = ts;
                        dr["DateOfAction"] = dt;
                        dr["TextOfReason"] = sText;
                        dr.EndEdit();
                        tTable.Rows.Add(dr);
                    }
                    reader.Close();
                }
                // Rename 'HeaderText' ONLY via dataGridView!!!
                // DO NOT using dataSet/dataTable for this action!!!
                int iIndex = 0;
                foreach (DataGridViewColumn column in dataGridView4.Columns)
                {
                    switch (iIndex)
                    {
                        case 0: column.Width = 45;
                            column.HeaderText = "N п/п";
                            break;
                        case 1: column.Width = 70;
                            column.HeaderText = "Предшеств.";                          
                            break;
                        case 2: column.Width = 115;
                            column.HeaderText = "Название организации";
                            break;
                        case 3: column.Width = 95;
                            column.HeaderText = "Фамилия владельца";
                            break;
                        case 4: column.Width = 95;
                            column.HeaderText = "Должность владельца";
                            break;
                        case 5: column.Width = 90;
                            column.HeaderText = "Код устройства";                           
                            break;
                        case 6: column.Width = 90;
                            column.HeaderText = "Длительность (дни)";
                            break;                       
                        case 7: column.Width = 75;
                            column.HeaderText = "Дата создания";
                            break;
                        case 8: column.Width = 175;
                            column.HeaderText = "Причина генерации";
                            break;                       
                    }
                    iIndex++;
                }
                dataGridView4.ReadOnly = true;
                dataGridView4.AllowUserToAddRows = false;
                dataGridView4.RowHeadersVisible = false;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyHistoryForm.RefreshKeyHistoryGrid - {0}", ex.Message);
            }
        }

        private void FillKeyHistLine(int iIDKey, ref int iIDParentKey, 
            ref string sCompanyName, ref string sFNameOfOwner, ref string sPosOfOwner, ref string sDevCode, 
            ref TimeSpan ts, ref DateTime dt, ref string sText)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SHOWKEYHISTORY", _mainForm.SqlConnection2);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = iIDKey;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // int iIDKey = reader.GetInt32(0);
                    if (!reader.IsDBNull(1))
                        iIDParentKey = reader.GetInt32(1);
                    
                    sCompanyName = reader.GetString(2);
                    sFNameOfOwner = reader.GetString(3);
                    sPosOfOwner = reader.GetString(4);
                    sDevCode = reader.GetString(5);
                    DateTime dtStart = reader.GetDateTime(6);
                    DateTime dtEnd = reader.GetDateTime(7);
                    ts= dtEnd - dtStart;
                    dt = reader.GetDateTime(8);
                    sText = reader.GetString(9);                     
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyHistoryForm.FillKeyHistLine - {0}", ex.Message);
            }
        }
    }
}
