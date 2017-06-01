using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class FormMain : RibbonForm
    {
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
            //try
            //{
            //    System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            //    clientSocket.Connect("127.0.0.1", 1234);
            //    clientSocket.ReceiveBufferSize = 8192;
            //    clientSocket.SendBufferSize = 8192;

            //    NetworkStream serverStream = clientSocket.GetStream();
            //    byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Tuc.Nguyen (sent from client)$");
            //    serverStream.Write(outStream, 0, outStream.Length);
            //    serverStream.Flush();

            //    byte[] inStream = new byte[8192];
            //    serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            //    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            //    MessageBox.Show("Data from Server : " + returndata);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

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

        private void ribbonOrbMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
