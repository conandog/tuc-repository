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
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace QuanLyDuLieu.GUI
{
    public partial class UcQLDL : UserControl
    {
        private string root = FormQLDL.root;
        private readonly string FAKE_NODE = "empty";
        private Dictionary<string, string> listSearchResult;

        public UcQLDL()
        {
            InitializeComponent();
        }

        private void UcQLDL_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            IconsExplorer.SetWindowTheme(treeViewFolder.Handle, "Explorer", null);
            IconsExplorer.SetWindowTheme(lvThongTin.Handle, "Explorer", null);

            Icon ico = IconsExplorer.GetFolderIcon(root, true);
            ImageList imageList = new ImageList();
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.Images.Add(ico);
            treeViewFolder.ImageList = imageList;

            InitialRoot();
            AddNewFolderNodes(treeViewFolder.TopNode);
            treeViewFolder.TopNode.Expand();
            tbSearch.Select();
        }

        private void InitialRoot()
        {
            DirectoryInfo info = new DirectoryInfo(root);
            treeViewFolder.Nodes.Clear();
            treeViewFolder.Nodes.Add(info.FullName, info.Name);
            tbGoTo.Text = treeViewFolder.TopNode.Name;
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

        private void AddNewFolderNodesWithSearch(TreeNode parentNode, Dictionary<string, string> listFile)
        {
            try
            {
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (listFile.Where(p => Path.GetDirectoryName(p.Key) == node.Name).ToList().Count > 0)
                    {
                        node.ForeColor = Color.Red;
                    }
                    else
                    {
                        node.ForeColor = Color.Black;
                    }

                    if (node.Nodes != null)
                    {
                        AddNewFolderNodesWithSearch(node, listFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.MESSAGE_ERROR);
            }
        }

        private Dictionary<string, string> GetListFilePathWithSearch(string text)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();

            try
            {
                string[] listFilePath = Directory.GetFiles(treeViewFolder.TopNode.Name, "*.*", SearchOption.AllDirectories);

                foreach (string filePath in listFilePath)
                {
                    FileInfo info = new FileInfo(filePath);
                    
                    if (info.Name.Contains(text))
                    {
                        res.Add(info.FullName, info.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.MESSAGE_ERROR);
            }

            return res;
        }

        private void treeViewFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Name;
            RefreshListView(path);
            tbGoTo.Text = path;
        }

        private void RefreshListView(string path)
        {
            lvThongTin.Items.Clear();
            LoadFolder(path);
            LoadFile(path);
        }

        private void LoadFolder(string path)
        {
            string[] listFolderPath = Directory.GetDirectories(path);

            if (listFolderPath.Length > 0)
            {
                foreach (string folderPath in listFolderPath)
                {
                    DirectoryInfo info = new DirectoryInfo(folderPath);
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(info.FullName);
                    lvi.SubItems.Add(info.Name);
                    lvi.SubItems.Add(info.Extension);
                    lvi.SubItems.Add(info.LastWriteTime.ToString(Constant.DEFAULT_DATE_FORMAT));
                    lvi.ImageIndex = GetIcon(info.FullName);
                    lvThongTin.Items.Add(lvi);
                }
            }
        }

        private void LoadFile(string path)
        {
            string[] listFilePath = Directory.GetFiles(path);

            if (listFilePath.Length > 0)
            {
                foreach (string filePath in listFilePath)
                {
                    FileInfo info = new FileInfo(filePath);
                    ListViewItem lvi = new ListViewItem();

                    if (listSearchResult != null)
                    {
                        if (listSearchResult.Where(p => p.Key == filePath).ToList().Count > 0)
                        {
                            lvi.ForeColor = Color.Red;
                        }
                    }

                    lvi.SubItems.Add(info.FullName);
                    lvi.SubItems.Add(info.Name);
                    lvi.SubItems.Add(info.Extension);
                    lvi.SubItems.Add(info.LastWriteTime.ToString(Constant.DEFAULT_DATE_FORMAT));
                    lvi.ImageIndex = GetIcon(info.FullName);
                    lvThongTin.Items.Add(lvi);
                }
            }
        }

        private int GetIcon(string path)
        {
            // Obtain a handle to the system image list.
            IconsExplorer.SHFILEINFO shfi = new IconsExplorer.SHFILEINFO();
            IntPtr hSysImgList = IconsExplorer.SHGetFileInfo("",
                                                             0,
                                                             ref shfi,
                                                             (uint)Marshal.SizeOf(shfi),
                                                             IconsExplorer.SHGFI_SYSICONINDEX
                                                              | IconsExplorer.SHGFI_SMALLICON);

            // Set the ListView control to use that image list.
            IntPtr hOldImgList = IconsExplorer.SendMessage(lvThongTin.Handle,
                                                           IconsExplorer.LVM_SETIMAGELIST,
                                                           IconsExplorer.LVSIL_SMALL,
                                                           hSysImgList);

            // If the ListView control already had an image list, delete the old one.
            if (hOldImgList != IntPtr.Zero)
            {
                IconsExplorer.ImageList_Destroy(hOldImgList);
            }

            IntPtr himl = IconsExplorer.SHGetFileInfo(path,
                                        0,
                                        ref shfi,
                                        (uint)Marshal.SizeOf(shfi),
                                        IconsExplorer.SHGFI_DISPLAYNAME
                                          | IconsExplorer.SHGFI_SYSICONINDEX
                                          | IconsExplorer.SHGFI_SMALLICON);

            return shfi.iIcon;
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
                e.NewWidth = 40;
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
            OpenFile();
        }

        private void OpenFile()
        {
            try
            {
                string path = lvThongTin.FocusedItem.SubItems[1].Text;
                FileAttributes attr = File.GetAttributes(path);

                if (attr.HasFlag(FileAttributes.Directory))
                {
                    if (treeViewFolder.SelectedNode.Nodes[path] == null)
                    {
                        treeViewFolder.SelectedNode.Expand();
                        treeViewFolder.SelectedNode = treeViewFolder.SelectedNode.Nodes[path];
                    }
                    else
                    {
                        treeViewFolder.SelectedNode = treeViewFolder.SelectedNode.Nodes[path];
                    }
                }
                else
                {
                    System.Diagnostics.Process.Start(lvThongTin.FocusedItem.SubItems[1].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.MESSAGE_ERROR);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            listSearchResult = GetListFilePathWithSearch(tbSearch.Text);

            if (listSearchResult.Count == 0 && !String.IsNullOrEmpty(tbSearch.Text))
            {
                MessageBox.Show("Không tìm thấy dữ liệu!");
                return;
            }
            else
            {
                treeViewFolder.ExpandAll();

                if (String.IsNullOrEmpty(tbSearch.Text))
                {
                    listSearchResult = null;
                    InitialRoot();
                    AddNewFolderNodes(treeViewFolder.TopNode);
                    treeViewFolder.TopNode.Expand();
                    treeViewFolder.SelectedNode = treeViewFolder.TopNode;
                    RefreshListView(treeViewFolder.TopNode.Name);
                }
                else
                {
                    AddNewFolderNodesWithSearch(treeViewFolder.TopNode, listSearchResult);
                    RefreshListView(treeViewFolder.SelectedNode.Name);
                }
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btSearch_Click(sender, e);
            }
        }

        private void lvThongTin_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string path = e.Item.SubItems[1].Text;
            FileAttributes attr = File.GetAttributes(path);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                e.Item.Checked = false;
            }
            else
            {
                CheckListViewItemsIsChecked();
            }
        }

        private void CheckListViewItemsIsChecked()
        {
            if (lvThongTin.CheckedItems.Count > 0)
            {
                btDelete.Enabled = true;
            }
            else
            {
                btDelete.Enabled = false;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Constant.MESSAGE_DELETE_CONFIRM, Constant.CAPTION_CONFIRM, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (ListViewItem item in lvThongTin.CheckedItems)
                {
                    bool isError = false;
                    string path = item.SubItems[1].Text;

                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception ex)
                    {
                        isError = true;
                    }

                    if (isError)
                    {
                        MessageBox.Show(Constant.MESSAGE_ERROR);
                    }
                }

                RefreshListView(treeViewFolder.SelectedNode.Name);
            }
        }

        private void btGoTo_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(tbGoTo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constant.MESSAGE_ERROR);
            }
        }

        private void lvThongTin_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string path = lvThongTin.FocusedItem.SubItems[1].Text;
                FileAttributes attr = File.GetAttributes(path);

                if (attr.HasFlag(FileAttributes.Directory))
                {
                    contextMenuStrip.Items[1].Visible = false;
                    contextMenuStrip.Show(Cursor.Position);
                }
                else if (lvThongTin.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip.Items[1].Visible = true;
                    contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Constant.MESSAGE_DELETE_CONFIRM, Constant.CAPTION_CONFIRM, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string path = lvThongTin.FocusedItem.SubItems[1].Text;
                    File.Delete(path);
                    RefreshListView(treeViewFolder.SelectedNode.Name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Constant.MESSAGE_ERROR);
                }
            }
        }

        private void MenuItemProperties_Click(object sender, EventArgs e)
        {
            File_Function.ShowFileProperties(lvThongTin.FocusedItem.SubItems[1].Text);
        }
    }
}
