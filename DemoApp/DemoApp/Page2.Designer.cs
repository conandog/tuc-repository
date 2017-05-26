namespace DemoApp
{
    partial class Page2
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btLibrary = new System.Windows.Forms.Button();
            this.pbLibrary = new System.Windows.Forms.PictureBox();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.pbMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLibrary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btLibrary
            // 
            this.btLibrary.Location = new System.Drawing.Point(150, 264);
            this.btLibrary.Name = "btLibrary";
            this.btLibrary.Size = new System.Drawing.Size(100, 23);
            this.btLibrary.TabIndex = 3;
            this.btLibrary.Text = "Thư Viện Ảnh";
            this.toolTip1.SetToolTip(this.btLibrary, "Click vào để xem tiếp");
            this.btLibrary.UseVisualStyleBackColor = true;
            this.btLibrary.Visible = false;
            this.btLibrary.Click += new System.EventHandler(this.btLibrary_Click);
            // 
            // pbLibrary
            // 
            this.pbLibrary.Location = new System.Drawing.Point(0, 0);
            this.pbLibrary.Name = "pbLibrary";
            this.pbLibrary.Size = new System.Drawing.Size(400, 300);
            this.pbLibrary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLibrary.TabIndex = 2;
            this.pbLibrary.TabStop = false;
            this.pbLibrary.Tag = "";
            this.pbLibrary.Visible = false;
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::DemoApp.Properties.Resources.loader;
            this.pbLoading.Location = new System.Drawing.Point(386, 383);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(80, 80);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoading.TabIndex = 1;
            this.pbLoading.TabStop = false;
            this.toolTip1.SetToolTip(this.pbLoading, "CÔNG TRÌNH HỒ\r\nDẦU TIẾNG");
            this.pbLoading.Click += new System.EventHandler(this.pbLoading_Click);
            // 
            // pbMap
            // 
            this.pbMap.Image = global::DemoApp.Properties.Resources._1;
            this.pbMap.Location = new System.Drawing.Point(0, 0);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(1000, 554);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            // 
            // Page2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 575);
            this.Controls.Add(this.btLibrary);
            this.Controls.Add(this.pbLibrary);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.pbMap);
            this.Name = "Page2";
            this.Text = "Page2";
            this.Load += new System.EventHandler(this.Page2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLibrary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbLibrary;
        private System.Windows.Forms.Button btLibrary;
    }
}