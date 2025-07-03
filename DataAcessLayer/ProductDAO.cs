using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();

        public void GenerateSampleDataset()
        {
            products.Add(new Product() { Id = 1, Name = "Coca", Quantity = 100, Price = 10 });
            products.Add(new Product() { Id = 2, Name = "Pepsi", Quantity = 120, Price = 15 });
            products.Add(new Product() { Id = 3, Name = "Mirinda", Quantity = 70, Price = 9 });
            products.Add(new Product() { Id = 4, Name = "Sting", Quantity = 90, Price = 12 });
            products.Add(new Product() { Id = 5, Name = "RedBull", Quantity = 200, Price = 17 });

        }

        public List<Product> GetProducts()
        {
            return products;
        }


        public bool SaveProduct(Product product)
        {
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null)
                return false; // sản phẩm đã tồn tại, không thêm mới được
            products.Add(product);
            return true; // thêm mới thành cppng
        }

        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProduct(Product product)
        {
            // Buoc 1: tim xem product muon sua co ton tai khong
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old == null) // khong tim thay
                return false; // khong sua duoc, vi khong ton tai
            old.Name = product.Name;
            old.Quantity = product.Quantity;
            old.Price = product.Price;
            return true; // sua thanh cong
        }
        public bool DeleteProduct(int id)
        {
            Product p = GetProduct(id);
            if (p != null)
            {
                products.Remove(p); // xoa san pham
                return true;
            }

            return false; // khong xoa duoc, vi khong ton tai
        }

        public bool DeleteProduct(Product product)
        {
            if (product == null)
                return false; // khong xoa duoc, vi product null
            return DeleteProduct(product.Id);

        }
    }
}
