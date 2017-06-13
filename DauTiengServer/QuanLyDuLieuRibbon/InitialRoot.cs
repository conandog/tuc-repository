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
    public partial class InitialRoot : Form
    {
        
        public InitialRoot()
        {
            InitializeComponent();
            //if (File.Exists("DauTieng_RootTree.xml") == true)
            //{
            //    XmlDocument doc = new XmlDocument();
            //    doc.Load("DauTieng_RootTree.xml");
            //    LoadTreeFromXmlDocument();
            //}
            
            //CreateDirectoryTREE("D:\\");
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void CreateDirectoryTREE(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("DauTieng_RootTree.xml");

            string root = string.Empty;
            string h1 = string.Empty;
            string h2 = string.Empty;
            string h3 = string.Empty;
            string h4 = string.Empty;

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string element = node.Name;
                string text = node.InnerText;
                Console.WriteLine(element + "\n");
                Console.WriteLine(text + "\n");
                switch (element)
                {
                    case "root":
                        root = text;
                        Directory.CreateDirectory(path + text);
                        break;
                    case "heading1":
                        h1 = text;
                        Directory.CreateDirectory(path + root + "\\" + text);
                        break;
                    case "heading2":
                        Directory.CreateDirectory(path + root + "\\" + h1 + "\\" + text);
                        h2 = text;
                        break;
                    case "heading3":
                        Directory.CreateDirectory(path + root + "\\" + h1 + "\\" + h2 + "\\" + text);
                        h3 = text;
                        break;
                    case "heading4":
                        Directory.CreateDirectory(path + root + "\\" + h1 + "\\" + h2 + "\\" + h3 + "\\" + text);
                        h4 = text;
                        break;

                    default:
                        return;
                }

            }
        }


        public void LoadTreeFromXmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("DauTieng_RootTree.xml");
            int r = 0;
            int h1 = 0;
            int h2 = 0;
            int h3 = 0;
            int h4 = 0;

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string element = node.Name;
                string text = node.InnerText;
               
                
                switch (element)
                {
                    case "root":
                        treeView_Directory.Nodes.Add(text);
                        //r = r + 1;
                        break;
                    case "heading1":
                        
                        treeView_Directory.Nodes[r].Nodes.Add(text);
                        r = r + 1;
                        break;
                    case "heading2":
                        treeView_Directory.Nodes[r-1].Nodes[h1].Nodes.Add(text);
                        h1 = h1 + 1;
                        break;
                    case "heading3":
                        treeView_Directory.Nodes[r-1].Nodes[h1-1].Nodes[h2].Nodes.Add(text);
                        h2 = h2 + 1;
                        break;
                    case "heading4":
                        
                        treeView_Directory.Nodes[r-1].Nodes[h1-1].Nodes[h2-1].Nodes[h3].Nodes.Add(text);
                        h3 = h3 + 1;
                        break;

                    default:
                        return;
                }

            }
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {

            string path = FolderDialog();

            if (path != null)
            {
                tbRootPath.Text = path;
                treeView_Directory.Enabled = true;
                treeView_Directory.Nodes.Add("DuLieuHoDauTieng");
            }
        }

        public static string FolderDialog()
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowNewFolderButton = false;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private void btn_AddChildNode_Click(object sender, EventArgs e)
        {
            if (treeView_Directory.SelectedNode != null)
            {
                TreeNode newNode = treeView_Directory.SelectedNode.Nodes.Add("Thư mục mới");
                treeView_Directory.SelectedNode = newNode;
                treeView_Directory.LabelEdit = true;
                if (!treeView_Directory.SelectedNode.IsEditing)
                {
                    treeView_Directory.SelectedNode.BeginEdit();
                }
            }
        }

        private void treeView_Directory_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            foreach (TreeNode tn in e.Node.Parent.Nodes)
            {
                if (tn.Text == e.Label)
                {
                    MessageBox.Show("Thư mục bị trùng tên, hãy nhập lại!");
                    e.CancelEdit = true;
                    treeView_Directory.SelectedNode = e.Node;
                    treeView_Directory.LabelEdit = true;
                    if (!treeView_Directory.SelectedNode.IsEditing)
                    {
                        treeView_Directory.SelectedNode.BeginEdit();
                    }
                    //return;
                }
            }
        }

        private void treeView_Directory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView_Directory.LabelEdit = true;
            if (!treeView_Directory.SelectedNode.IsEditing)
            {
                treeView_Directory.SelectedNode.BeginEdit();
            }
        }

    }
}
