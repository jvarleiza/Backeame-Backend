using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Data.Entities
{
    public class Reward : BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public string BackerAmount { get; set; }
        public string ShipsTo { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
