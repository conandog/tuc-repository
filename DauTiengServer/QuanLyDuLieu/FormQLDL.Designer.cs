namespace QuanLyDuLieu
{
    partial class FormQLDL
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btTrangChu = new System.Windows.Forms.Button();
            this.btQuanLyDuLieu = new System.Windows.Forms.Button();
            this.btThemDuLieu = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnBody = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 732);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.btTrangChu);
            this.flowLayoutPanel2.Controls.Add(this.btQuanLyDuLieu);
            this.flowLayoutPanel2.Controls.Add(this.btThemDuLieu);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 33);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1002, 100);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btTrangChu
            // 
            this.btTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTrangChu.Location = new System.Drawing.Point(20, 3);
            this.btTrangChu.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btTrangChu.Name = "btTrangChu";
            this.btTrangChu.Size = new System.Drawing.Size(90, 90);
            this.btTrangChu.TabIndex = 0;
            this.btTrangChu.Text = "Trang chủ";
            this.btTrangChu.UseVisualStyleBackColor = true;
            this.btTrangChu.Click += new System.EventHandler(this.btTrangChu_Click);
            // 
            // btQuanLyDuLieu
            // 
            this.btQuanLyDuLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuanLyDuLieu.Location = new System.Drawing.Point(150, 3);
            this.btQuanLyDuLieu.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btQuanLyDuLieu.Name = "btQuanLyDuLieu";
            this.btQuanLyDuLieu.Size = new System.Drawing.Size(90, 90);
            this.btQuanLyDuLieu.TabIndex = 1;
            this.btQuanLyDuLieu.Text = "Quản lý dữ liệu";
            this.btQuanLyDuLieu.UseVisualStyleBackColor = true;
            this.btQuanLyDuLieu.Click += new System.EventHandler(this.btQuanLyDuLieu_Click);
            // 
            // btThemDuLieu
            // 
            this.btThemDuLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThemDuLieu.Location = new System.Drawing.Point(280, 3);
            this.btThemDuLieu.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btThemDuLieu.Name = "btThemDuLieu";
            this.btThemDuLieu.Size = new System.Drawing.Size(90, 90);
            this.btThemDuLieu.TabIndex = 2;
            this.btThemDuLieu.Text = "Thêm dữ liệu";
            this.btThemDuLieu.UseVisualStyleBackColor = true;
            this.btThemDuLieu.Click += new System.EventHandler(this.btThemDuLieu_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.pnBody, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 143);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1002, 586);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // pnBody
            // 
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody.Location = new System.Drawing.Point(53, 13);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(895, 560);
            this.pnBody.TabIndex = 0;
            // 
            // FormQLDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1024, 771);
            this.Name = "FormQLDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ DỮ LIỆU";
            this.Load += new System.EventHandler(this.FormQLDL_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btTrangChu;
        private System.Windows.Forms.Button btQuanLyDuLieu;
        private System.Windows.Forms.Button btThemDuLieu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnBody;
    }
}

