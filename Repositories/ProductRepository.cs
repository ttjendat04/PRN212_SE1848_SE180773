using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObjects;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();

        public void GenerateSampleDataset()
        {
            productDAO.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return productDAO.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return productDAO.SaveProduct(product);
           
        }
        public Product GetProduct(int id)
        {
            return productDAO.GetProduct(id);
        }

        public bool UpdateProduct(Product product)
        {
            return productDAO.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return productDAO.DeleteProduct(id);
        }

        public bool DeleteProduct(Product product)
        {
            return productDAO.DeleteProduct(product.Id);
        }
    }
}
