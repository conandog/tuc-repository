namespace QuanLyKinhDoanh
{
    partial class UcOrderIndex
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnSelect = new System.Windows.Forms.Panel();
            this.lbNhomSanPham = new System.Windows.Forms.Label();
            this.lbSanPham = new System.Windows.Forms.Label();
            this.pbOrder = new System.Windows.Forms.PictureBox();
            this.pbStatistics = new System.Windows.Forms.PictureBox();
            this.pnSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // pnSelect
            // 
            this.pnSelect.Controls.Add(this.lbNhomSanPham);
            this.pnSelect.Controls.Add(this.lbSanPham);
            this.pnSelect.Controls.Add(this.pbOrder);
            this.pnSelect.Controls.Add(this.pbStatistics);
            this.pnSelect.Location = new System.Drawing.Point(230, 228);
            this.pnSelect.Name = "pnSelect";
            this.pnSelect.Size = new System.Drawing.Size(520, 140);
            this.pnSelect.TabIndex = 5;
            // 
            // lbNhomSanPham
            // 
            this.lbNhomSanPham.AutoSize = true;
            this.lbNhomSanPham.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNhomSanPham.ForeColor = System.Drawing.Color.Gray;
            this.lbNhomSanPham.Location = new System.Drawing.Point(399, 120);
            this.lbNhomSanPham.Name = "lbNhomSanPham";
            this.lbNhomSanPham.Size = new System.Drawing.Size(81, 16);
            this.lbNhomSanPham.TabIndex = 6;
            this.lbNhomSanPham.Text = "THỐNG KÊ";
            // 
            // lbSanPham
            // 
            this.lbSanPham.AutoSize = true;
            this.lbSanPham.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSanPham.ForeColor = System.Drawing.Color.Gray;
            this.lbSanPham.Location = new System.Drawing.Point(38, 120);
            this.lbSanPham.Name = "lbSanPham";
            this.lbSanPham.Size = new System.Drawing.Size(85, 16);
            this.lbSanPham.TabIndex = 4;
            this.lbSanPham.Text = "ĐƠN HÀNG";
            // 
            // pbOrder
            // 
            this.pbOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOrder.Location = new System.Drawing.Point(30, 10);
            this.pbOrder.Name = "pbOrder";
            this.pbOrder.Size = new System.Drawing.Size(100, 100);
            this.pbOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOrder.TabIndex = 0;
            this.pbOrder.TabStop = false;
            this.pbOrder.Click += new System.EventHandler(this.pbOrder_Click);
            this.pbOrder.MouseEnter += new System.EventHandler(this.pbOrder_MouseEnter);
            this.pbOrder.MouseLeave += new System.EventHandler(this.pbOrder_MouseLeave);
            // 
            // pbStatistics
            // 
            this.pbStatistics.BackColor = System.Drawing.Color.Blue;
            this.pbStatistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStatistics.Location = new System.Drawing.Point(390, 10);
            this.pbStatistics.Name = "pbStatistics";
            this.pbStatistics.Size = new System.Drawing.Size(100, 100);
            this.pbStatistics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatistics.TabIndex = 2;
            this.pbStatistics.TabStop = false;
            // 
            // UcOrderIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnSelect);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcOrderIndex";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Load += new System.EventHandler(this.UcOrderIndex_Load);
            this.pnSelect.ResumeLayout(false);
            this.pnSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSelect;
        private System.Windows.Forms.Label lbNhomSanPham;
        private System.Windows.Forms.Label lbSanPham;
        private System.Windows.Forms.PictureBox pbOrder;
        private System.Windows.Forms.PictureBox pbStatistics;
    }
}
