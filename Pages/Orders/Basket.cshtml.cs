using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiskeTorvet.Interfaces;
using FiskeTorvet.Models;
using FiskeTorvet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiskeTorvet.Pages.Orders
{
    public class BasketModel : PageModel
    {
        public BasketService ChartService { get; }
        public Dictionary<int, Clothing> OrderedItems { get; set; }
        private IProductRepository repo;

        public Clothing Item { get; set; }



        public BasketModel(IProductRepository repository, BasketService chart)
        {
            repo = repository;
            ChartService = chart;
            OrderedItems = new Dictionary<int, Clothing>();
        }
        public IActionResult OnGet(string i)
        {
            Clothing coat = repo.GetCoat(i);
            ChartService.Add(coat);
            OrderedItems = ChartService.GetOrderedItems();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            ChartService.RemoveItem(id);
            OrderedItems = ChartService.GetOrderedItems();
            return Page();
        }
    }
}
