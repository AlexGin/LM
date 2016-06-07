using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM
{
    public class KeyFilter
    {
        public int IDKey { get; set; }
        public int IDCompany { get; set; } // { set; get; } // It's also OK
        public int IDParentKey { get; set; }
        public int IDDevice { get; set; }
        public int ValidKeyMode { get; set; } // Value: "1"-Valid (by date-time) Key; "0"-Invalid Key; "-1"-all keys
        public int TestKeyMode { get; set; } // Value: "1"-Test Key; "0"-License (no-test) Key; "-1"-any key
        public string FNameOfOwner { get; set; }
        public string PositionOfOwner { get; set; }

        private bool _bUseDateTime = false; 
        private DateTime _dtStart;
        private DateTime _dtEnd;

        public DateTime DTStart
        {
            get { return _dtStart; }
        }

        public DateTime DTEnd
        {
            get { return _dtEnd; }
        }

        public bool IsUseDateTime
        {
            get { return _bUseDateTime; }
        }

        public KeyFilter()
        {
            IDKey = -1; // Any ID of key
            IDCompany = -1; // Any company
            IDParentKey = -1; // Any parent key
            IDDevice = -1; // Any device
            TestKeyMode = -1; // Any key
            ValidKeyMode = -1; // All keys (valid and invalid - on date-time)
        }

        public KeyFilter(int iIDKey, int iIDCompany, int iIDParentKey=-1, int iIDDevice=-1, int iTestKeyMode=-1, int iValidKeyMode=-1)
        // public KeyFilter(int iIDKey, int iIDCompany, int iIDParentKey, int iIDDevice, int iTestKeyMode, int iValidKeyMode)
        {
            IDKey = iIDKey;
            IDCompany = iIDCompany;
            IDParentKey = iIDParentKey;
            IDDevice = iIDDevice;
            TestKeyMode = iTestKeyMode;
            ValidKeyMode = iValidKeyMode;
        }

        public void SetDateTime(DateTime dtStart, DateTime dtEnd)
        {
            _bUseDateTime = true;
            _dtStart = dtStart;
            _dtEnd = dtEnd;
        }
    }
}
