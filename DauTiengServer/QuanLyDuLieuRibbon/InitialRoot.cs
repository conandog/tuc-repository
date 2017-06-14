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
    public partial class InitialRoot : Form
    {
        public InitialRoot()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void CreateDirectoryFromXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Form1.xmlPath);
                XmlNode root = doc.GetElementsByTagName(Form1.XML_ROOT)[0];
                string rootDirPath = root.Attributes[Form1.XML_PATH].Value;
                rootDirPath = Path.Combine(rootDirPath, root.FirstChild.Value);

                //if (Directory.Exists(rootDirPath))
                //{
                //    MessageBox.Show("Thư mục đã tồn tại!");
                //    return;
                //}

                DirectoryInfo rootDir = Directory.CreateDirectory(rootDirPath);
                CreateNewDirectory(root, rootDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.MESSAGE_ERROR);
            }
        }

        private void CreateNewDirectory(XmlNode node, DirectoryInfo parent)
        {
            try
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Element)
                    {
                        DirectoryInfo dir = Directory.CreateDirectory(Path.Combine(parent.FullName, childNode.FirstChild.Value));

                        if (childNode.HasChildNodes)
                        {
                            CreateNewDirectory(childNode, dir);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadTreeFromXmlDocument(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.GetElementsByTagName(Form1.XML_ROOT)[0];
                tbRootPath.Text = root.Attributes[Form1.XML_PATH].Value;
                string rootName = root.FirstChild.Value;

                treeView_Directory.Nodes.Clear();
                treeView_Directory.Nodes.Add(rootName);
                LoadTreeFromXml(root, treeView_Directory.TopNode);
                treeView_Directory.Enabled = true;
                treeView_Directory.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.MESSAGE_ERROR);
            }
        }

        private void LoadTreeFromXml(XmlNode xmlNode, TreeNode treeNode)
        {
            try
            {
                foreach (XmlNode childXmlNode in xmlNode.ChildNodes)
                {
                    if (childXmlNode.NodeType == XmlNodeType.Element)
                    {
                        TreeNode childTreeNode = new TreeNode(childXmlNode.FirstChild.Value);
                        treeNode.Nodes.Add(childTreeNode);

                        if (childXmlNode.HasChildNodes)
                        {
                            LoadTreeFromXml(childXmlNode, childTreeNode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            string path = FolderDialog();

            if (path != null)
            {
                tbRootPath.Text = path;
                treeView_Directory.Enabled = true;

                if (treeView_Directory.GetNodeCount(false) == 0)
                {
                    treeView_Directory.Nodes.Add("DuLieuHoDauTieng");
                    treeView_Directory.SelectedNode = treeView_Directory.TopNode;
                }
            }
        }

        public static string FolderDialog()
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
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
                TreeNode newNode = treeView_Directory.SelectedNode.Nodes.Add("Thu muc moi");
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

        private void InitialRoot_Load(object sender, EventArgs e)
        {
            IconsExplorer.SetWindowTheme(treeView_Directory.Handle, "Explorer", null);

            if (File.Exists(Form1.xmlPath) == true)
            {
                LoadTreeFromXmlDocument(Form1.xmlPath);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(docNode);

                XmlElement defaultContent = xmlDoc.CreateElement(Form1.XML_DEFAULT_CONTENT);
                defaultContent.SetAttribute("version", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

                XmlElement rootElement = xmlDoc.CreateElement(Form1.XML_ROOT);
                rootElement.SetAttribute(Form1.XML_PATH, tbRootPath.Text);
                rootElement.InnerText = treeView_Directory.TopNode.Text;
                defaultContent.AppendChild(rootElement);

                SaveTreeToXml(treeView_Directory.TopNode, ref rootElement);

                xmlDoc.AppendChild(defaultContent);
                xmlDoc.Save(Form1.xmlPath);

                CreateDirectoryFromXml();
                MessageBox.Show("Lưu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.MESSAGE_ERROR);
            }
        }

        private void SaveTreeToXml(TreeNode node, ref XmlElement element)
        {
            try
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    XmlElement childElement = element.OwnerDocument.CreateElement("heading" + childNode.Level);
                    childElement.InnerText = childNode.Text;

                    if (childNode.GetNodeCount(false) > 0)
                    {
                        SaveTreeToXml(childNode, ref childElement);
                    }

                    element.AppendChild(childElement);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_DeleteNode_Click(object sender, EventArgs e)
        {
            treeView_Directory.Nodes.Remove(treeView_Directory.SelectedNode);
        }

        private void treeView_Directory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView_Directory.SelectedNode != null)
            {
                btn_AddChildNode.Enabled = true;
                btn_DeleteNode.Enabled = true;
            }
            else
            {
                btn_AddChildNode.Enabled = false;
                btn_DeleteNode.Enabled = false;
            }
        }

        private void tbRootPath_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbRootPath.Text))
            {
                btSave.Enabled = false;
            }
            else
            {
                btSave.Enabled = true;
            }
        }
    }
}
