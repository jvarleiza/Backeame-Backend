using Backeame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Magic.DTOs
{
    public class ProjectDTO
    {        
        public string id { get; set; }
        public string title { get; set; }
        public string entrepreneur { get; set; }
        public string briefDesc { get; set; }
        public string location { get; set; }
        public int percentageFunded { get; set; }
        public string amountPledged { get; set; }
        public int daysToGo { get; set; }

        public List<CategoryDTO> categories { get; set; }

        public List<RewardDTO> rewards { get; set; }

        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public string persistance_Type { get; set; }
                
    }
}
