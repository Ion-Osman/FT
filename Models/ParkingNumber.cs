using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiskeTorvet.Models
{
    public class ParkingNumber
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }
    }
}
