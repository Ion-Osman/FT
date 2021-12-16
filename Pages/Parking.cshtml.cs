using FiskeTorvet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeTorvet.Pages
{
    public class ParkingModel : PageModel
    {
        int Park;
        
  
        private readonly ILogger<IndexModel> _logger;
        public JsonFileParkingService _ParkingService;

        public ParkingModel(ILogger<IndexModel> logger, JsonFileParkingService ParkingService)
        {
            _logger = logger;
            _ParkingService = ParkingService;
           
        }

        public void OnGet()
        {
            
            Park = _ParkingService.GetParkingNumber().Number;
            
        }

        public int parkingNumber
        {
            
            get { 
               
                return Park     ; 
            }
        }
    }
}
