using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiskeTorvet.Models;

namespace FiskeTorvet.Shops
{
    public class Shop
    {
        //Electro SmartWatch, SmartPhone, Laptop, PC, TV, Fridge, Microwave

        //Clothing Hat, Jacket, Hoddie, T-Shiŕt, Shirt, Pants, Shorts, Socks

        //Jewelry Ring, Necklace, Bracelet, Earring

        //Table Picture, ID, Name, Price, Description, Stock amount == one box eaach
        private List<Electro> electronics { get; }

        private List<Clothing> clothes { get; }

        private List<Jewelry> jewelry { get; }
        public Shop()
        {
        }

        public List<Electro> AllElectronics()
        {
            return electronics;
        }

        public List<Clothing> AllClothes()
        {
            return clothes;
        }

        public List<Jewelry> AllJewelry()
        {
            return jewelry;
        }
    }
}
