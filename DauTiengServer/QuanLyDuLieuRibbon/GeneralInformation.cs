using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QuanLyDuLieuRibbon
{
    public partial class GeneralInformation : Form
    {
        public GeneralInformation()
        {
            InitializeComponent();
            LoadMap();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public void LoadMap()
        {
            Font font;

            XmlDocument doc = new XmlDocument();
            doc.Load("Information.xml");

            string title = string.Empty;
            string l1 = string.Empty;
            string l2 = string.Empty;
            string l3 = string.Empty;
            string l4 = string.Empty;
            string l5 = string.Empty;
            string l6 = string.Empty;
            string l7 = string.Empty;
            string l8 = string.Empty;
            string l9 = string.Empty;

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string element = node.Name;
                string text = node.InnerText;
                Console.WriteLine(element + "\n");
                Console.WriteLine(text + "\n");
                switch (element)
                {
                    case "title":
                        font = new Font("Arial", 20, FontStyle.Bold);
                        label1.Text = text;
                        label1.Font = font;
                        break;
                    case "line1":
                        font = new Font("Arial", 12, FontStyle.Regular);
                        label2.Text = text;
                        label2.Font = font;
                        break;
                    case "line2":
                        font = new Font("Arial", 12, FontStyle.Regular);
                        label3.Text = text;
                        label3.Font = font;
                        break;
                    case "line3":
                        font = new Font("Arial", 12, FontStyle.Regular);
                        label4.Text = text;
                        label4.Font = font;
                        break;
                    case "line4":
                        font = new Font("Arial", 12, FontStyle.Regular);
                        label5.Text = text;
                        label5.Font = font;
                        break;
                    case "line5":
                        font = new Font("Arial", 12, FontStyle.Regular);
                        label6.Text = text;
                        label6.Font = font;
                        break;
                    case "line6":
                        font = new Font("Arial", 12, FontStyle.Regular);
                        label7.Text = text;
                        label7.Font = font;
                        break;
                    case "line7":
                        font = new Font("Arial", 12, FontStyle.Regular);
                        label8.Text = text;
                        label8.Font = font;
                        break;
                    case "line8":
                        font = new Font("Arial", 12, FontStyle.Regular);
                        label9.Text = text;
                        label9.Font = font;
                        break;
                    case "line9":
                        font = new Font("Arial", 10, FontStyle.Regular);
                        label10.Text = text;
                        label10.Font = font;
                        break;
                    default:
                        return;
                }

            }
        }
    }
}
