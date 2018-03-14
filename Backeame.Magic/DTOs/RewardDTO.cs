using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Magic.DTOs
{
    public class RewardDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public int stock { get; set; }
        public decimal price { get; set; }
        public DateTime estimatedDelivery { get; set; }
        public string backerAmount { get; set; }
        public string shipsTo { get; set; }
    }
}
