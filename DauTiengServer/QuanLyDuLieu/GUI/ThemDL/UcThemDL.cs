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
        public UcThemDL()
        {
            InitializeComponent();
        }

        private void UcQLDL_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            UcAdd ucAdd = new UcAdd();
            ucAdd.VisibleChanged += UcAdd_VisibleChanged;
            flowLayoutAdd.Controls.Add(ucAdd);
        }

        private void UcAdd_VisibleChanged(object sender, EventArgs e)
        {
            UcAdd uc = (UcAdd)sender;

            if (!uc.Visible)
            {
                flowLayoutAdd.Controls.Remove(uc);

                if (flowLayoutAdd.Controls.Count < 7)
                {
                    pbAdd.Enabled = true;
                }
            }
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            UcAdd ucAdd = new UcAdd();
            ucAdd.VisibleChanged += UcAdd_VisibleChanged;
            flowLayoutAdd.Controls.Add(ucAdd);

            if (flowLayoutAdd.Controls.Count >= 7)
            {
                pbAdd.Enabled = false;
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
                foreach (var control in flowLayoutAdd.Controls)
                {
                    if (control is UcAdd)
                    {
                        string source = ((UcAdd)control).source;
                        string destination = ((UcAdd)control).destination;

                        if (!String.IsNullOrEmpty(source) && !String.IsNullOrEmpty(destination))
                        {
                            DirectoryCopy(source, destination, true);
                        }
                    }
                }

                MessageBox.Show(String.Format(Constant.MESSAGE_UPDATE_SUCCESS, "Dữ liệu mới"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Constant.MESSAGE_UPDATE_ERROR, "Quá trình"));
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
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
                file.CopyTo(temppath, false);
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
    }
}
