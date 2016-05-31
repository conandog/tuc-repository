using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller.Common;
using Model;
using System.IO;

namespace QuanLyDonHang
{
    /// <summary>
    /// Interaction logic for ConnectDatabaseWD.xaml
    /// </summary>
    public partial class ConnectDatabaseWD : Window
    {
        public ConnectDatabaseWD()
        {
            InitializeComponent();
        }

        private void WindowConnectDatabase_Loaded(object sender, RoutedEventArgs e)
        {
            if (CommonFunction.AutoConnect())
            {
                LoginWindow _loginWD = new LoginWindow();
                _loginWD.Show();
                WindowConnectDatabase.Close();
            }
            else
            {
                SQLConnection.WindowsAuthentication = true;
            }
        }


        private void ValidateInput()
        {
            if (rbWA.IsChecked.Value)
            {
                if (!String.IsNullOrEmpty(tbServer.Text))
                {
                    btConnect.IsEnabled = true;
                }
                else
                {
                    btConnect.IsEnabled = false;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(tbServer.Text) &&
                    !String.IsNullOrEmpty(tbUsername.Text))
                {
                    btConnect.IsEnabled = true;
                }
                else
                {
                    btConnect.IsEnabled = false;
                }
            }
        }

        private void ConnectDB()
        {
            try
            {
                SQLConnection.ServerName = tbServer.Text;
                SQLConnection.UserName = tbUsername.Text;
                SQLConnection.Password = pbPassword.Password;

                if (!SQLConnection.NewConnection())
                {
                    MessageBox.Show("Không thể kết nối đến server!");
                    tbServer.Focus();
                    tbServer.SelectAll();
                }
                else
                {
                    WriteConfiguration();
                    //open main window
                    LoginWindow _loginWD = new LoginWindow();
                    _loginWD.Show();
                    WindowConnectDatabase.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void WriteConfiguration()
        {
            try
            {
                if (rbWA.IsChecked.Value)
                {
                    CommonFunction.WriteConfiguration(true, tbServer.Text, tbUsername.Text, pbPassword.Password);
                }
                else
                {
                    CommonFunction.WriteConfiguration(false, tbServer.Text, tbUsername.Text, pbPassword.Password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbWA_Checked(object sender, RoutedEventArgs e)
        {
            tbUsername.Text = String.Empty;
            tbUsername.IsEnabled = false;
            pbPassword.Password = String.Empty;
            pbPassword.IsEnabled = false;
            SQLConnection.WindowsAuthentication = true;
            ValidateInput();
        }

        private void rbSSA_Checked(object sender, RoutedEventArgs e)
        {
            tbUsername.IsEnabled = true;
            pbPassword.IsEnabled = true;
            SQLConnection.WindowsAuthentication = false;
            ValidateInput();
        }

        private void tbServer_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInput();
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInput();
        }

        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectDB();
        }
    }
}
