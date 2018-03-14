using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Magic.DTOs
{
    public class ProjectShallowDTO
    {
        public string id { get; set; }
        public string title { get; set; }
        public string entrepreneur { get; set; }
        public string briefDesc { get; set; }
        public string location { get; set; }
        public int percentageFunded { get; set; }
        public string amountPledged { get; set; }
        public int daysToGo { get; set; }
        public string urlComponent { get; set; }
    }
}
