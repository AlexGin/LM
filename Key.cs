using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM
{
    public class Key
    {
        private int _iID;
        private int _iIDCompany;
        private int _iIDDevice;
        private int _iIDParentKey;
        private string _strValueOfKey;
        private DateTime _dtStartDate;
        private DateTime _dtEndDate;
        private short _nFlagOfTest;
        private DateTime _dtIssueDate;

        public Key(int iIDCompany, int iIDDevice, int iIDParentKey = -1, string strValueOfKey = "")
        {
            _iIDCompany = iIDCompany;
            _iIDDevice = iIDDevice;
            _iIDParentKey = iIDParentKey;
            _strValueOfKey = strValueOfKey;
        }

        public Key(int iIDDevice)
        {
            _iIDCompany = -1;
            _iIDDevice = iIDDevice;
            _iIDParentKey = -1;
            _strValueOfKey = "";
        }

        public void KeyGenerate()
        {
            Random ran = new Random();
            string resKeyCode = "";
            for (int i = 0; i < 64; i++)
            {                 
                resKeyCode += (char)(0x30 + ran.Next(0, 9));
            }
            _strValueOfKey = resKeyCode;
        }

        public string ValueOfKey 
        { 
            get { return _strValueOfKey; }
            set { _strValueOfKey = value; }
        }

        public int IDCompany { get { return _iIDCompany; } }
        public int IDDevice { get { return _iIDDevice; } }
        public int ID
        {
            get { return _iID; }
            set { _iID = value; }
        }

        public int IDParentKey 
        { 
            get { return _iIDParentKey; }
            set { _iIDParentKey = value; }
        }

        public short FlagOfTest
        {
            get {  return _nFlagOfTest; }
            set {  _nFlagOfTest = value; }
        }

        public DateTime StartDate
        {
            get { return _dtStartDate; }
            set { _dtStartDate = value; }
        }

        public DateTime EndDate
        {
            get { return _dtEndDate; }
            set { _dtEndDate = value; }
        }

        public DateTime IssueDate
        {
            get { return _dtIssueDate; }
            set { _dtIssueDate = value; }
        }
    }
}
