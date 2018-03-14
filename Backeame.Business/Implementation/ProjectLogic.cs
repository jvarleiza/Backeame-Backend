using System;
using Backeame.Data.Entities;
using Backeame.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Backeame.Business.Implementation
{
    public class ProjectLogic : BaseLogic<Project>, IProjectLogic
    {
        private readonly IUnitOfWork UnitOfWork;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="uof">Inject unit of work</param>
        public ProjectLogic(IUnitOfWork uof)
            : base(uof)
        {
            this.UnitOfWork = uof;
        }

        public Project Tinder()
        {     
            IEnumerable<Project> allProjects = this.UnitOfWork.ProjectRepository.GetAll();
            
            var rand = new Random();
            Project tinderProject = allProjects.ElementAt(rand.Next(allProjects.Count()));

            return tinderProject;
        }
    }
}
