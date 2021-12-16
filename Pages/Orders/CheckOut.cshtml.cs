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
    public class CheckOutModel : PageModel
    {
        private JsonFileOrderService repository;
        private BasketService cart;

        [BindProperty]
        public new User User { get; set; }
        public Order Order { get; set; }

        public CheckOutModel(JsonFileOrderService repo, BasketService cartService)
        {
            repository = repo;
            cart = cartService;
        }
        public void OnGet()
        {
            //User u = User;
        }

        int i = 0;
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Order order = new Order();
            order.OrderID = i++;
            order.User = User;
            order.Item = cart.GetOrderedItems();
            order.DateTime = DateTime.Now;
            repository.AddOrder(order);
            return RedirectToPage("Order", User);
        }
    }
}
