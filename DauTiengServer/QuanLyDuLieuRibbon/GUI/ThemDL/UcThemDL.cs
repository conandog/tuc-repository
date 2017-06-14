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
    public partial class UcThemDL : UserControl
    {
        private bool isOverWrite = true;

        public UcThemDL()
        {
            InitializeComponent();
        }

        private void UcQLDL_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void LoadListViewFolder(string path)
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
                    lvi.ImageIndex = IconsExplorer.GetIconIndexOfListView(info.FullName, lvThongTin.Handle);
                    lvThongTin.Items.Add(lvi);
                }
            }
        }

        private void LoadListViewFile(string folderPath)
        {
            string[] listFilePath = Directory.GetFiles(folderPath);

            if (listFilePath.Length > 0)
            {
                foreach (string filePath in listFilePath)
                {
                    FileInfo info = new FileInfo(filePath);
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(info.FullName);
                    lvi.SubItems.Add(info.Name);
                    lvi.SubItems.Add(info.Extension);
                    lvi.ImageIndex = IconsExplorer.GetIconIndexOfListView(info.FullName, lvThongTin.Handle);
                    lvThongTin.Items.Add(lvi);
                }
            }
        }

        private void LoadListViewDestinationFolder(string path)
        {
            string[] listFolderPath = Directory.GetDirectories(path);

            if (listFolderPath.Length > 0)
            {
                foreach (string folderPath in listFolderPath)
                {
                    DirectoryInfo info = new DirectoryInfo(folderPath);
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = info.Name;
                    lvi.SubItems.Add(info.Extension);
                    lvi.ImageIndex = IconsExplorer.GetIconIndexOfListView(info.FullName, lvDestination.Handle);
                    lvDestination.Items.Add(lvi);
                }
            }
        }

        private void LoadListViewDestinationFile(string folderPath)
        {
            string[] listFilePath = Directory.GetFiles(folderPath);

            if (listFilePath.Length > 0)
            {
                foreach (string filePath in listFilePath)
                {
                    FileInfo info = new FileInfo(filePath);
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = info.Name;
                    lvi.SubItems.Add(info.Extension);
                    lvi.ImageIndex = IconsExplorer.GetIconIndexOfListView(info.FullName, lvDestination.Handle);
                    lvDestination.Items.Add(lvi);
                }
            }
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pbFinish_Click(object sender, EventArgs e)
        {
            ProcessTransfer();
        }

        private void ProcessTransfer()
        {
            try
            {
                try
                {
                    foreach (ListViewItem item in lvThongTin.CheckedItems)
                    {
                        string destination = tbDestination.Text;
                        string source = item.SubItems[1].Text;
                        FileAttributes attr = File.GetAttributes(source);

                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            DirectoryCopy(source, destination, true);
                        }
                        else
                        {
                            destination = Path.Combine(destination, Path.GetFileName(source));
                            File.Copy(source, destination, isOverWrite);
                        }
                    }

                    MessageBox.Show(String.Format(Constant.MESSAGE_UPDATE_SUCCESS, "Dữ liệu mới"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Constant.MESSAGE_ERROR);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Constant.MESSAGE_UPDATE_ERROR, "Quá trình"));
            }
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, isOverWrite);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void btSource_Click(object sender, EventArgs e)
        {
            string path = File_Function.FolderDialog();
            lvThongTin.Items.Clear();

            if (path != null)
            {
                tbSource.Text = path;
                LoadListViewFolder(path);
                LoadListViewFile(path);
            }
        }

        private void btDestination_Click(object sender, EventArgs e)
        {
            FormDestination form = new FormDestination();

            if (form.ShowDialog() == DialogResult.OK)
            {
                tbDestination.Text = form.destination;
                CheckListViewItemsIsChecked();

                lvDestination.Items.Clear();
                LoadListViewDestinationFolder(tbDestination.Text);
                LoadListViewDestinationFile(tbDestination.Text);
            }
            else if (String.IsNullOrEmpty(tbDestination.Text))
            {
                lvDestination.Items.Clear();
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            ProcessTransfer();
        }

        private void lvThongTin_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CheckListViewItemsIsChecked();
        }

        private void CheckListViewItemsIsChecked()
        {
            if (lvThongTin.CheckedItems.Count > 0 && !String.IsNullOrEmpty(tbDestination.Text))
            {
                btAdd.Enabled = true;
            }
            else
            {
                btAdd.Enabled = false;
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
    }
}
