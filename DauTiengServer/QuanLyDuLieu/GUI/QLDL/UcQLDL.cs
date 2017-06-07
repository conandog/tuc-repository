using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Library;

namespace QuanLyDuLieu.GUI
{
    public partial class UcQLDL : UserControl
    {
        private string root = FormQLDL.root;
        private readonly string FAKE_NODE = "empty";

        public UcQLDL()
        {
            InitializeComponent();
        }

        private void UcQLDL_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            DirectoryInfo info = new DirectoryInfo(root);
            treeViewFolder.Nodes.Add(info.FullName, info.Name);
            AddNewFolderNodes(treeViewFolder.TopNode);
        }

        private void AddNewFolderNodes(TreeNode currentNode)
        {
            string[] listPath = Directory.GetDirectories(currentNode.Name);

            if (listPath.Length > 0)
            {
                for (int i = 0; i < listPath.Length; i++)
                {
                    DirectoryInfo info = new DirectoryInfo(listPath[i]);

                    if (Directory.GetDirectories(listPath[i]).Length > 0)
                    {
                        TreeNode childNode = new TreeNode(FAKE_NODE);
                        TreeNode[] listChild = new TreeNode[] { childNode };
                        TreeNode node = new TreeNode(info.Name, listChild);
                        node.Name = info.FullName;
                        currentNode.Nodes.Add(node);
                    }
                    else
                    {
                        currentNode.Nodes.Add(info.FullName, info.Name);
                    }
                }
            }
        }

        private void treeViewFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvThongTin.Items.Clear();
            string[] listFilePath = Directory.GetFiles(e.Node.Name);
            
            if (listFilePath.Length > 0)
            {
                foreach (string filePath in listFilePath)
                {
                    FileInfo info = new FileInfo(filePath);
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(info.FullName);
                    lvi.SubItems.Add(info.Name);
                    lvi.SubItems.Add(info.Extension);
                    lvi.SubItems.Add(info.LastWriteTime.ToString(Constant.DEFAULT_DATE_FORMAT));
                    lvThongTin.Items.Add(lvi);
                }
            }
        }

        private void treeViewFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0 && e.Node.Nodes[0].Text == FAKE_NODE)
            {
                e.Node.Nodes.Clear();
                AddNewFolderNodes(e.Node);
            }
        }

        private void lvThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvThongTin_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0 && lvThongTin.Items.Count > 0)
            {
                bool isChecked = lvThongTin.Items[0].Checked;

                foreach (ListViewItem item in lvThongTin.Items)
                {
                    item.Checked = !isChecked;
                }
            }
        }

        private void lvThongTin_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.NewWidth = 30;
                e.Cancel = true;
            }

            if (e.ColumnIndex == 1)
            {
                e.NewWidth = 0;
                e.Cancel = true;
            }
        }

        private void lvThongTin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvThongTin.SelectedItems.Count > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start(lvThongTin.SelectedItems[0].SubItems[1].Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Constant.MESSAGE_ERROR);
                }
            }
        }
    }
}
