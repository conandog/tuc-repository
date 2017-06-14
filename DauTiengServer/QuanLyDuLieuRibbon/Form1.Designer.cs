namespace QuanLyDuLieuRibbon
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem_Info = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonOrbMenuItem_Quit = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonTab_Home = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel_First_tabHome = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_Map = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel_Second_tabHome = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_Info = new System.Windows.Forms.RibbonButton();
            this.ribbonTab_FileManager = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel_First_tabFileManager = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_FileData = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel_Second_tabFileManager = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_AddListFile = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_InitRoot = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Text = "Trang Chủ";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel1);
            this.ribbonTab2.Panels.Add(this.ribbonPanel2);
            this.ribbonTab2.Text = "Quản Lý Dữ Liệu";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Text = "Dữ liệu Dầu Tiếng";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Text = "Thêm mới dữ liệu";
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem_Info);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem_Quit);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 163);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "File";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(944, 158);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab_Home);
            this.ribbon1.Tabs.Add(this.ribbonTab_FileManager);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "File";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonOrbMenuItem_Info
            // 
            this.ribbonOrbMenuItem_Info.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem_Info.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem_Info.Image")));
            this.ribbonOrbMenuItem_Info.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem_Info.SmallImage")));
            this.ribbonOrbMenuItem_Info.Text = "Thông tin phần mềm";
            // 
            // ribbonOrbMenuItem_Quit
            // 
            this.ribbonOrbMenuItem_Quit.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem_Quit.Image = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem_Quit.Image")));
            this.ribbonOrbMenuItem_Quit.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonOrbMenuItem_Quit.SmallImage")));
            this.ribbonOrbMenuItem_Quit.Text = "Thoát";
            // 
            // ribbonTab_Home
            // 
            this.ribbonTab_Home.Panels.Add(this.ribbonPanel_First_tabHome);
            this.ribbonTab_Home.Panels.Add(this.ribbonPanel_Second_tabHome);
            this.ribbonTab_Home.Text = "Trang Chủ";
            // 
            // ribbonPanel_First_tabHome
            // 
            this.ribbonPanel_First_tabHome.Items.Add(this.ribbonButton_Map);
            this.ribbonPanel_First_tabHome.Text = "     Bản đồ    .  ";
            // 
            // ribbonButton_Map
            // 
            this.ribbonButton_Map.Image = global::QuanLyDuLieuRibbon.Properties.Resources.rsz_ico_maps_3;
            this.ribbonButton_Map.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_Map.SmallImage")));
            this.ribbonButton_Map.Click += new System.EventHandler(this.ribbonButton_Map_Click);
            // 
            // ribbonPanel_Second_tabHome
            // 
            this.ribbonPanel_Second_tabHome.Items.Add(this.ribbonButton_Info);
            this.ribbonPanel_Second_tabHome.Text = "Thông tin đề tài";
            // 
            // ribbonButton_Info
            // 
            this.ribbonButton_Info.Image = global::QuanLyDuLieuRibbon.Properties.Resources.rsz_accounting_purchase_order_icon;
            this.ribbonButton_Info.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_Info.SmallImage")));
            this.ribbonButton_Info.Text = "";
            this.ribbonButton_Info.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.ribbonButton_Info.Click += new System.EventHandler(this.ribbonButton_Info_Click);
            // 
            // ribbonTab_FileManager
            // 
            this.ribbonTab_FileManager.Panels.Add(this.ribbonPanel_First_tabFileManager);
            this.ribbonTab_FileManager.Panels.Add(this.ribbonPanel_Second_tabFileManager);
            this.ribbonTab_FileManager.Panels.Add(this.ribbonPanel3);
            this.ribbonTab_FileManager.Text = "Quản Lý Dữ Liệu";
            // 
            // ribbonPanel_First_tabFileManager
            // 
            this.ribbonPanel_First_tabFileManager.Items.Add(this.ribbonButton_FileData);
            this.ribbonPanel_First_tabFileManager.Text = "Dữ liệu Dầu Tiếng";
            // 
            // ribbonButton_FileData
            // 
            this.ribbonButton_FileData.Image = global::QuanLyDuLieuRibbon.Properties.Resources.rsz_1user_cards_512;
            this.ribbonButton_FileData.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_FileData.SmallImage")));
            this.ribbonButton_FileData.Click += new System.EventHandler(this.ribbonButton_FileData_Click);
            // 
            // ribbonPanel_Second_tabFileManager
            // 
            this.ribbonPanel_Second_tabFileManager.Items.Add(this.ribbonButton_AddListFile);
            this.ribbonPanel_Second_tabFileManager.Text = "Thêm mới dữ liệu";
            // 
            // ribbonButton_AddListFile
            // 
            this.ribbonButton_AddListFile.Image = global::QuanLyDuLieuRibbon.Properties.Resources.rsz_1unnamed;
            this.ribbonButton_AddListFile.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_AddListFile.SmallImage")));
            this.ribbonButton_AddListFile.Click += new System.EventHandler(this.ribbonButton_AddListFile_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.ribbonButton_InitRoot);
            this.ribbonPanel3.Text = "Khởi tạo thư mục";
            // 
            // ribbonButton_InitRoot
            // 
            this.ribbonButton_InitRoot.Image = global::QuanLyDuLieuRibbon.Properties.Resources.rsz_tpdkdesign_net_refresh_cl_windows_view_detail_8;
            this.ribbonButton_InitRoot.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_InitRoot.SmallImage")));
            this.ribbonButton_InitRoot.Click += new System.EventHandler(this.ribbonButton_InitRoot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 661);
            this.Controls.Add(this.ribbon1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(960, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ DỮ LIỆU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab_Home;
        private System.Windows.Forms.RibbonPanel ribbonPanel_First_tabHome;
        private System.Windows.Forms.RibbonPanel ribbonPanel_Second_tabHome;
        private System.Windows.Forms.RibbonTab ribbonTab_FileManager;
        private System.Windows.Forms.RibbonPanel ribbonPanel_First_tabFileManager;
        private System.Windows.Forms.RibbonPanel ribbonPanel_Second_tabFileManager;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem_Info;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem_Quit;
        private System.Windows.Forms.RibbonButton ribbonButton_Info;
        private System.Windows.Forms.RibbonButton ribbonButton_Map;
        private System.Windows.Forms.RibbonButton ribbonButton_FileData;
        private System.Windows.Forms.RibbonButton ribbonButton_AddListFile;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbonButton_InitRoot;
    }
}

