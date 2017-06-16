using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QuanLyDuLieuRibbon
{
    public partial class Form1 : RibbonForm
    {
        public static string root = "DuLieuHoDauTieng";
        public const string xmlPath = "DauTieng_RootTree.xml";
        public const string XML_DEFAULT_CONTENT = "directorycontrol";
        public const string XML_PATH = "path";
        public const string XML_ROOT = "root";

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
            if (Directory.Exists(Form1.root) == false)
            {
                MessageBox.Show("Thư mục gốc không tồn tại. Hãy tạo lại cây thư mục hoặc liên hệ với lập trình viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ribbonButton_InitRoot_Click(null, null);
            }
            else
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadXmlAndGetRootPath();
        }

        private void ReadXmlAndGetRootPath()
        {
            try
            {
                if (File.Exists(xmlPath))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlPath);
                    XmlNode rootNode = doc.GetElementsByTagName(XML_ROOT)[0];
                    root = rootNode.Attributes[XML_PATH].Value + rootNode.FirstChild.Value;
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.MESSAGE_ERROR);
            }
        }
    }
}
