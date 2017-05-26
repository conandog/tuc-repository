using DemoApp.Properties;
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

namespace DemoApp
{
    public partial class Page2 : Form
    {
        string dropboxPath = String.Empty;
        string dauTiengFolder = String.Empty;
        string pic1 = String.Empty;
        string pic2 = String.Empty;

        public Page2()
        {
            InitializeComponent();
        }

        private void Page2_Load(object sender, EventArgs e)
        {
            pbMap.Controls.Add(pbLoading);
            pbLoading.BackColor = Color.Transparent;

            pbMap.Controls.Add(pbLibrary);
            pbLibrary.BackColor = Color.Transparent;

            GetDropboxLocalPath();

            if (String.IsNullOrEmpty(dropboxPath))
            {
                MessageBox.Show("Vui lòng cập nhật dropbox để có hình ảnh mới nhất!");
            }
            else
            {
                dauTiengFolder = Path.Combine(dropboxPath, "SaleNotes\\DauTieng_Project");
                pic1 = Path.Combine(dauTiengFolder, "1.png");
                pic2 = Path.Combine(dauTiengFolder, "2.png");
                pbMap.Image = Image.FromFile(pic1);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void GetDropboxLocalPath()
        {
            try
            {
                var infoPath = @"Dropbox\info.json";
                var jsonPath = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), infoPath);
                if (!File.Exists(jsonPath)) jsonPath = Path.Combine(Environment.GetEnvironmentVariable("AppData"), infoPath);
                //if (!File.Exists(jsonPath)) throw new Exception("Dropbox could not be found!");
                dropboxPath = File.ReadAllText(jsonPath).Split('\"')[5].Replace(@"\\", @"\");
            }
            catch
            {
                //
            }
        }

        private void pbLoading_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pic2))
            {
                pbMap.Image = Resources._2;
            }
            else
            {
                pbMap.Image = Image.FromFile(pic2);
            }

            pbLoading.Visible = false;
            pbLibrary.Visible = true;
            btLibrary.Visible = true;
        }

        private void btLibrary_Click(object sender, EventArgs e)
        {
            switch (pbLibrary.Tag.ToString())
            {
                case "1":
                    pbLibrary.Image = Resources._21;
                    pbLibrary.Tag = "2";
                    break;
                case "2":
                    pbLibrary.Image = Resources._4;
                    pbLibrary.Tag = "3";
                    break;
                case "3":
                    pbLibrary.Image = Resources._3;
                    pbLibrary.Tag = "4";
                    break;
                case "4":
                    pbLibrary.Image = null;
                    pbLibrary.Tag = String.Empty;
                    break;
                default:
                    pbLibrary.Image = Resources._11;
                    pbLibrary.Tag = "1";
                    break;
            }
        }
    }
}
