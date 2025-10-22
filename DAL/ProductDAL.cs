using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL : IProductDAL
    {
        ShopContext shopContext;

        public ProductDAL(ShopContext _shopContext)
        {
            shopContext = _shopContext;
        }
        public List<Product> getAllProducts()
        {
            return shopContext.Products.ToList();
        }

        public Product getProductById(int id)
        {
            Product p = shopContext.Products.FirstOrDefault(x=>x.ProductId == id);
            if (p == null)
                return null;
            return p;
        }

        public Product getProductByName(string name)
        {
            Product p = shopContext.Products.FirstOrDefault(x => x.ProductName == name);
            if (p == null)
                return null;
            return p;
        }
        public List<Product> getAllProductsByCategory(int categoryId)
        {
            Category c = shopContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (c == null)
                return null;
            return shopContext.Products.Where(x => x.CategoryId==categoryId).ToList();
        }
        public void addProduct(Product newProduct)
        {
           shopContext.Products.Add(newProduct);
            shopContext.SaveChanges();
        }

        public void removeProduct(int id)
        {
            Product p = shopContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (p != null)
            {
                shopContext.Products.Remove(p);
                shopContext.SaveChanges();
            }
                
        }

        public void updateProduct(Product updatedProduct)
        {
            Product p = shopContext.Products.FirstOrDefault(x => x.ProductId == updatedProduct.ProductId);
            if (p != null)
            {
                p.ProductName = updatedProduct.ProductName;
                p.ImageSrc = updatedProduct.ImageSrc;
                p.Price = updatedProduct.Price;
                p.Description = updatedProduct.Description;
                p.CategoryId = updatedProduct.CategoryId;
                shopContext.SaveChanges();
            }
        }
    }
}
