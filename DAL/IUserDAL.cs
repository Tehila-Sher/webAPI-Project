using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDAL
    {
        public List<User> getAllUsers();
        public User getUserById(int id);
        public User getUserByName(string name);
        public void addUser(User newUser);
        public void removeUser(int id);
        public void updateUser(User updatedUser);
    }
}
