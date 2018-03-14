using Backeame.Data.Access;
using Backeame.Data.Entities;
using Backeame.Data.Repository;
using Backeame.Magic.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Backeame.Data.Repository.Implementation
{
    public class BackerRepository : IRepository<Backer>
    {
        internal BackeameContext context;
        internal DbSet<Backer> dbSet;

        public BackerRepository(BackeameContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Backer>();
        }

        /// <summary>
        /// Get all non deleted records
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IEnumerable<Backer> Get(
            Expression<Func<Backer, bool>> filter = null,
            Func<IQueryable<Backer>, IOrderedQueryable<Backer>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<Backer> query = dbSet.GetNonDeleted<Backer>(true);

            return PrivateGet(query, filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Get all records from database, including deleted ones.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IEnumerable<Backer> GetAll(
            Expression<Func<Backer, bool>> filter = null,
            Func<IQueryable<Backer>, IOrderedQueryable<Backer>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<Backer> query = dbSet;

            return PrivateGet(query, filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Gets all records from query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        private IEnumerable<Backer> PrivateGet(
            IQueryable<Backer> query,
            Expression<Func<Backer, bool>> filter = null,
            Func<IQueryable<Backer>, IOrderedQueryable<Backer>> orderBy = null,
            string includeProperties = "")
        {
            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public virtual Backer GetById(object id)
        {
            var searchedEntity = dbSet.GetNonDeleted(true).Where(e => e.Id.Equals(id));
            return searchedEntity.IsNotEmpty() ? searchedEntity.SingleOrDefault() : null;
        }

        public virtual void Insert(Backer entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            Backer entityToDelete = this.GetById(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(Backer entityToDelete)
        {
            entityToDelete.IsDeleted = true;
            Update(entityToDelete);
        }

        public virtual void Update(Backer entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IEnumerable<Backer> GetSequence(int take, 
            int skip = 0, 
            Expression<Func<Backer, bool>> filter = null, 
            Func<IQueryable<Backer>, IOrderedQueryable<Backer>> orderBy = null, 
            string includeProperties = null)
        {
            IQueryable<Backer> query = dbSet;

            var returnList = PrivateGet(query, filter, orderBy, includeProperties)
                                    .Skip(skip)
                                    .Take(take)
                                    .ToList();

            return returnList;
        }
    }
}
