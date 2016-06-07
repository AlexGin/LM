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
    public partial class KeyFilterForm : Form
    {
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private KeyFilter _keyFilter;
        private LMMainForm _mainForm;
        private Dictionary<int, string> _dictCompanyNames;
        private Dictionary<int, string> _dictDevicesCodes;
        private List<string> _listFNameOfOwners;        
        private Dictionary<int, int> _dictParents; // IDPARENT as a Key, ID (current) - as a Value
        public KeyFilterForm(LMMainForm mainForm, KeyFilter keyFilter)
        {
            _mainForm = mainForm;
            _keyFilter = keyFilter;
            InitializeComponent();
            // Set key-filter into unactive state:
            _keyFilter.IDCompany = -1;
            _keyFilter.IDDevice = -1;
            _keyFilter.IDKey = -1;
            _keyFilter.IDParentKey = -1;
            _keyFilter.FNameOfOwner = ""; // Empty string
        }

        private void OnFilterLoad(object sender, EventArgs e)
        {
            try
            {
                radioButtonAnyKey.Checked = true;
                radioButtonAllKeys.Checked = true;

                checkBoxCompany.Checked = false;
                checkBoxDevice.Checked = false;
                checkBoxOwner.Checked = false;
                checkBoxParent.Checked = false;

                comboBoxCompany.Enabled = false;
                comboBoxDevice.Enabled = false;
                comboBoxOwner.Enabled = false;
                comboBoxParent.Enabled = false;

                _dictCompanyNames = new Dictionary<int, string>();
                LMMainForm.PrepareDictionary(_dictCompanyNames, null);

                _dictDevicesCodes = new Dictionary<int, string>();
                _listFNameOfOwners = new List<string>();
                PrepareDeviceAndOwners(_dictDevicesCodes, _listFNameOfOwners);

                _dictParents = new Dictionary<int, int>();
                PrepareParents(_dictParents);

                foreach (KeyValuePair<int, string> kvp in this._dictCompanyNames)
                {
                    string strCompanyName = kvp.Value;
                    comboBoxCompany.Items.Add((object)strCompanyName);
                }

                foreach (KeyValuePair<int, string> kvp in this._dictDevicesCodes)
                {                    
                    string strOutCode = string.Format("Устройство '{0}' (код устройства '{1}')", kvp.Key, kvp.Value);
                    comboBoxDevice.Items.Add((object)strOutCode);
                }

                foreach (string strFNameOfOwner in _listFNameOfOwners)
                    comboBoxOwner.Items.Add((object)strFNameOfOwner);

                foreach (KeyValuePair<int, int> kvp in this._dictParents)
                {
                    string strText = string.Format("Ключ '{0}' (вместо ключа '{1}')", kvp.Value, kvp.Key);
                    comboBoxParent.Items.Add((object)strText);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyFilterForm.OnFilterLoad - {0}", ex.Message);
            }
        }

        public void PrepareParents(Dictionary<int, int> dictParents)
        {
            try
            {
                string strSQL = "SELECT ID, IDPARENTKEY FROM Keys";
                SqlCommand cmd = new SqlCommand(strSQL, _mainForm.SqlConnection2);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int iIDParentKey = 0, iID = 0;
                    if (!reader.IsDBNull(1))
                    {
                        iID = reader.GetInt32(0);
                        iIDParentKey = reader.GetInt32(1);
                        dictParents.Add(iIDParentKey, iID);
                    }                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyFilterForm.PrepareListParents - {0}", ex.Message);
            }
        }

        public void PrepareDeviceAndOwners(Dictionary<int, string> dict, List<string> list)
        {
            try
            {                
                string strSQL = "SELECT ID, CodeOfKey, FNameOfOwner FROM Devices";
                SqlCommand cmd = new SqlCommand(strSQL, _mainForm.SqlConnection2);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int iDeviceId = reader.GetInt32(0);
                    string strCodeOfKey = reader.GetString(1);
                    dict[iDeviceId] = strCodeOfKey;

                    string strFNameOfOwner = reader.GetString(2);
                    list.Add(strFNameOfOwner);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyFilterForm.PrepareDeviceAndOwners - {0}", ex.Message);
            }
        }

        private void OnClickOK(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBoxCompany.Checked)
                {
                    int iSelCompany = comboBoxCompany.SelectedIndex;
                    string strCompanyName = comboBoxCompany.Items[iSelCompany].ToString();

                    foreach (KeyValuePair<int, string> kvp in this._dictCompanyNames)
                    {
                        if (kvp.Value == strCompanyName)
                        {
                            this._keyFilter.IDCompany = kvp.Key;
                            break;
                        }
                    }
                }
                if (this.checkBoxOwner.Checked)
                {
                    int iSelOwner = comboBoxOwner.SelectedIndex;
                    string strFNameOfOwner = comboBoxOwner.Items[iSelOwner].ToString();
                    this._keyFilter.FNameOfOwner = strFNameOfOwner;
                }
                if (this.checkBoxDevice.Checked)
                {
                    int iSelDevice = comboBoxDevice.SelectedIndex;
                    string strDevice = comboBoxDevice.Items[iSelDevice].ToString();
                    string strDeviceCode = ParseStringLastValue(strDevice).ToString();
                    foreach (KeyValuePair<int, string> kvp in this._dictDevicesCodes)
                    {
                        string strCurrDevCode = kvp.Value;
                        if (strDeviceCode == strCurrDevCode)
                        {
                            int iDeviceID = kvp.Key;
                            this._keyFilter.IDDevice = iDeviceID;
                            break;
                        }
                    }                    
                }
                if (this.checkBoxParent.Checked)
                {
                    int iSelParent = comboBoxParent.SelectedIndex;
                    string strParent = comboBoxParent.Items[iSelParent].ToString();
                    int iParentID = ParseStringLastValue(strParent);                    
                    this._keyFilter.IDParentKey = iParentID;
                }

                if (radioButtonTestKey.Checked)
                    this._keyFilter.TestKeyMode = 1;
                else if (radioButtonLicKey.Checked)
                    this._keyFilter.TestKeyMode = 0;
                else if (radioButtonAnyKey.Checked)
                    this._keyFilter.TestKeyMode = -1;

                if (radioButtonValid.Checked)
                    this._keyFilter.ValidKeyMode = 1;
                else if (radioButtonInvalid.Checked)
                    this._keyFilter.ValidKeyMode = 0;
                else if (radioButtonAllKeys.Checked)
                    this._keyFilter.ValidKeyMode = -1;

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyFilterForm.OnClickOK - {0}", ex.Message);
            }
        }

        private int ParseStringLastValue(string str)
        {
            try
            {
                Stack<char> stack = new Stack<char>();
                int iResult = -1;
                int iLen = str.Length;
                string strResult = "";
                bool bOutFlag = false;
                for (int iIndex = iLen - 1; iIndex > 0; iIndex--)
                {
                    char chr = str[iIndex];
                    if (chr == 0x27) // symbol "'"
                    {
                        bOutFlag = !bOutFlag;
                        if (!bOutFlag)
                            break;
                        else
                            continue;
                    }
                    if (bOutFlag)
                        stack.Push(chr);
                }

                foreach (char ch in stack)
                    strResult += ch;

                iResult = Convert.ToInt32(strResult);
                return iResult;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("KeyFilterForm.ParseStringLastValue - {0}", ex.Message);
                return -1; // Error occur
            }
        }

        private void OnClickCancel(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void OnCheckedChangedCompany(object sender, EventArgs e)
        {
            comboBoxCompany.Enabled = this.checkBoxCompany.Checked;
        }

        private void OnCheckedChangedDevice(object sender, EventArgs e)
        {
            comboBoxDevice.Enabled = this.checkBoxDevice.Checked;
        }

        private void OnCheckedChangedOwner(object sender, EventArgs e)
        {
            comboBoxOwner.Enabled = this.checkBoxOwner.Checked;
        }

        private void OnCheckedChangedParent(object sender, EventArgs e)
        {
            comboBoxParent.Enabled = this.checkBoxParent.Checked;
        }
    }
}
