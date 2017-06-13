namespace QuanLyDuLieuRibbon
{
    partial class DataTransfer
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
            this.ucThemDL1 = new QuanLyDuLieu.GUI.UcThemDL();
            this.SuspendLayout();
            // 
            // ucThemDL1
            // 
            this.ucThemDL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucThemDL1.Location = new System.Drawing.Point(20, 0);
            this.ucThemDL1.Name = "ucThemDL1";
            this.ucThemDL1.Size = new System.Drawing.Size(744, 561);
            this.ucThemDL1.TabIndex = 0;
            // 
            // DataTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ucThemDL1);
            this.Name = "DataTransfer";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.Text = "DataTransfer";
            this.ResumeLayout(false);

        }

        #endregion

        private QuanLyDuLieu.GUI.UcThemDL ucThemDL1;
    }
}