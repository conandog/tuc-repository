namespace QuanLyDuLieuRibbon
{
    partial class InitialRoot
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSave = new System.Windows.Forms.Button();
            this.btn_DeleteNode = new System.Windows.Forms.Button();
            this.btn_AddChildNode = new System.Windows.Forms.Button();
            this.treeView_Directory = new System.Windows.Forms.TreeView();
            this.tbRootPath = new System.Windows.Forms.TextBox();
            this.btnShowDialog = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.661631F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.33837F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.416919F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.58308F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(683, 331);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.btn_DeleteNode);
            this.panel1.Controls.Add(this.btn_AddChildNode);
            this.panel1.Controls.Add(this.treeView_Directory);
            this.panel1.Controls.Add(this.tbRootPath);
            this.panel1.Controls.Add(this.btnShowDialog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(14, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 317);
            this.panel1.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Location = new System.Drawing.Point(400, 111);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(116, 23);
            this.btSave.TabIndex = 5;
            this.btSave.Text = "Lưu";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btn_DeleteNode
            // 
            this.btn_DeleteNode.Enabled = false;
            this.btn_DeleteNode.Location = new System.Drawing.Point(400, 62);
            this.btn_DeleteNode.Name = "btn_DeleteNode";
            this.btn_DeleteNode.Size = new System.Drawing.Size(116, 23);
            this.btn_DeleteNode.TabIndex = 4;
            this.btn_DeleteNode.Text = "Xóa Thư Mục";
            this.btn_DeleteNode.UseVisualStyleBackColor = true;
            this.btn_DeleteNode.Click += new System.EventHandler(this.btn_DeleteNode_Click);
            // 
            // btn_AddChildNode
            // 
            this.btn_AddChildNode.Enabled = false;
            this.btn_AddChildNode.Location = new System.Drawing.Point(400, 33);
            this.btn_AddChildNode.Name = "btn_AddChildNode";
            this.btn_AddChildNode.Size = new System.Drawing.Size(116, 23);
            this.btn_AddChildNode.TabIndex = 3;
            this.btn_AddChildNode.Text = "Thêm Thư Mục Con";
            this.btn_AddChildNode.UseVisualStyleBackColor = true;
            this.btn_AddChildNode.Click += new System.EventHandler(this.btn_AddChildNode_Click);
            // 
            // treeView_Directory
            // 
            this.treeView_Directory.Enabled = false;
            this.treeView_Directory.Location = new System.Drawing.Point(4, 33);
            this.treeView_Directory.Name = "treeView_Directory";
            this.treeView_Directory.Size = new System.Drawing.Size(389, 202);
            this.treeView_Directory.TabIndex = 2;
            this.treeView_Directory.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_Directory_AfterLabelEdit);
            this.treeView_Directory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Directory_AfterSelect);
            this.treeView_Directory.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Directory_NodeMouseDoubleClick);
            // 
            // tbRootPath
            // 
            this.tbRootPath.Location = new System.Drawing.Point(123, 5);
            this.tbRootPath.Name = "tbRootPath";
            this.tbRootPath.ReadOnly = true;
            this.tbRootPath.Size = new System.Drawing.Size(270, 20);
            this.tbRootPath.TabIndex = 1;
            this.tbRootPath.TextChanged += new System.EventHandler(this.tbRootPath_TextChanged);
            // 
            // btnShowDialog
            // 
            this.btnShowDialog.Location = new System.Drawing.Point(3, 3);
            this.btnShowDialog.Name = "btnShowDialog";
            this.btnShowDialog.Size = new System.Drawing.Size(114, 23);
            this.btnShowDialog.TabIndex = 0;
            this.btnShowDialog.Text = "Chọn thư mục gốc";
            this.btnShowDialog.UseVisualStyleBackColor = true;
            this.btnShowDialog.Click += new System.EventHandler(this.btnShowDialog_Click);
            // 
            // InitialRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 331);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InitialRoot";
            this.Text = "InitialRoot";
            this.Load += new System.EventHandler(this.InitialRoot_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tbRootPath;
        private System.Windows.Forms.Button btn_DeleteNode;
        private System.Windows.Forms.Button btn_AddChildNode;
        private System.Windows.Forms.TreeView treeView_Directory;
        private System.Windows.Forms.Button btSave;
    }
}