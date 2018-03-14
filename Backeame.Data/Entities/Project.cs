using Backeame.Data.Helper;
using Backeame.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Data.Entities
{
    public class Project : BaseEntity
    {        
        public Project()
        {
            this.Categories = new List<Category>();
            this.Rewards = new List<Reward>();
        }
        public string Title { get; set; }
        public string Entrepreneur { get; set; }
        public string BriefDesc { get; set; }
        public string Location { get; set; }
        public int PercentageFunded { get; set; }
        public string AmountPledged { get; set; }
        public string UrlComponent { get; set; }
        public int DaysToGo { get; set; }
       
        public List<Category> Categories { get; set; }

        public List<Reward> Rewards { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        [Column("Type")]
        public string Persistance_Type { get; set; }

        [NotMapped]
        public ProjectType Type
        {
            get { return (ProjectType)Enum.Parse(typeof(ProjectType), this.Persistance_Type); }
            set { this.Persistance_Type = value.ToString(); }
        }



    }
}
