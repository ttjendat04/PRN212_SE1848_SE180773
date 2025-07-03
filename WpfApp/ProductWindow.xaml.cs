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
using BusinessObjects;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService = new ProductService();
        bool isComplete = false;
        public ProductWindow()
        {
            InitializeComponent();
            
            isComplete = false;
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
            isComplete = true;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isComplete == false)
                return; // vi thuc hien thao tac du lieu
            if (e.AddedItems.Count < 0)
                return;  // vi nguoi dung chua chon dong nao
            //lay Product dang chon ra:
            Product p = e.AddedItems[0] as Product;
            if (p == null)
                return; // khong co dong nao duoc chon
            txtId.Text = p.Id.ToString();
            txtName.Text = p.Name;
            txtQuantity.Text = p.Quantity.ToString();
            txtPrice.Text = p.Price.ToString();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = new Product();
                p.Id = int.Parse(txtId.Text);
                p.Name = txtName.Text;
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Price = double.Parse(txtPrice.Text);

                bool kq = productService.SaveProduct(p);
                if (kq)
                {
                    lvProduct.ItemsSource = null; // reset the item source
                    lvProduct.ItemsSource = productService.GetProducts(); // rebind the item source
                }
                isComplete = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:   {ex.Message}");
                return;






            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isComplete = false;
                int id = int.Parse(txtId.Text);
                Product p = productService.GetProduct(id);
                if (p == null)
                    return;// không tìm thấy sản phẩm
                           // nếu tìm thấy thì thay đổi dữ liệu
                p.Name = txtName.Text;
                p.Quantity = int.Parse(txtQuantity.Text);
                p.Price = int.Parse(txtPrice.Text);

                bool kq = productService.UpdateProduct(p);
                if (kq == true)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }


                isComplete = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật");
                return;
            }
            
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Luôn luôn phải xác thực có muốn xóa hay không
                MessageBoxResult ret = MessageBox.Show(
                    "Bạn có chắc muốn xóa sản phẩm này không?", // Nội dung hỏi của cửa sổ
                    "Xác nhận xóa",// tiêu đề của cửa sổ
                    MessageBoxButton.YesNo, //hiển thị 2 lựa chọn YES-NO cho người dùng chọn
                    MessageBoxImage.Question// hiển thị biểu tượng câu hỏi
                    );
                if (ret == MessageBoxResult.No)
                    return; // nếu người dùng chọn No tức là không xóa
                isComplete = false;
                int id = int.Parse(txtId.Text);
                bool kq = productService.DeleteProduct(id);
                if (kq == false) return;

                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = productService.GetProducts();
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa bị lỗi: " + ex.Message);
                return;
            }
        }
    }
}
