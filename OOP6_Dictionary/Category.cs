using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }

        public Category()
        {
            Products = new Dictionary<int, Product>();
        }

        public override string ToString()
        {
            return $"{Id} \t {Name}";
        }

    /*Khi quan ly moi doi tuong ta deu phai dap ung
     * day du tinh nang CRUD
     */
        public void AddProduct(Product p)
        {
            //Kiem tra neu Id cua Product chua ton tai thi them moi
            if (p == null)
            {
                return; // du lieu dau vao null
            }
            if (Products.ContainsKey(p.Id))
            {
                return; //Id da ton tai thi khong them
            }
            // them moi Prodcut vao Dictionary
            Products.Add(p.Id, p);
        }
        // Xuat toan bo san pham:

        public void PrintAllProducts()
        {
            foreach (KeyValuePair<int, Product> kvp in Products)
            {
                Product p = kvp.Value;
                Console.WriteLine(p);
            }
        }
        //Lọc các sản phẩm từ min tới max
        public Dictionary<int, Product>
            FilterProductByPrice(double min, double max)
        {
            return Products.
                Where(item => item.Value.Price >= min && item.Value.Price <= max)
                .ToDictionary<int, Product>();
        }

        // Sắp xếp sản phầm theo đơn giá tăng dần:

        public Dictionary<int, Product> SortProductByPrice()
        {
            return Products.OrderBy(item => item.Value.Price)
                 .ToDictionary<int, Product>();
        }

        // Hãy sắp xếp theo đơn giá tăng dần, nếu sản phẩm trùng nhau xếp sản phẩm theo số lượng giảm dần
        public Dictionary<int,Product> SortComplex()
        {
            return Products
                .OrderByDescending(item => item.Value.Quantity)
                .OrderBy(item => item.Value.Price)
                .ToDictionary<int, Product>();
        }

        public bool UpdateProduct(Product p)
        {
            if (p == null)
                return false; // nhập null sao mà sửa
            if (Products.ContainsKey(p.Id)==false)
            {
                return false; //Không thấy sao mà sửa
            }

            // cập nhật giá trị tại ô nhớ chứa p.Id
            Products[p.Id] = p;
            return true; // cập nhật thành công
        }

        public bool RemoveProduct(int id)
        {
            if (Products.ContainsKey(id) == false)
                return false; // Không tìm thấy Id để xóa
            Products.Remove(id);
            return true; // Xóa thành công
        }

        // Viết hàm cho xóa các sản phẩm giá từ a đến b
        public int DeleteProductByPrice(double min, double max)
        {
            var keysToRemove = Products
                .Where(item => item.Value.Price >= min && item.Value.Price <= max)
                .Select(item => item.Key)
                .ToList();

                foreach (var key in keysToRemove)
                {
                    Products.Remove(key); // Xóa từng sản phẩm theo key

                }
                return keysToRemove.Count; // Trả về true nếu có sản phẩm bị xóa
        }

        public int DeleteProductByQuantity(int min, int max)
        {
            var keysToRemove = Products
                .Where(item => item.Value.Quantity >= min && item.Value.Quantity <= max)
                .Select(item => item.Key)
                .ToList();
            foreach (var key in keysToRemove)
            {
                Products.Remove(key); // Xóa từng sản phẩm theo key
            }    
            return keysToRemove.Count; // Trả về số lượng sản phẩm bị xóa
        }
        
    }
}
