using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderBLL : IOrderBLL
    {
        IOrderDAL orderDAL;

        public OrderBLL(IOrderDAL _orderDAL)
        {
            orderDAL = _orderDAL;
        }
        public void addOrder(Order newOrder)
        {
             orderDAL.addOrder(newOrder);
        }

        public List<Order> getAllOrders()
        {
           return orderDAL.getAllOrders();
        }

        public List<Order> getAllUserOrders(int userId)
        {
            return orderDAL.getAllUserOrders(userId);
        }

        public Order getOrderById(int id)
        {
            return orderDAL.getOrderById(id);
        }

        public void removeOrder(int id)
        {
            orderDAL.removeOrder(id);
        }

        public void updateOrder(Order updatedOrder)
        {
            orderDAL.updateOrder(updatedOrder);
        }
    }
}
