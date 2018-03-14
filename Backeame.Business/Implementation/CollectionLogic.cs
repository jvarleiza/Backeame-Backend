using Backeame.Data.Entities;
using Backeame.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Business.Implementation
{
    public class CollectionLogic : ICollectionLogic
    {
        private readonly IUnitOfWork UnitOfWork;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="uof">Inject unit of work</param>
        public CollectionLogic(IUnitOfWork uof)           
        {
            this.UnitOfWork = uof;
        }

        public Collection JustLaunched()
        {
            Collection justLaunched = new Collection();

            DateTime filterDate = new DateTime();

            filterDate = DateTime.Now.AddDays(Properties.Settings.Default.JustLauchedTimeSpanInDays * -1);

            List<Project> justLaunchedProjects = this.UnitOfWork.ProjectRepository.GetAll(p => p.StartDate >= filterDate).ToList();
            justLaunched.projects = justLaunchedProjects;
            return justLaunched;
        }

        public Collection NearlyFunded()
        {
            Collection nearlyFunded = new Collection();
            List<Project> nearlyFundedProjects = this.UnitOfWork.ProjectRepository.GetAll(p => p.PercentageFunded >= Properties.Settings.Default.PercentageNearlyFunded).ToList();
            nearlyFunded.projects = nearlyFundedProjects;
            return nearlyFunded;
        }

        public Collection PerCategory(int categoryId)
        {
            Collection categoryCollection = new Collection();
            List<Project> categoryProjects = this.UnitOfWork.ProjectRepository.GetAll(p => p.Categories.Any(c=> c.Id == categoryId),null,"Categories").ToList();
            categoryCollection.projects = categoryProjects;
            return categoryCollection;
        }

        public Collection PerProjectType(ProjectType type)
        {
            Collection projectTypeCollection = new Collection();
            List<Project> projects = this.UnitOfWork.ProjectRepository.GetAll(p => p.Type == type).ToList();
            projectTypeCollection.projects = projects;
            return projectTypeCollection;
        }

        public Collection Recommended()
        {
            throw new NotImplementedException();
        }

        public Collection Trending()
        {
            throw new NotImplementedException();
        }
    }
}
