using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class ProductBLL : IProductBLL
    {
        IProductDAL productDAL;

        public ProductBLL(IProductDAL _productDAL)
        {
            productDAL = _productDAL;
        }
        public void addProduct(Product newProduct)
        {
            productDAL.addProduct(newProduct);
        }

        public List<Product> getAllProducts()
        {
            return productDAL.getAllProducts();
        }

        public List<Product> getAllProductsByCategory(int categoryId)
        {
           return productDAL.getAllProductsByCategory(categoryId);
        }

        public Product getProductById(int id)
        {
            return productDAL.getProductById(id);
        }

        public Product getProductByName(string name)
        {
            return productDAL.getProductByName(name);
        }

        public void removeProduct(int id)
        {
           productDAL.removeProduct(id);
        }

        public void updateProduct(Product updatedProduct)
        {
            productDAL.updateProduct(updatedProduct);
        }
    }
}
