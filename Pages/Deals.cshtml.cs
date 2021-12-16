using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiskeTorvet.Shops;
using FiskeTorvet.Models;
using FiskeTorvet.Services;

namespace FiskeTorvet.Pages
{
    public class DealsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private Shop catalog;

        public Dictionary<int, Electro> Electronics { get;  set; }
        public Dictionary<int, Clothing> Clothes { get;  set; }
        public Dictionary<int, Jewelry> Jewelry { get;  set; }

        public DealsModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            Clothes = productService.GetClothing();
            Electronics = productService.GetElectro();
            Jewelry = productService.GetJewelry();
            catalog = new Shop();
        }
         

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
