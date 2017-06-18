using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;

namespace QuanLyKinhDoanh
{
    public partial class UcOrderIndex : UserControl
    {
        private UserControl uc;

        public UcOrderIndex()
        {
            InitializeComponent();
        }

        private void LoadResource()
        {
            try
            {
                pbOrder.Image = Image.FromFile(ConstantResource.KHACHHANG_ICON_KHACHHANG_INDEX);
                pbStatistics.Image = Image.FromFile(ConstantResource.KHACHHANG_ICON_KHACHHANG_GROUP_INDEX);
            }
            catch
            {
                MessageBox.Show(Constant.MESSAGE_ERROR_MISSING_RESOURCE, Constant.CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Dispose();
            }
        }

        private void UcOrderIndex_Load(object sender, EventArgs e)
        {
            LoadResource();

            pnSelect.Location = CommonFunc.SetWidthCenter(this.Size, pnSelect.Size, Constant.DEFAULT_TOP_HEIGHT);

            FormMain.isEditing = false;

            InitPermission();

            this.BringToFront();
        }

        private void InitPermission()
        {
            if (FormMain.user.IdGroup != Constant.ID_GROUP_ADMIN)
            {
                CommonFunc.NewControl(this.Controls, ref uc, new UcOrder());
            }
        }

        private void pbOrder_Click(object sender, EventArgs e)
        {
            CommonFunc.NewControl(this.Controls, ref uc, new UcOrder());
        }

        private void pbOrder_MouseEnter(object sender, EventArgs e)
        {
            pbOrder.Image = Image.FromFile(ConstantResource.KHACHHANG_ICON_KHACHHANG_INDEX_MOUSEOVER);
            lbSanPham.ForeColor = Constant.COLOR_MOUSEOVER;
        }

        private void pbOrder_MouseLeave(object sender, EventArgs e)
        {
            pbOrder.Image = Image.FromFile(ConstantResource.KHACHHANG_ICON_KHACHHANG_INDEX);
            lbSanPham.ForeColor = Constant.COLOR_NORMAL;
        }
    }
}
