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

namespace HellloWpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            //Giả lập account là:
            //User name là Obama, password 124
            if(txtUserName.Text=="obama" &&
                txtPassword.Password=="124")
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                //Đóng cửa sổ đăng nhập:
                Close();
                //hoặc gọi:
                //btnThoat.RaiseEvent(e);
            }
            else
            {
                MessageBox.Show("Sai rồi má");
                
            }    
        }
    }
}
