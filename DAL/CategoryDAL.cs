using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        ShopContext shopContext;

        public CategoryDAL(ShopContext _shopContext)
        {
            shopContext = _shopContext;
        }
        public List<Category> getAllCategories()
        {
            return shopContext.Categories.ToList();
        }
        public Category getCategoryById(int id)
        {
            Category c = shopContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (c == null)
                return null;
            return c;
        }

        public Category getCategoryByName(string name)
        {
            Category c = shopContext.Categories.FirstOrDefault(x => x.CategoryName == name);
            if (c == null)
                return null;
            return c;
        }

        public void addCategory(Category newCategory)
        {
            shopContext.Categories.Add(newCategory);
            shopContext.SaveChanges();
        }

        public void removeCategory(int id )
        {
            Category c = shopContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (c != null)      
            shopContext.Categories.Remove(c);
            shopContext.SaveChanges();
        }

        public void updateCategory(Category updatedCategory)
        {
            Category c = shopContext.Categories.FirstOrDefault(x => x.CategoryId == updatedCategory.CategoryId);
            if (c != null) { 
            c.CategoryName = updatedCategory.CategoryName;
            shopContext.SaveChanges();
             }
        }
    }
}
