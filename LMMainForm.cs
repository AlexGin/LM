using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

//Here is the once-per-application setup information
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace LM
{    
    public partial class LMMainForm : Form
    {
        // see:
        // http://www.codeproject.com/Articles/140911/log-net-Tutorial 
        log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DevicesForm _devices;
        private CompanyForm _company;
        private KeysForm _keys;
        private string _strFilePath;
        private SqlConnection _sqlConn;
        private SqlConnection _sqlConn2;
        public static SqlConnection g_sqlConn;
        private bool _b1Activate = true;
        public LMMainForm()
        {
            try
            {
                log.Info("License Manager - Application start");                

                InitializeComponent();               
            }
            catch (Exception ex)
            {
                log.ErrorFormat("LMMainForm.LMMainForm - {0}", ex.Message);
            }
        }

        public void HistoryWrite(string strText)
        {
            DateTime dtNow = DateTime.Now;
            string strOut = string.Format("[{0}] - {1}", dtNow.ToString(), strText);
            string fileName = this._strFilePath + "/LMHistory.txt";
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(strOut);
            }
        }

        private int DBConnect(string strLogin = "", string strPassword = "")
        {
            try
            {
                int iResult = 0; // Without errors; connection OK
                bool bSilentMode = (bool)(0 == strLogin.Length && 0 == strPassword.Length);
                string strConnString = bSilentMode ? GetConnString() : RetrieveConnString(strLogin, strPassword);
                if (strConnString.Length == 0)
                {
                    iResult = 2; // Invalid password or login
                    return iResult;
                }
                _sqlConn = new SqlConnection(strConnString);
                _sqlConn.Open();

                _sqlConn2 = new SqlConnection(strConnString);
                _sqlConn2.Open();
                g_sqlConn = _sqlConn2;

                bool bConnect = ((_sqlConn.State == ConnectionState.Open) && (_sqlConn2.State == ConnectionState.Open));
                if (bConnect)
                {
                    toolStripStatusLabel1.Text = "Соединение с БД установлено";

                    string strSqlConnState = string.Format("MS SQL Server - connection state: {0}", _sqlConn.State.ToString());
                    log.Info(strSqlConnState);
                    HistoryWrite(strSqlConnState);
                }
                else
                {
                    log.Error("LMMainForm.DBConnect - SQL Connection ERROR");
                    iResult = -1; // Connection error
                }
                return iResult;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("LMMainForm.DBConnect - {0}", ex.Message);
                return -1; // Connection error
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            log.Info("License Manager - Application exit");
            HistoryWrite("License Manager - Application exit");
        }

        public System.Data.SqlClient.SqlConnection SqlConnection
        {
            get
            {
                return _sqlConn;
            }
        }

        public System.Data.SqlClient.SqlConnection SqlConnection2
        {
            get
            {
                return _sqlConn2;
            }
        }

        public void KeysFormClosed()
        {
            _keys = null;
        }

        public void CompanyFormClosed()
        {
            _company = null;
        }

        public void DevicesFormClosed()
        {
            _devices = null;
        }

        private void OnClickExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnActivatedMainForm(object sender, EventArgs e)
        {
            try
            {
                if (_b1Activate)
                {
                    // Login:
                    _b1Activate = false;
#if LOGIN_MODE
                    LoginForm lf = new LoginForm();
                    if (lf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string sLogin = lf.LoginText;
                        string sPassword = lf.PasswordText;
                        int iConnResult = DBConnect(sLogin, sPassword);
                        if (2 == iConnResult)
                        {
                            MessageBox.Show("Неверный логин или пароль", "License Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
#endif
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("LMMainForm.OnActivatedMainForm - {0}", ex.Message);
            }
        }

        private void OnLoadMainForm(object sender, EventArgs e)
        {
            try
            {                
                IsMdiContainer = true;
#if (!LOGIN_MODE)
                int iConnResult = DBConnect();
                if (2 == iConnResult)
                {
                    MessageBox.Show("Неверный логин или пароль", "License Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
#endif
            }
            catch (Exception ex)
            {
                log.ErrorFormat("LMMainForm.OnLoadMainForm - {0}", ex.Message);               
            }
        }

        private void OnClickCompany(object sender, EventArgs e)
        {
            if ((_company != null) && (_company.Visible))
            {
                _company.Focus();
                return;
            }

            if (_company == null)
            {
                _company = new CompanyForm(this);
                _company.MdiParent = this;
            }
            _company.Show();
        }

        private void OnClickDevices(object sender, EventArgs e)
        {
            if ((_devices != null) && (_devices.Visible))
            {
                _devices.Focus();
                return;
            }

            if (_devices == null)
            {
                _devices = new DevicesForm(this);
                _devices.MdiParent = this;
            }

            _devices.Show();
        }

        private void OnClickKeys(object sender, EventArgs e)
        {
            if ((_keys != null) && (_keys.Visible))
            {
                _keys.Focus();
                return;
            }

            if (_keys == null)
            {
                _keys = new KeysForm(this);
                _keys.MdiParent = this;
            }

            _keys.Show();
        }

        public void ShowKeysByFilter(KeyFilter kf)
        {
            if (_keys != null)
            {
                _keys.Close();
            }

            _keys = null;
                        
            _keys = new KeysForm(this, kf);
            _keys.MdiParent = this;

            _keys.Show();
        }

        public void ShowKeysForDevice(int iIDDevice)
        {
            if (_keys != null)
            {
                _keys.Close();
            }

            _keys = null;

            KeyFilter kfr = new KeyFilter(-1, -1, -1, iIDDevice, -1, -1); // 1);
            kfr.FNameOfOwner = ""; // Empty string
            _keys = new KeysForm(this, kfr);
            _keys.MdiParent = this;

            _keys.Show();
        }

        public void ShowKeysForCompany(int iIDCompany)
        {
            if (_keys != null)
            {
                _keys.Close();                
            }

            _keys = null;

            KeyFilter kfr = new KeyFilter(-1, iIDCompany, -1, -1, -1, -1); //1);
            kfr.FNameOfOwner = ""; // Empty string
            _keys = new KeysForm(this, kfr);
            _keys.MdiParent = this;
            
            _keys.Show();
        }

        private string RetrieveConnString(string strLogin, string strPassword)
        {   
            string strConn = "";

            string sSvrName = "", sDbName = "", sUsrName = "", sPwd = "", sFilePath = "";
            LoadRegValues(ref sSvrName, ref sDbName, ref sUsrName, ref sPwd, ref sFilePath);
            _strFilePath = sFilePath;

            if ((strLogin == sUsrName) && (strPassword == sPwd))
            {
                strConn = string.Format(
                  "Persist Security Info=false;User ID={0};Password={1};Initial Catalog={2};Data Source={3}",
                  sUsrName, sPwd, sDbName, sSvrName);
                // "Persist Security Info=false;User ID=sa;Password=sa;Initial Catalog=BSEU;Data Source=ALEX-OLD"; 

                return strConn;
            }
            return "";
        }

        private string GetConnString()
        {
            string strConn = "";


            string sSvrName = "", sDbName = "", sUsrName = "", sPwd = "", sFilePath = "";
            LoadRegValues(ref sSvrName, ref sDbName, ref sUsrName, ref sPwd, ref sFilePath);
            _strFilePath = sFilePath;
            strConn = string.Format(
                "Persist Security Info=false;User ID={0};Password={1};Initial Catalog={2};Data Source={3}",
                sUsrName, sPwd, sDbName, sSvrName);
            // "Persist Security Info=false;User ID=sa;Password=sa;Initial Catalog=BSEU;Data Source=ALEX-OLD"; 

            return strConn;
        }

        private void LoadRegValues(ref string strSvrName, ref string strDbName, ref string strUsrName, ref string strPwd, ref string strFilePath)
        {
            try
            {
                RegistryKey regKeyLM = Registry.LocalMachine;
                RegistryKey regKeyLM1 = regKeyLM.OpenSubKey("SOFTWARE\\BEVALEX\\LicenseManager");

                if (null != regKeyLM1)
                {
                    strSvrName = (string)regKeyLM1.GetValue("NETServerName", (object)(" "));
                    strDbName = (string)regKeyLM1.GetValue("NETDBName", (object)(" "));

                    strUsrName = (string)regKeyLM1.GetValue("NETUserName", (object)(" "));
                    strPwd = (string)regKeyLM1.GetValue("NETPassword", (object)(" "));

                    strFilePath = (string)regKeyLM1.GetValue("NETFilePath", (object)(" "));
                    regKeyLM1.Close();
                }                
                regKeyLM.Close();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("LMMainForm.LoadRegValues - {0}", ex.Message);                
            }
        }

        public static int GetLimitOfKeys(int iIDCompany)
        {            
            string strSQL = "SELECT LimitOfKeys FROM Company WHERE ID=@IDCOMPANY";
            SqlCommand cmd = new SqlCommand(strSQL, g_sqlConn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@IDCOMPANY", SqlDbType.Int).Value = iIDCompany; 

            SqlDataReader reader = cmd.ExecuteReader();
            int iResult = 0;     
            if (reader.Read())
            {                
                iResult += reader.GetInt32(0);
            }
            reader.Close();
            return iResult;  
        }

        public static int PrepareDictionary(Dictionary<int, string> dict, List<string> list)
        {
            int iResult = 0;
            string strSQL = "SELECT ID, CompanyName FROM Company";
            SqlCommand cmd = new SqlCommand(strSQL, g_sqlConn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int iCompanyId = reader.GetInt32(0);
                string strCompanyName = reader.GetString(1);
                if (list != null)
                {
                    if (null == list.Find(x => x == strCompanyName)) // Add in list, if value is not exist 
                        list.Add(strCompanyName);
                }
                dict[iCompanyId] = strCompanyName;
                iResult++;
            }
            reader.Close();
            return iResult;
        }

        public static DateTime RetrieveLinkerTimestamp(string filePath)
        {            
            // string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }

        private void OnClickAbout(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void OnClickUserMan(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("UserManual.doc");
        }

        private void OnClickSearch(object sender, EventArgs e)
        {
            KeyFilter kf = new KeyFilter();
            KeyFilterForm kffm = new KeyFilterForm(this, kf);
            if (kffm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ShowKeysByFilter(kf);
            }
        }

        private void OnClickHistory(object sender, EventArgs e)
        {
            try
            {                
                KeyHistoryForm history = new KeyHistoryForm(this, null); 
                history.ShowDialog();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("LMMainForm.OnClickHistory - {0}", ex.Message);
            }
        }               
    }
}
