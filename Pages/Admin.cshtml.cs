using FiskeTorvet.Models;
using FiskeTorvet.Services;
using FiskeTorvet.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FiskeTorvet.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public JsonFileParkingService _ParkingService;
        public JsonFileProductService _ProductService;
        public IUserService _UserService;

        public AdminModel(ILogger<IndexModel> logger, JsonFileParkingService ParkingService, JsonFileProductService ProductService, IUserService userService)
        {
            _logger = logger;
            _ParkingService = ParkingService;
            _ProductService = ProductService;
            _UserService = userService;
        }

        public void OnGet()
        {

        }
        public void OnPostParkingIncrease()
        {
            _ParkingService.Increase();
        }
        public void OnPostParkingDecrease()
        {
            _ParkingService.Decrease();
        }
        public void OnPostParkingSet(int value)
        {
            _ParkingService.Set(value);
        }
        public void OnPostReset()
        {
            _ProductService.Reset();
            _ParkingService.Set(500);
           
            _ProductService.AddItemElectro(1, "Smart Watch", ", sleep monitoring, watertight value 50 m and storage of 32GB.", 1999, "smartwatch.png" );
            _ProductService.AddItemElectro(2, "Smartphone", "4.7 inches IPS 1334 × 750, Phone A13 Bionic 6 - core processor, 3 GB RAM, 128 GB internal memory, 12 Mpx rear camera(f / 1.8), 7 Mpx front camera, optical stabilization, GPS etc.", 4999, "smartphone.png" );
            _ProductService.AddItemElectro(6, "Fridge", "Fridge with freezer at the bottom, energy class D, climate class SN, N, ST and T, refrigerator volume 276l, freezer volume 114l, hinges on the right, number of refrigerator shelves 4, number of freezer compartments 3, number of cooling circuits 1, stainless steel, functions: total No Frost, zero zone, Multi-AirFlow, electronic temperature control, holiday mode, antibacterial seal, 203 × 59.5 × 65.8 cm (H × W × D).", 8999, "fridge.jpg" );
            _ProductService.AddItemElectro(3, "Laptop", "Laptop M1, 13.3 inches IPS glossy 2560 × 1600, RAM 8GB, Apple M1 8 - core GPU, SSD 256GB, backlit keyboard, webcam, USB-C, fingerprint reader, WiFi 6 and Weight 1.37 kg.", 6999, "laptop.png" );
            _ProductService.AddItemElectro(4, "PC", "Gaming PC Intel Core i5 10400F Comet Lake 4.3 GHz, NVIDIA GeForce RTX 3060 12GB, RAM 16GB DDR4, SSD 1000 GB, Without drive, Wi-Fi, HDMI and DisplayPort, 4 × USB 3.2, 2 × USB 2.0, case type: Midi Tower, Windows 10 Home.", 9999, "pc.png" );
            _ProductService.AddItemElectro(7, "Microwave", "Built-in microwave oven, power consumption 1270 W, volume 20 l, number of power levels 5, microwave heating power 800 W, plate size 25 cm, defrost, timer, automatic programs and without grill, turntable, color black.", 3999, "microwave.png" );
            _ProductService.AddItemElectro(5, "TV", "SMART ANDROID LED TV, 125cm, 4K Ultra HD, RMR 1000 (50Hz), HDR10, HLG, Dolby Vision, DVB-T2 / S2 / C, H.265 / HEVC, 4 × HDMI, 2 × USB, WiFi, Bluetooth, HbbTV 2.0, game mode, voice control, Apple TV, Netflix, Google Assistant, VESA 200 × 200, repro 20W, en. class G.", 5999, "tv.png" );

            _ProductService.AddItemClothing(102, "Jacket",   "Water-repellent cotton jacket is an autumn must.",   599,   "jacket.png" );
            _ProductService.AddItemClothing(106, "Pants",   "Chinos in cotton twill with extra stretch.",   299,   "pants.png" );
            _ProductService.AddItemClothing(103, "Hoodie",   "This cotton hoodie will make you look slim.",   399,   "hoddie.png" );
            _ProductService.AddItemClothing(108, "Socks",   "3-pairs of warm socks is winter must!",   99,   "socks.png" );
            _ProductService.AddItemClothing(104, "T-Shirt",   "Cotton Unisex Functional T-Shirt!",   199,   "t-shirt.png" );
            _ProductService.AddItemClothing(105, "Shirt",   "Best selling shirt on market! 100% cotton.",   249,   "shirt.png" );
            _ProductService.AddItemClothing(107, "Shorts",   "Wool comfy shorts for our ladies.",   199,   "shorts.png" );
            _ProductService.AddItemClothing(101, "Hat",   "Big hat for a big man!",   59,   "hat.png" );

            _ProductService.AddItemJewelry(201,"Ring",   "White gold ring with a small jewel.",   1499,   "ring.png" );
            _ProductService.AddItemJewelry(202,"Necklace",   "9ct Yellow Gold T-Bar Belcher Chain Necklace.",   999,   "Necklace.png" );
            _ProductService.AddItemJewelry(204,"Earrings",   "Surgical steel earrings with a beautiful jewels.",   999,   "earrings.png" );
            _ProductService.AddItemJewelry(203,"Bracelet",   "Bracelet made of real sea pearls.",   899,   "bracelet.png" );

        }

        public void OnPostRemoveItem(string storeName, int id)
        {
            if(storeName == "Electronics")
            {
                _ProductService.RemoveItemElectro(id);
            }
            else if(storeName == "Clothing")
            {
                _ProductService.RemoveItemClothing(id);
            }
            else if(storeName == "Jewelry")
            {
                _ProductService.RemoveItemJewelry(id);

            }
            else
            {

            }
        }
       
        public void OnPostAddItem(string storeName, int id, string name, string description, int price, string imageName)
        {
            if (storeName == "Electronics")
            {
                _ProductService.AddItemElectro(id, name, description, price, imageName);
            }else if(storeName == "Clothing")
            {
                _ProductService.AddItemClothing(id, name, description, price, imageName);
            }else if (storeName == "Jewelry")
            {
                _ProductService.AddItemJewelry(id, name, description, price, imageName);
            }
            else
            {

            }
        }

        public void OnPostCreateUser(string name, string userName, string password, bool isAdmin, int id)
        {
            User newUser = new User();
            newUser.Name = name;
            newUser.Username = userName;
            newUser.Password = password;
            newUser.ConfirmPassword = password;
            newUser.IsAdmin = isAdmin;
            newUser.Id = id;
            _UserService.AddUser(newUser);
        }
        public void OnPostRemoveUser(int id)
        {
            _UserService.RemoveUser(id);
        }
        

    }
}
