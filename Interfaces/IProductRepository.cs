using FiskeTorvet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeTorvet.Interfaces
{
   public interface IProductRepository
    {
        Dictionary<int, Clothing> GetClothing();
        Clothing GetCoat(string n);
        Dictionary<int, Electro> GetElectro();
        Dictionary<int, Jewelry> GetJewelry();
        void RemoveItemClothing(int id);
        void AddItemClothing(int id, string name, string description, int price, string imageName);
        void AddItem(Clothing Item);
        void RemoveItemElectro(int id);
        void AddItemElectro(int id, string name, string description, int price, string imageName);
        void RemoveItemJewelry(int id);
        void AddItemJewelry(int id, string name, string description, int price, string imageName);
        void Reset();
    }
}
