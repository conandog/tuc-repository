using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuLieuRibbon
{
    public partial class Form1 : RibbonForm
    {
        public static string root = @"C:\DuLieuHoDauTieng";

        Form _MapHoDauTieng = new MapHoDauTieng_Form();
        Form _InitialRoot = new InitialRoot();
        Form _GeneralInformation = new GeneralInformation();

        Form _DataManagement = new DataManagement();
        Form _DataTransfer = new DataTransfer();

        public Form1()
        {
            InitializeComponent();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        
        private void ribbonButton_Map_Click(object sender, EventArgs e)
        {
            if (_MapHoDauTieng.IsMdiChild == false)
            {
                _MapHoDauTieng.MdiParent = this;
                _MapHoDauTieng.Show();
            }
            else
            {
                _MapHoDauTieng.Activate();
            }
        }

        private void ribbonButton_Info_Click(object sender, EventArgs e)
        {
            if (_GeneralInformation.IsMdiChild == false)
            {
                _GeneralInformation.MdiParent = this;
                _GeneralInformation.Show();
            }
            else
            {
                _GeneralInformation.Activate();
            }
        }

        private void ribbonButton_InitRoot_Click(object sender, EventArgs e)
        {
            if (_InitialRoot.IsMdiChild == false)
            {
                _InitialRoot.MdiParent = this;
                _InitialRoot.Show();
            }
            else
            {
                _InitialRoot.Activate();
            }
        }

        private void ribbonButton_FileData_Click(object sender, EventArgs e)
        {
            if (_DataManagement.IsMdiChild == false)
            {
                _DataManagement.MdiParent = this;
                _DataManagement.Show();
            }
            else
            {
                _DataManagement.Activate();
            }
        }

        private void ribbonButton_AddListFile_Click(object sender, EventArgs e)
        {
            if (_DataTransfer.IsMdiChild == false)
            {
                _DataTransfer.MdiParent = this;
                _DataTransfer.Show();
            }
            else
            {
                _DataTransfer.Activate();
            }
        }
    }
}
