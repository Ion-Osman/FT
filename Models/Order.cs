using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeTorvet.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public User User { get; set; }
        public Dictionary<int, Clothing> Item { get; set; }
        public DateTime DateTime { get; set; }
    }
}
