using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        ShopContext shopContext;

        public UserDAL(ShopContext _shopContext)
        {
            shopContext = _shopContext;
        }

        public List<User> getAllUsers()
        {
            return shopContext.Users.ToList();
        }

        public User getUserById(int id)
        {
            User u = shopContext.Users.FirstOrDefault(x=>x.UserId== id);
            if (u == null)
                return null;
            return u;
        }

        public User getUserByName(string name)
        {
            User u = shopContext.Users.FirstOrDefault(x => x.Username == name);
            if (u == null)
                return null;
            return u;
        }

        public void addUser(User newUser)
        {
            shopContext.Users.Add(newUser);
            shopContext.SaveChanges();
        }

        public void removeUser(int id)
        {
            User u = shopContext.Users.FirstOrDefault(x => x.UserId == id);
            if (u != null)
            {
                shopContext.Users.Remove(u);
                shopContext.SaveChanges();
            }
        }

        public void updateUser(User updatedUser)
        {
            shopContext.Users.Update(updatedUser);
            shopContext.SaveChanges();
        }
    }
}
