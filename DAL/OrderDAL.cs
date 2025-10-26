using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDAL : IOrderDAL
    {
        ShopContext shopContext;

        public OrderDAL(ShopContext _shopContext)
        {
            shopContext = _shopContext;
        }
        public List<Order> getAllOrders()
        {
           return shopContext.Orders.ToList();
        }

        public Order getOrderById(int id)
        {
            Order  o= shopContext.Orders.FirstOrDefault(x => x.OrderID == id);
            if (o == null)
                return null;
            return o;
        }

        public List<Order> getAllUserOrders(int userId)
        {
            User u = shopContext.Users.FirstOrDefault(x => x.UserId == userId);
            if (u == null)
                return null;
            return shopContext.Orders
        .Where(o => o.UserId == userId)
        .ToList();
        }

        public void addOrder(Order newOrder)
        {
           shopContext.Orders.Add(newOrder);
            shopContext.SaveChanges();
        }
    
        public void removeOrder(int id)
        {
            Order o = shopContext.Orders.FirstOrDefault(x => x.OrderID == id);
            if (o != null)
            {
                shopContext.Orders.Remove(o);
                shopContext.SaveChanges();
            }
        }

        public void updateOrder(Order updatedOrder)
        {
            Order o = shopContext.Orders.FirstOrDefault(x => x.OrderID == updatedOrder.OrderID);
            if (o != null)
            {
                o.OrderDate = updatedOrder.OrderDate;
                o.User = updatedOrder.User;
                o.UserId = updatedOrder.UserId;
                o.User = updatedOrder.User;
                shopContext.SaveChanges();
            }
        }
    }
}
