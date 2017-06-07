using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}
