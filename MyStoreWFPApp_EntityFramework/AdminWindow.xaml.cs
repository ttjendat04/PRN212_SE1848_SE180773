using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using System.Xaml;
using System.Xml.Linq;
using MyStoreWFPApp_EntityFramework.Models;

namespace MyStoreWFPApp_EntityFramework
{
    /// <summary>
    /// Interaction logic for AdminWindow1.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        //MyStoreContext context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesIntoTreeView();
        }

        private void LoadCategoriesIntoTreeView()
        {
            //Tạo gốc cây cho TreeView
            TreeViewItem root = new TreeViewItem();
            root.Header = " Kho hàng Cát Lái";
            tvCategory.Items.Add(root);
            //Truy vấn toàn bộ danh mục:
            var caterories = context.Categories.ToList();
            //Đưa danh mục lên TreeView:
            foreach (var category in caterories)
            {
                //Tạo node danh myujc:
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);

                //lọc sản phẩm theo danh mục:
                var products = context.Products.
                    Where(x => x.CategoryId == category.CategoryId).
                    ToList();

                // nạp product vào node danh mục tương ứng:
                foreach (var product in products)
                {
                    //Tạo node sản phẩm:
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                }
            }
            root.ExpandSubtree();
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
                return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            if (item == null)
                return;
            Category category = item.Tag as Category;
            if (category == null)
                return;
            LoadProductsIntoListView(category);
        }

        private void LoadProductsIntoListView(Category category)
        {
            //lọc sản phẩm theo danh mục:
            var products = context.Products.
                Where(x => x.CategoryId == category.CategoryId).
                ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
            Product product = e.AddedItems[0] as Product;
            DisplayProductDetail(product);

        }
        void DisplayProductDetail(Product product)
        {
            if (product == null)
            {
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";
            }
            else
            {
                txtId.Text = product.ProductId + "";
                txtName.Text = product.ProductName;
                txtQuantity.Text = product.UnitsInStock + "";
                txtPrice.Text = product.UnitPrice + "";
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetail(null);
            txtId.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Bước 1: Tìm danh mục mà ta muốn lưu Product
                // Bước 2: Tạo đối tượng Product muốn lưu
                // Bước 3: Gán giá trị cho các thuộc tính của Product và Lưu
                // Bước 4: Thực hiện lưu cập nhật lại giao diện TreeView, ListView

                //-----CHI TIẾT-------
                //Bước 1: Tìm danh mục mà ta muốn lưu Product
                TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node == null)
                {
                    MessageBox.Show(
                        "Bạn cần chọn Danh mục trước",
                        "Lỗi lưu sản phẩm",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                Category category = cate_node.Tag as Category;
                if (category == null)
                {
                    MessageBox.Show(
                        "Bạn cần chọn Danh mục trước",
                        "Lỗi lưu sản phẩm",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;

                }

                //Bước 2: Tạo đối tượng Product muốn lưu
                Product product = new Product();
                //Bước 3: Gán giá trị cho các thuộc tính của Product và Lưu
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.CategoryId = category.CategoryId; //Gán CategoryId cho Product
                context.Products.Add(product);
                context.SaveChanges();
                //Bước 4: Thực hiện lưu cập nhật lại giao diện TreeView, ListView
                //Bước 4.1: Nạp lại TreeView 
                TreeViewItem product_node = new TreeViewItem();
                product_node.Header = product.ProductName;
                product_node.Tag = product;
                cate_node.Items.Add(product_node);
                //Bước 4.2: Nạp lại ListView
                LoadProductsIntoListView(category);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tè le: " + ex.Message,
                "Lỗi",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }

          private void btnUpdate_Click(object sender, RoutedEventArgs e)
          {
            try
            {
                //Bước 1: Tìm danh mục mà ta muốn sửa
                //Bước 2: TIến hành thay đổi giá trị cuộc tính
                //Bước 3: Thực hiện lưu các thay đổi
                //Bước 4: Cập nhật lại giao diện TreeView và ListView
                //-----CHI TIẾT-------
                //Bước 1: Tìm danh mục mà ta muốn sửa
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy sản phẩm để sửa, check lại ID",
                        "Lỗi sửa sản phẩm",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                //Bước 2: TIến hành thay đổi giá trị cuộc tính
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                //Bước 3: Thực hiện lưu các thay đổi
                context.SaveChanges();
                //Bước 4: Cập nhật lại giao diện TreeView và ListView
                //Bước 4.1: Nạp lại các Product Node
                TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node != null)
                {
                    Category category = cate_node.Tag as Category;
                    if (category != null)
                    {
                        //Xóa toàn bộ node CON cũ của cate node:
                        cate_node.Items.Clear();
                        // Nạp lại Product:
                        //lọc sản phẩm theo danh mục:
                        var products = context.Products.
                            Where(x => x.CategoryId == category.CategoryId).
                            ToList();

                        // nạp product vào node danh mục tương ứng:
                        foreach (var product_update in products)
                        {
                            //Tạo node sản phẩm:
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update;
                            cate_node.Items.Add(product_node);
                        }
                        //Bước 4.2: Nạp lại ListView
                        LoadProductsIntoListView(category);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tè le: " + ex.Message,
                "Lỗi",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
            

          }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Bước 1: Tìm sản phẩm để xóa
                //Bước 2: Hỏi xác thực có muốn xóa không
                //Bước 3: Tiến hành xóa nếu đồng ý
                //Bước 4: Cập nhật lại giao diện TreeView và ListView
                //-----CHI TIẾT-------
                //Bước 1: Tìm sản phẩm để xóa
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show(
                        $"Không tìm thấy sản phẩm nào có mã= {id}  để xóa",
                        "Lỗi xóa sản phẩm",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                MessageBoxResult result = MessageBox.Show(
                    $"Thím có chắc muốn xóa sản phẩm [{product.ProductName}] này không ?",
                    "Xác nhận xóa",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                //Bươc 3: Tiến hành xóa nếu đồng ý
                context.Products.Remove(product);
                context.SaveChanges();
                //Bước 4: Cập nhật lại giao diện TreeView và ListView
                //Nạp lại TreeView
                TreeViewItem cate_node = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node != null)
                {
                    Category category = cate_node.Tag as Category;
                    if (category != null)
                    {
                        //Xóa toàn bộ node CON cũ của cate node:
                        cate_node.Items.Clear();
                        // Nạp lại Product:
                        //lọc sản phẩm theo danh mục:
                        var products = context.Products.
                            Where(x => x.CategoryId == category.CategoryId).
                            ToList();

                        // nạp product vào node danh mục tương ứng:
                        foreach (var product_update in products)
                        {
                            //Tạo node sản phẩm:
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_update.ProductName;
                            product_node.Tag = product_update;
                            cate_node.Items.Add(product_node);
                        }
                        //Bước 4.2: Nạp lại ListView
                        LoadProductsIntoListView(category);
                        //xóa chi tiết:
                        DisplayProductDetail(null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tè le: " + ex.Message,
                "Lỗi",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }

            
        }


    }

}
        

