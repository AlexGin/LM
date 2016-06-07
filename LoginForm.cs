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
    public partial class LoginForm : Form
    {
        private string _strPassword;
        public string LoginText { get; set; }
        public string PasswordText 
        {
            get { return _strPassword; }
        }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void OKButtonClick(object sender, EventArgs e)
        {
            LoginText = this.textBoxLogin.Text;
            _strPassword = this.textBoxPassword.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
