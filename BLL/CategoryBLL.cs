using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        ICategoryDAL categoryDAL;

        public CategoryBLL(ICategoryDAL _categoryDAL)
        {
            categoryDAL = _categoryDAL;
        }
        public void addCategory(Category newCategory)
        {
            categoryDAL.addCategory(newCategory);
        }

        public List<Category> getAllCategories()
        {
           return categoryDAL.getAllCategories();
        }

        public Category getCategoryById(int id)
        {
            return categoryDAL.getCategoryById(id);
        }

        public Category getCategoryByName(string name)
        {
            return categoryDAL.getCategoryByName(name);
        }

        public void removeCategory(int id)
        {
            categoryDAL.removeCategory(id);
        }

        public void updateCategory(Category updatedCategory)
        {
            categoryDAL.updateCategory(updatedCategory);
        }
    }
}
