using FiskeTorvet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeTorvet.Interfaces
{
   public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        void AddOrder(Order order);
    }
}
