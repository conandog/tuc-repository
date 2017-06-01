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
    public partial class Page3 : Form
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Page3_Load(object sender, EventArgs e)
        {
            FileBrowser.Browser newBrowser = new FileBrowser.Browser();
            newBrowser.StartUpDirectory = FileBrowser.SpecialFolders.Other;
            newBrowser.StartUpDirectoryOther = @"C:\Program Files";
            newBrowser.Dock = DockStyle.Fill;
            this.Controls.Add(newBrowser);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
    }
}
