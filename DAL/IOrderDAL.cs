using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderDAL
    {
        public List<Order> getAllOrders();
        public Order getOrderById(int id);
        public List<Order> getAllUserOrders(int userId);
        public void addOrder(Order newOrder);
        public void removeOrder(int id);
        public void updateOrder(Order updatedOrder);
    }
}
