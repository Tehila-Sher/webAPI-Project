using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL : IUserBLL
    {
        IUserDAL userDAL;

        public UserBLL(IUserDAL _userDAL)
        {
            userDAL = _userDAL;
        }
        public void addUser(User newUser)
        {
           userDAL.addUser(newUser);
        }

        public List<User> getAllUsers()
        {
           return userDAL.getAllUsers();
        }

        public User getUserById(int id)
        {
           return userDAL.getUserById(id);
        }

        public User getUserByName(string name)
        {
            return userDAL.getUserByName(name);
        }

        public void removeUser(int id)
        {
            userDAL.removeUser(id);
        }

        public void updateUser(User updatedUser)
        {
            userDAL.updateUser(updatedUser);
        }
    }
}
