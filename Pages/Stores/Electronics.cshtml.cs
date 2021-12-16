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

namespace FiskeTorvet.Pages.Stores
{
    public class ElectronicsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        JsonFileProductService _productService;
        private Shop catalog;
        public ElectronicsModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            catalog = new Shop();
            _productService = productService;

        }
        public Dictionary<int, Electro> Electronics { get; private set; }
        
        public IActionResult OnGet()
        {
            Electronics = _productService.GetElectro();
            return Page();
        }
    }
}
