using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiskeTorvet.Models
{
    public class Clothing
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Price")]
        public decimal Price { get; set; }

        [JsonPropertyName("ImageName")]
        public string ImageName { get; set; }
    }
}
