using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> dsDuLieu = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnThem_Click(object sender,
            RoutedEventArgs e)
        {
            // x là giá trị muốn đưa vào cuối danh sách
            int x = int.Parse(txtGiaTri.Text);
            // Thêm x vào danh sách:
            dsDuLieu.Add(x);
            HienThiDanhDanh();
            txtGiaTri.Text = "";

        }

        //Hàm hiển thị danh sách lên giao diện
        void HienThiDanhDanh()
        {
            lstDuLieu.Items.Clear();
            for (int i =0; i < dsDuLieu.Count; i++)
            {
                int x = dsDuLieu[i];
                lstDuLieu.Items.Add(x);
            }    
        }
         
        private void BtnChen_Click(object sender,
            RoutedEventArgs e)
        {
            // x là giá trị muốn chèn vào danh sách
            int x = int.Parse(txtGiaTriChen.Text);
            // i là vị trí muốn chèn x vào
            int vt = int.Parse(txtViTriChen.Text);
            // Chèn x vào vị trí i trong danh sách:
            dsDuLieu.Insert(vt, x);
            HienThiDanhDanh();
            txtGiaTriChen.Text = "";
            txtViTriChen.Text = "";
        }

        private void BtnSapXepTang_Click(object sender, RoutedEventArgs e)
        {
            // Sắp xếp danh sách theo thứ tự tăng dần
            dsDuLieu.Sort();
            //HIỂN THỊ DANH SÁCH
            HienThiDanhDanh();
        }
        private void BtnSapXepGiam_Click(object sender, RoutedEventArgs e)
        {
            // Sắp xếp danh sách theo thứ tự giảm dần
            dsDuLieu.Sort();
            // Đảo ngược thứ tự của danh sách
            dsDuLieu.Reverse();
            //HIỂN THỊ DANH SÁCH
            HienThiDanhDanh();
        }

        private void BtnXoa1PhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn phần tử mới xóa được", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }
            // xóa phần tử tại vị trí đang chọn:
            dsDuLieu.RemoveAt(lstDuLieu.SelectedIndex);
            HienThiDanhDanh();
        }

        private void BtnXoaNhieuPhanTu_Click(object sender,
            RoutedEventArgs e)
        {
            if(lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn phần tử mới xóa được", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }
            //vòng lặp lấy các phần tử được chọn trên giao diện
            while(lstDuLieu.SelectedItems.Count > 0)
            {
                //lấy phần tử đầu tiên ra
                int data = (int)lstDuLieu.SelectedItems[0];
                //xóa phần tử khỏi danh sách
                dsDuLieu.Remove(data);
                // xóa dữ liệu khỏi giao diện
                lstDuLieu.Items.Remove(data);
            }
        }

        private void BtnXoaToanBoPhanTu_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Clear();// xóa toàn bộ dữ liệu
            HienThiDanhDanh();
        }
    }
}