using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICategoryBLL
    {
        public List<Category> getAllCategories();
        public Category getCategoryById(int id);
        public Category getCategoryByName(string name);
        public void addCategory(Category newCategory);
        public void removeCategory(int id);
        public void updateCategory(Category updatedCategory);
      //  void addCategory(global::DTO.CategoryDTO category);
    }
}
