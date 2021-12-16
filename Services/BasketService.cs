using FiskeTorvet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeTorvet.Services
{
    public class BasketService
    {
        Dictionary<int, Clothing> _cartItems;
        public BasketService()
        {
            _cartItems = new Dictionary<int, Clothing>();
        }

        public void Add(Clothing coat)
        {
            _cartItems.Add(coat.Id, coat);
        }

        public Dictionary<int, Clothing> GetOrderedItems()
        {
            return _cartItems;
        }

        public void RemoveItem(int id)
        {
            foreach (var coat in _cartItems)
            {
                if (coat.Value.Id == id)
                {
                    _cartItems.Remove(coat.Key);
                    break;
                }
            }
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0.00M;

            foreach (var v in _cartItems)
            {
                totalPrice = totalPrice + (decimal)v.Value.Price;
            }
            return totalPrice;
        }

    }
}
