namespace QuanLyDuLieuRibbon
{
    partial class MapHoDauTieng_Form
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
            DevExpress.Utils.Animation.Transition transition2 = new DevExpress.Utils.Animation.Transition();
            DevExpress.Utils.Animation.SlideFadeTransition slideFadeTransition2 = new DevExpress.Utils.Animation.SlideFadeTransition();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.btn_MapCenter = new System.Windows.Forms.Button();
            this.btn_MapZoomOut = new System.Windows.Forms.Button();
            this.btn_MapZoomIn = new System.Windows.Forms.Button();
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(721, 366);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.gmap.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gmap_OnPolygonClick);
            // 
            // btn_MapCenter
            // 
            this.btn_MapCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MapCenter.Location = new System.Drawing.Point(685, 330);
            this.btn_MapCenter.Name = "btn_MapCenter";
            this.btn_MapCenter.Size = new System.Drawing.Size(24, 24);
            this.btn_MapCenter.TabIndex = 1;
            this.btn_MapCenter.Text = "O";
            this.btn_MapCenter.UseVisualStyleBackColor = true;
            this.btn_MapCenter.Click += new System.EventHandler(this.btn_MapCenter_Click);
            // 
            // btn_MapZoomOut
            // 
            this.btn_MapZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MapZoomOut.Location = new System.Drawing.Point(685, 300);
            this.btn_MapZoomOut.Name = "btn_MapZoomOut";
            this.btn_MapZoomOut.Size = new System.Drawing.Size(24, 24);
            this.btn_MapZoomOut.TabIndex = 2;
            this.btn_MapZoomOut.Text = "-";
            this.btn_MapZoomOut.UseVisualStyleBackColor = true;
            this.btn_MapZoomOut.Click += new System.EventHandler(this.btn_MapZoomOut_Click);
            // 
            // btn_MapZoomIn
            // 
            this.btn_MapZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MapZoomIn.Location = new System.Drawing.Point(685, 270);
            this.btn_MapZoomIn.Name = "btn_MapZoomIn";
            this.btn_MapZoomIn.Size = new System.Drawing.Size(24, 24);
            this.btn_MapZoomIn.TabIndex = 3;
            this.btn_MapZoomIn.Text = "+";
            this.btn_MapZoomIn.UseVisualStyleBackColor = true;
            this.btn_MapZoomIn.Click += new System.EventHandler(this.btn_MapZoomIn_Click);
            // 
            // transitionManager1
            // 
            this.transitionManager1.ShowWaitingIndicator = false;
            transition2.Control = this.labelControl1;
            slideFadeTransition2.Parameters.Background = System.Drawing.Color.Empty;
            transition2.TransitionType = slideFadeTransition2;
            this.transitionManager1.Transitions.Add(transition2);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(99, 122);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "labelControl1";
            this.labelControl1.Visible = false;
            // 
            // MapHoDauTieng_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 366);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_MapZoomIn);
            this.Controls.Add(this.btn_MapZoomOut);
            this.Controls.Add(this.btn_MapCenter);
            this.Controls.Add(this.gmap);
            this.Name = "MapHoDauTieng_Form";
            this.Text = "MapHoDauTieng_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Button btn_MapCenter;
        private System.Windows.Forms.Button btn_MapZoomOut;
        private System.Windows.Forms.Button btn_MapZoomIn;
        private DevExpress.Utils.Animation.TransitionManager transitionManager1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}