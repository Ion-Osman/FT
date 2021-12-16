using FiskeTorvet.Interfaces;
using FiskeTorvet.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeTorvet.Services
{
    public class JsonFileOrderService:IOrderRepository
    {
        public JsonFileOrderService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileNameOrder
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Orders.json"); }
        }

        public List<Order> GetAllOrders()
        {
            string json = File.ReadAllText(JsonFileNameOrder);
            return JsonConvert.DeserializeObject<List<Order>>(json);
        }
        public void AddOrder(Order order)
        {
            List<Order> orders = GetAllOrders().ToList();
            order.OrderID = GetOrderNumber() + 1;
            orders.Add(order);
          //  JsonFileWritter.WriteToJsonOrder(orders, filePath);
            string Json = JsonConvert.SerializeObject(orders);
            File.WriteAllText(JsonFileNameOrder, Json);
        }

        private int GetOrderNumber()
        {
            List<int> ids = new List<int>();
            List<Order> orders = GetAllOrders().ToList();
            foreach (var o in orders)
            {
                ids.Add(o.OrderID);
            }
            return ids.Max();
        }
    }
}
