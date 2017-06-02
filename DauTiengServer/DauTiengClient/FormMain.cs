using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class FormMain : RibbonForm
    {
        string ROOT = @"D:\Root";
        string TEMP = @"D:\Root\Temp";

        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void CloseAllChild()
        {
            while (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void ribbtAbout_Click(object sender, EventArgs e)
        {
            // Remove the access control entry from the directory.
            RemoveDirectorySecurity(ROOT, @"adminpc\admin", FileSystemRights.FullControl, AccessControlType.Allow);
            CloseAllChild();

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(FormAbout))
                {
                    f.Activate();
                    return;
                }
            }

            Form form = new FormAbout();
            form.MdiParent = this;
            form.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
                clientSocket.Connect("127.0.0.1", 1234);
                clientSocket.ReceiveBufferSize = 8192;
                clientSocket.SendBufferSize = 8192;

                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Tuc.Nguyen (sent from client)$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                byte[] inStream = new byte[8192];
                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                MessageBox.Show("Data from Server : " + returndata);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Visible = false;
            FormLogin form = new FormLogin();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                ribbtAbout_Click(null, null);
                this.Visible = true;
            }
            else
            {
                this.Close();
            }
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            // Add the access control entry to the directory.
            AddDirectorySecurity(ROOT, @"adminpc\admin", FileSystemRights.Read, AccessControlType.Allow);

            CloseAllChild();

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Page2))
                {
                    f.Activate();
                    return;
                }
            }

            Form form = new Page2();
            form.MdiParent = this;
            form.Show();
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            CloseAllChild();

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Page3))
                {
                    f.Activate();
                    return;
                }
            }

            Form form = new Page3();
            form.MdiParent = this;
            form.Show();
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            RestructureData(ROOT, TEMP);

            CloseAllChild();

            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(Page1))
                {
                    f.Activate();
                    return;
                }
            }

            Form form = new Page1();
            form.MdiParent = this;
            form.Show();
        }

        private void RestructureData(string rootPath, string tempPath)
        {
            try
            {
                string[] files = Directory.GetFiles(tempPath);

                if (files.Length > 0)
                {
                    List<string> listError = new List<string>();

                    foreach (string filePath in files)
                    {
                        string fileName = Path.GetFileName(filePath);

                        if (fileName.StartsWith("DT_"))
                        {
                            try
                            {
                                string destFolder = Path.Combine(rootPath, "QL_DeTai", "2001_04");
                                Directory.CreateDirectory(destFolder);
                                File.Copy(filePath, Path.Combine(destFolder, fileName), false);
                                //File.Delete(filePath);
                            }
                            catch (Exception e)
                            {
                                listError.Add(e.Message);
                            }
                        }

                        if (fileName.EndsWith(".jpg"))
                        {
                            try
                            {
                                string destFolder = Path.Combine(rootPath, "QL_DuLieuKhac", "Hinh Anh", "2007_11");
                                Directory.CreateDirectory(destFolder);
                                File.Copy(filePath, Path.Combine(destFolder, fileName), false);
                                //File.Delete(filePath);
                            }
                            catch (Exception e)
                            {
                                listError.Add(e.Message);
                            }
                        }
                    }

                    if (listError.Count > 0)
                    {
                        string fullError = String.Empty;

                        for (int i = 0; i < listError.Count; i++)
                        {
                            fullError += (i + 1) + ". " + listError[i] + "\n";
                        }

                        MessageBox.Show(fullError);
                    }
                    else
                    {
                        MessageBox.Show("Tái cấu trúc thư mục thành công.");
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại dữ liệu để tái cấu trúc thư mục.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ribbonOrbMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Adds an ACL entry on the specified directory for the specified account.
        public static void AddDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(FileName);

            // Get a DirectorySecurity object that represents the 
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.AddAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));

            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);

        }

        // Removes an ACL entry on the specified directory for the specified account.
        public static void RemoveDirectorySecurity(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(FileName);

            // Get a DirectorySecurity object that represents the 
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.RemoveAccessRule(new FileSystemAccessRule(Account,
                                                            Rights,
                                                            ControlType));

            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);

        }
    }
}
