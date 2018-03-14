using System.Collections.Generic;

namespace Backeame.Business
{
    public interface IBaseLogic<Entity>
        where Entity : class
    {
        /// <summary>
        /// Creates new entity
        /// </summary>
        /// <param name="entity">New entity</param>
        /// <returns></returns>
        bool Create(Entity entity);

        /// <summary>
        /// Update a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(Entity entity);

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(Entity entity);

        /// <summary>
        /// Delete a entity by its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(object id);

        /// <summary>
        /// Get all entities in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Entity> GetAll();

        /// <summary>
        /// Get a segment of records in database
        /// </summary>
        /// <param name="page"></param>
        /// <param name="elementCount"></param>
        /// <returns></returns>
        IEnumerable<Entity> GetSegment(int page, int elementCount = 20);

        /// <summary>
        /// Get a entity by its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Entity Get(object id);

        /// <summary>
        /// Dispose
        /// </summary>
        void Dispose();
    }
}

