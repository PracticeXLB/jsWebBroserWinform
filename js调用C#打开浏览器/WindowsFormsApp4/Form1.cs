using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.NewWindow += WebBrowser1_NewWindow;

            webBrowser1.Navigate(Application.StartupPath + @"\HTMLPage.htm");
        }
        public void OpenIE(string url)
        {
            Process.Start("iexplore.exe", url);
        }
        private void WebBrowser1_NewWindow(object sender, CancelEventArgs e)
        {

            Process.Start("iexplore.exe", this.webBrowser1.StatusText);
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object[] objects = new object[1];
            objects[0] = "c# 调用 javascript";
            webBrowser1.Document.InvokeScript("AlertTest", objects);
        }
    }
}
