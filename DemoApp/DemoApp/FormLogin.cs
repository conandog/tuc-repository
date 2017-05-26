using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            lbError.Text = String.Empty;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // look for the expected key
            if (keyData == Keys.Enter)
            {
                Login();

                // eat the message to prevent it from being passed on
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ValidateInput()
        {
            if (!string.IsNullOrEmpty(tbUserName.Text) &&
                !string.IsNullOrEmpty(tbPassword.Text)
                )
            {
                btLogin.Enabled = true;
            }
            else
            {
                btLogin.Enabled = false;
            }
        }

        private void Login()
        {
            if (tbUserName.Text == "admin" && tbPassword.Text == "admin")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lbError.Text = "Tên hoặc mật khẩu không chính xác! Vui lòng nhập lại";
                tbUserName.Focus();
                tbUserName.SelectAll();
            }
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            lbError.Text = string.Empty;
            ValidateInput();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            lbError.Text = string.Empty;
            ValidateInput();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
        }
    }
}
