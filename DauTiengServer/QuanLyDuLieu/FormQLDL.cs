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
        public static string root = @"C:\DuLieuHoDauTieng";
        private UserControl currentUc;
        private static bool isWarningClosing = false;

        public FormQLDL()
        {
            InitializeComponent();
        }

        private void FormQLDL_Load(object sender, EventArgs e)
        {
            btTrangChu_Click(null, null);
        }

        private void EnableAllButtons()
        {
            btTrangChu.Enabled = true;
            btQuanLyDuLieu.Enabled = true;
            btThemDuLieu.Enabled = true;
        }

        private bool WarningClosingDialog()
        {
            if (isWarningClosing)
            {
                return MessageBox.Show(Constant.MESSAGE_EXIT, Constant.CAPTION_WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes;
            }

            return true;
        }

        private void btTrangChu_Click(object sender, EventArgs e)
        {
            if (!WarningClosingDialog())
            {
                return;
            }

            isWarningClosing = false;
            EnableAllButtons();
            btTrangChu.Enabled = false;
            CommonFunc.NewControl(pnBody.Controls, ref currentUc, new UcTrangChu());
        }

        private void btQuanLyDuLieu_Click(object sender, EventArgs e)
        {
            if (!WarningClosingDialog())
            {
                return;
            }

            isWarningClosing = false;
            EnableAllButtons();
            CommonFunc.NewControl(pnBody.Controls, ref currentUc, new UcQLDL());
        }

        private void btThemDuLieu_Click(object sender, EventArgs e)
        {
            if (!WarningClosingDialog())
            {
                return;
            }

            isWarningClosing = true;
            EnableAllButtons();
            btThemDuLieu.Enabled = false;
            CommonFunc.NewControl(pnBody.Controls, ref currentUc, new UcThemDL());
        }
    }
}
