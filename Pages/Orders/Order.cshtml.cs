using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiskeTorvet.Models;
using FiskeTorvet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiskeTorvet.Pages.Orders
{
    public class OrderModel : PageModel
    {
        private JsonFileOrderService repository;

        private BasketService cart;

        public User User { get; set; }
        public Order Order { get; set; }
        public Dictionary<int, Clothing> cartItems { get; set; }

        public OrderModel(JsonFileOrderService repoService, BasketService cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        public IActionResult OnGet(User st)
        {
            User = st;
            cartItems = cart.GetOrderedItems();
            if (cartItems?.Count() <= 0)
            {
                return Redirect("Basket");
            }
            return Page();
        }
    }
}
