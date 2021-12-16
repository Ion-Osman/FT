using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FiskeTorvet.Models;
using FiskeTorvet.Interfaces;

namespace FiskeTorvet.Services
{
   
        public class JsonFileProductService:IProductRepository
    {
            public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
            {
                WebHostEnvironment = webHostEnvironment;
            }

            public IWebHostEnvironment WebHostEnvironment { get; }

            private string JsonFileNameClothes
            {
                get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Clothes.json"); }
            }
            private string JsonFileNameJewelry
        {
                get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Jewelry.json"); }
            }
            private string JsonFileNameElectronics
            {
                get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Electronics.json"); }
            }
        
        public Dictionary<int, Clothing> GetClothing()
            {
                    string json = File.ReadAllText(JsonFileNameClothes);
                    return JsonConvert.DeserializeObject<Dictionary<int, Clothing>>(json);
                
            }
            public Dictionary<int, Electro> GetElectro()
            {
                    
                    string json = File.ReadAllText(JsonFileNameElectronics);
                    Dictionary<int, Electro> output = JsonConvert.DeserializeObject<Dictionary<int, Electro>>(json);
                    //if(output != null)
                    //{
                    //    return output;
                    //}
                    //else
                    //{
                        //Dictionary<int, Electro> noData = new Dictionary<int, Electro>();
                        //Electro noDataObj = new Electro();
                        //noDataObj.Name = "NO DATA HERE";
                        //noData.Add(1, noDataObj);
                    return output;
                    //}
                        
                }
            public Dictionary<int, Jewelry> GetJewelry()
            {
                    string json = File.ReadAllText(JsonFileNameJewelry);
                    return JsonConvert.DeserializeObject<Dictionary<int, Jewelry>>(json);
                
            }
            public void RemoveItemClothing(int id)
            {

                Dictionary<int, Clothing> data = GetClothing();
                data.Remove(id);
                string Json = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFileNameClothes, Json);
            }

            public void AddItemClothing(int id, string name, string description, int price, string imageName)
            {    
                    Clothing newItem = new Clothing();
                    newItem.Id = id;
                    newItem.Name = name;
                    newItem.Description = description;
                    newItem.Price = price;
                    newItem.ImageName = imageName;
                    Dictionary<int, Clothing> data = GetClothing();
                    data.Add(newItem.Id, newItem);
                    string Json = JsonConvert.SerializeObject(data);
                    File.WriteAllText(JsonFileNameClothes, Json);
            }

        public void AddItem(Clothing Item)
        {
            Clothing newItem = new Clothing();
            Dictionary<int, Clothing> data = GetClothing();
            data.Add(newItem.Id, newItem);
            string Json = JsonConvert.SerializeObject(data);
            File.WriteAllText(JsonFileNameClothes, Json);
        }
            public void RemoveItemElectro(int id)
            {
                Dictionary<int, Electro> data = GetElectro();
                data.Remove(id);
                string Json = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFileNameElectronics, Json);
            }

            public void AddItemElectro(int id, string name, string description, int price, string imageName)
            {
                Electro newItem = new Electro();
                newItem.Id = id;
                newItem.Name = name;
                newItem.Description = description;
                newItem.Price = price;
                newItem.ImageName = imageName;
                Dictionary<int, Electro> data = GetElectro();
                data.Add(newItem.Id, newItem);
                string Json = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFileNameElectronics, Json);
            }
            public void RemoveItemJewelry(int id)
            {

                Dictionary<int, Jewelry> data = GetJewelry();
                data.Remove(id);
                string Json = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFileNameJewelry, Json);
            }

            public void AddItemJewelry(int id, string name, string description, int price, string imageName)
            {
                Jewelry newItem = new Jewelry();
                newItem.Id = id;
                newItem.Name = name;
                newItem.Description = description;
                newItem.Price = price;
                newItem.ImageName = imageName;
                Dictionary<int, Jewelry> data = GetJewelry();
                data.Add(newItem.Id, newItem);
                string Json = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFileNameJewelry, Json);
            }

        public Clothing GetCoat(string n)
        {
            foreach (var b in GetClothing())
            {
                if (b.Value.Name == n)
                    return b.Value;
            }
            return new Clothing();
        }

        public void Reset()
            {
                
                Dictionary<int, Jewelry> emptyJewelry = new Dictionary<int, Jewelry>();
                Dictionary<int, Electro> emptyElectronics = new Dictionary<int, Electro>();
                Dictionary<int, Clothing> emptyClothing = new Dictionary<int, Clothing>();

                string JsonJewelry = JsonConvert.SerializeObject(emptyJewelry);
                string JsonElectronics = JsonConvert.SerializeObject(emptyElectronics);
                string JsonClothing = JsonConvert.SerializeObject(emptyClothing);

                File.WriteAllText(JsonFileNameJewelry, JsonJewelry);
                File.WriteAllText(JsonFileNameElectronics, JsonElectronics);
                File.WriteAllText(JsonFileNameClothes, JsonClothing);
        }



    }
    }

