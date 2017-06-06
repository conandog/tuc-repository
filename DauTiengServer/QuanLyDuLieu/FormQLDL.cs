using Library;
using QuanLyDuLieu.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuLieu
{
    public partial class FormQLDL : Form
    {
        UserControl uc;

        public FormQLDL()
        {
            InitializeComponent();
        }

        private void FormQLDL_Load(object sender, EventArgs e)
        {

        }

        private void btTrangChu_Click(object sender, EventArgs e)
        {

        }

        private void btQuanLyDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void btThemDuLieu_Click(object sender, EventArgs e)
        {
            CommonFunc.NewControl(pnBody.Controls, ref uc, new UcThemDL());
        }
    }
}
