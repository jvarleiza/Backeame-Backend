using Backeame.Data.Access;
using Backeame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Backeame.Data.Repository.Implementation
{
    public class ProjectRepository: GenericRepository<Project>
    {
        internal BackeameContext context;
        internal DbSet<Project> dbSet;

        public ProjectRepository(BackeameContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Project>();
        }

        public Project Tinder()
        {
            IQueryable<Project> query = dbSet.GetNonDeleted<Project>();
            var rand = new Random();
            Project p = query.ElementAt(rand.Next(query.Count()));
            return p;
        }
    }
}
