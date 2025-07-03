using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public void GenerateSampleDataset();

        public bool SaveProduct(Product product);
        public bool UpdateProduct(Product product);
        public Product GetProduct(int id);
        public bool DeleteProduct(int id);
        public bool DeleteProduct(Product product);
    }
}
