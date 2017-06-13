using QuanLyDuLieuRibbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuLieu.GUI
{
    public partial class FormDestination : Form
    {
        private string root = Form1.root;
        private List<Button> listButton = new List<Button>();
        public string destination
        {
            get
            {
                return tbDestination.Text;
            }
        }

        public FormDestination()
        {
            InitializeComponent();
        }

        private void FormDestination_Load(object sender, EventArgs e)
        {
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
            button4.Click += Button_Click;
            button5.Click += Button_Click;

            listButton.Add(button1);
            listButton.Add(button2);
            listButton.Add(button3);
            listButton.Add(button4);
            listButton.Add(button5);

            tbDestination.Text = root;
            LoadAllFolderNames(root);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            root = Path.Combine(root, ((Button)sender).Text);
            tbDestination.Text = root;
            LoadAllFolderNames(root);
        }

        private void LoadAllFolderNames(string path)
        {
            for (int i = 0; i < 5; i++)
            {
                listButton[i].Visible = false;
            }

            string[] listPath = Directory.GetDirectories(path);

            if (listPath.Length > 0)
            {
                for (int i = 0; i < listPath.Length && i < 5; i++)
                {
                    DirectoryInfo info = new DirectoryInfo(listPath[i]);
                    listButton[i].Text = info.Name;
                    listButton[i].Visible = true;
                }

                listButton[0].Select();
            }
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbFinish_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
