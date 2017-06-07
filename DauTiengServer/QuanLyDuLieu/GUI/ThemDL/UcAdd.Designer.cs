namespace QuanLyDuLieu.GUI
{
    partial class UcAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAdd));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btDestination = new System.Windows.Forms.Button();
            this.tbDestination = new System.Windows.Forms.TextBox();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.btSource = new System.Windows.Forms.Button();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.btDestination, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbDestination, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbSource, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btSource, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbDelete, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btDestination
            // 
            this.btDestination.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btDestination.Location = new System.Drawing.Point(418, 13);
            this.btDestination.Name = "btDestination";
            this.btDestination.Size = new System.Drawing.Size(44, 23);
            this.btDestination.TabIndex = 7;
            this.btDestination.Text = "Đích";
            this.btDestination.UseVisualStyleBackColor = true;
            this.btDestination.Click += new System.EventHandler(this.btDestination_Click);
            // 
            // tbDestination
            // 
            this.tbDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestination.Location = new System.Drawing.Point(468, 15);
            this.tbDestination.Name = "tbDestination";
            this.tbDestination.ReadOnly = true;
            this.tbDestination.Size = new System.Drawing.Size(289, 20);
            this.tbDestination.TabIndex = 4;
            // 
            // tbSource
            // 
            this.tbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSource.Location = new System.Drawing.Point(63, 15);
            this.tbSource.Name = "tbSource";
            this.tbSource.ReadOnly = true;
            this.tbSource.Size = new System.Drawing.Size(289, 20);
            this.tbSource.TabIndex = 3;
            // 
            // btSource
            // 
            this.btSource.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btSource.Location = new System.Drawing.Point(3, 13);
            this.btSource.Name = "btSource";
            this.btSource.Size = new System.Drawing.Size(54, 23);
            this.btSource.TabIndex = 6;
            this.btSource.Text = "Nguồn";
            this.btSource.UseVisualStyleBackColor = true;
            this.btSource.Click += new System.EventHandler(this.btSource_Click);
            // 
            // pbDelete
            // 
            this.pbDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbDelete.Image = ((System.Drawing.Image)(resources.GetObject("pbDelete.Image")));
            this.pbDelete.Location = new System.Drawing.Point(770, 15);
            this.pbDelete.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(20, 20);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 8;
            this.pbDelete.TabStop = false;
            this.pbDelete.Click += new System.EventHandler(this.pbDelete_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "=====>";
            // 
            // UcAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcAdd";
            this.Size = new System.Drawing.Size(800, 50);
            this.Load += new System.EventHandler(this.UcAdd_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbDestination;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Button btDestination;
        private System.Windows.Forms.Button btSource;
        private System.Windows.Forms.PictureBox pbDelete;
        private System.Windows.Forms.Label label1;
    }
}
