using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FiskeTorvet.Models;
using Newtonsoft.Json;

namespace FiskeTorvet.Services
{
   
        public class JsonFileParkingService
        {
            public JsonFileParkingService(IWebHostEnvironment webHostEnvironment)
            {
                WebHostEnvironment = webHostEnvironment;
            }

            public IWebHostEnvironment WebHostEnvironment { get; }

            private string JsonFileName
            {

               get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Parking.json"); }
            }

            public ParkingNumber GetParkingNumber()
            {
                string json = File.ReadAllText(JsonFileName); 
                return JsonConvert.DeserializeObject<ParkingNumber>(json);                 
            }

            public void Increase()
            {
                
                ParkingNumber data = GetParkingNumber();
                data.Number = data.Number + 1;
                string Json = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFileName, Json);
            }
            public void Decrease()
            {

                ParkingNumber data = GetParkingNumber();
                data.Number = data.Number - 1;
                string Json = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFileName, Json);
            }
            public void Set(int value)
            {
                ParkingNumber data = new ParkingNumber();
                data.Number = value;
                string Json = JsonConvert.SerializeObject(data);
                File.WriteAllText(JsonFileName, Json);
            }
    }
}

