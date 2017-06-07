using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace QuanLyDuLieu.GUI
{
    public partial class UcAdd : UserControl
    {
        public UcAdd()
        {
            InitializeComponent();
        }

        private void UcAdd_Load(object sender, EventArgs e)
        {

        }

        private void btSource_Click(object sender, EventArgs e)
        {
            string path = File_Function.OpenDialog("Dữ liệu", "*");

            if (path != null)
            {
                tbSource.Text = path;
            }
        }

        private void btDestination_Click(object sender, EventArgs e)
        {

        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
