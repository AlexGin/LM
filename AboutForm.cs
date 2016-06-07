using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LM
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            string strFileName = "LM.exe"; 

            InitializeComponent();

            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(strFileName);
            string strVersion = fileVersionInfo.FileVersion;
            DateTime dtCompileDateTime = LMMainForm.RetrieveLinkerTimestamp(strFileName);

            labelVersion.Text = strVersion;
            labelTime.Text = dtCompileDateTime.ToString();

            string strLink = "http://files.rsdn.ru/21902/alexgin_resume.pdf";
            int iLen = this.linkLabel1.Text.Length;
            this.linkLabel1.Links.Add(0, iLen, strLink);
        }
        
        private void OnLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
