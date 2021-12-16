using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FiskeTorvet.Shops;
using FiskeTorvet.Models;
using Microsoft.Extensions.Logging;
using FiskeTorvet.Services;
using FiskeTorvet.Interfaces;

namespace FiskeTorvet.Pages.Stores
{
    public class XXLClothingModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        JsonFileProductService _productService;
        private IProductRepository bla;
        [BindProperty]
        public Clothing Item { get; set; }
        private Shop catalog;
        public XXLClothingModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            catalog = new Shop();
            _productService = productService;
        }
        public Dictionary<int, Clothing> Clothes { get; private set; }
        
        public IActionResult OnGet()
        {
            Clothes = _productService.GetClothing();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                bla.AddItem(Item);
                Clothes = bla.GetClothing();
            }
            return Page();
        }
    }
}
