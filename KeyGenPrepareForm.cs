using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LM
{
    public partial class KeyGenPrepareForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _strResultCompany;
        private string _strResultDeviceCode;
        private int _idCompany;

        private Dictionary<int, List<string>> _dictDeviceCodes; // Key - as IDCOMPANY (in the dbo.Devices)
        private Dictionary<int, string> _dictCompanyNames;  // Key - as IDCOMPANY
        private bool _bTestKeyFlag;
        private DateTime _dtStartDate;
        private DateTime _dtEndDate;
        private DateTime _dtIssueDate;
        private int _iParentKey;

        public KeyGenPrepareForm(Dictionary<int, string> dictCompanyNames, Dictionary<int, List<string>> dictDeviceCodes, int iParentKey)
        {
            _dictCompanyNames = dictCompanyNames;
            _dictDeviceCodes = dictDeviceCodes;
            _iParentKey = iParentKey;

            InitializeComponent();
        }

        public KeyGenPrepareForm(Dictionary<int, string> dictCompanyNames, Dictionary<int, List<string>> dictDeviceCodes)
        {
            _dictCompanyNames = dictCompanyNames;
            _dictDeviceCodes = dictDeviceCodes;
            _iParentKey = 0;

            InitializeComponent();
        }

        public DateTime DTStartDate { get { return _dtStartDate; } }
        public DateTime DTEndDate { get { return _dtEndDate; } }
        public DateTime DTIssueDate { get { return _dtIssueDate; } }
        public bool TestKeyFlag { get { return _bTestKeyFlag; } }
        
        public string ResultCompany
        { 
            get { return _strResultCompany; }
            set { _strResultCompany = value; }
        }
        public string ResultDeviceCode 
        { 
            get { return _strResultDeviceCode; } 
            set { _strResultDeviceCode = value; } 
        }
        public int IDCompany 
        { 
            get { return _idCompany; }
            set { _idCompany = value; }
        }
        
        private void OnLoadSelect(object sender, EventArgs e)
        {
            if (0 == _iParentKey)
            {                
                foreach (KeyValuePair<int, string> kvp in this._dictCompanyNames)
                {
                    string strCompanyName = kvp.Value;
                    this.listBoxCompany.Items.Add((object)strCompanyName);
                }
                this.btnOK.Enabled = false;
            }
            else
            {
                this.listBoxCompany.Items.Add((object)_strResultCompany);
                this.listBoxDevCode.Items.Add((object)_strResultDeviceCode);
                this.listBoxCompany.Enabled = false;
                this.listBoxDevCode.Enabled = false;
            }

            if (0 != _iParentKey)
            {
                string strAddText = string.Format(" (вместо ключа {0})", _iParentKey);
                this.Text += strAddText;
            }
        }

        private void OnCompanyIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int iSelIndexCompany = this.listBoxCompany.SelectedIndex;
                _strResultCompany = this.listBoxCompany.Items[iSelIndexCompany].ToString();
                int iKey = 0;
                foreach (KeyValuePair<int, string> kvp in _dictCompanyNames)
                {
                    string strCompanyName = kvp.Value;
                    if (_strResultCompany == strCompanyName)
                    {
                        iKey = kvp.Key; // It is IDCOMPANY                        
                        break;
                    }
                }
                this.listBoxDevCode.Items.Clear();
                if (iKey != 0)
                {
                    if (this._dictDeviceCodes.ContainsKey(iKey))
                    {
                        List<string> lst = this._dictDeviceCodes[iKey];
                        
                        foreach (string str in lst)
                            this.listBoxDevCode.Items.Add((object)str);

                        this.btnOK.Enabled = true;
                    }
                    else
                        this.btnOK.Enabled = false;

                    this._idCompany = iKey;
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyGenPrepareForm.OnCompanyIndexChanged - {0}", ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                _bTestKeyFlag = this.checkBoxTestKey.Checked;

                _dtIssueDate = this.dateTimePicker1.Value;
                _dtStartDate = this.dateTimePicker2.Value;
                _dtEndDate = this.dateTimePicker3.Value;

                int iSelIndexCode = this.listBoxDevCode.SelectedIndex;
                if ((-1) != iSelIndexCode)
                    _strResultDeviceCode = this.listBoxDevCode.Items[iSelIndexCode].ToString();                     
                else
                    _strResultDeviceCode = this.listBoxDevCode.Items[0].ToString();

                int iSelIndexCompany = this.listBoxCompany.SelectedIndex;
                if ((-1) != iSelIndexCompany)
                    _strResultCompany = this.listBoxCompany.Items[iSelIndexCompany].ToString();
                else
                    _strResultCompany = this.listBoxCompany.Items[0].ToString();

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyGenPrepareForm.btnOK_Click - {0}", ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }        
    }
}
