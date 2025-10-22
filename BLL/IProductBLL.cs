using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal interface IProductBLL
    {
        public List<Product> getAllProducts();
        public Product getProductById(int id);
        public Product getProductByName(string name);
        public List<Product> getAllProductsByCategory(int categoryId);
        public void addProduct(Product newProduct);
        public void removeProduct(int id);
        public void updateProduct(Product updatedProduct);
    }
}
