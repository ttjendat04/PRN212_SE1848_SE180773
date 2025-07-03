using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Xml.Schema;
using MyStoreWFPApp_EntityFramework.Models;

namespace MyStoreWFPApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public LoginWindow()
        {
            InitializeComponent();
            ChangeBackground();
        }

        private void ChangeBackground()
        {
            //đổi màu nền cho nút thoát:
            LinearGradientBrush bush = new LinearGradientBrush();
            bush.GradientStops.Add(new GradientStop(Colors.Magenta, 0.0));
            bush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.1));
            bush.GradientStops.Add(new GradientStop(Colors.Magenta, 1.0));
            btnThoat.Background =  bush;

            //đổi màu nền cho nút đăng nhập:
            RadialGradientBrush bush2 = new RadialGradientBrush();
            bush2.GradientOrigin = new Point(0.5, 0.75);
            bush2.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            bush2.GradientStops.Add(new GradientStop(Colors.White, 0.5));
            bush2.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));
            btnDangNhap.Background = bush2;


        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password.Trim();
            AccountMember am = context.AccountMembers
                .FirstOrDefault(x => x.EmailAddress == email && x.MemberPassword == password);

            if (am == null)
            {
                MessageBox.Show("Đăng nhập thát bại - vui lòng kiểm tra lại account",
                    "Thông báo",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            else
            {
                if (am.MemberRole == 1)
                {
                    MessageBox.Show("Đăng nhập Admin thành công",
                        "Success Login",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    AdminWindow aw = new AdminWindow();
                    aw.Show();
                    Close();
                    return;
                }
                else if (am.MemberRole == 2)
                {
                    MessageBox.Show("Đăng nhập Staff thành công",
                        "Success Login",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    AdminWindow aw = new AdminWindow();
                    aw.Show();
                    Close();
                    return;
                }
                else if (am.MemberRole == 3)
                {
                    MessageBox.Show("Đăng nhập Member thành công",
                        "Succes Login",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    AdminWindow aw = new AdminWindow();
                    aw.Show();
                    Close();
                    return;
                }
            }
        }
    }
}
