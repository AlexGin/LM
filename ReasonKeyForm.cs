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
    public partial class ReasonKeyForm : Form
    {
        private string _strTextOfReason;
        public string TextOfReason
        {
            get { return _strTextOfReason; }
        }
        public ReasonKeyForm()
        {
            InitializeComponent();
        }

        private void OnClickOK(object sender, EventArgs e)
        {
            _strTextOfReason = textBox1.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void OnClickCancel(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
