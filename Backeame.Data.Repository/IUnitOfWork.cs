using Backeame.Data.Entities;
using System;

namespace Backeame.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Authentication Repository
        /// </summary>
        IAuthRepository AuthRepository { get; }

        /// <summary>
        /// Backer Repository
        /// </summary>
        IRepository<Backer> BackerRepository { get; }

        /// <summary>
        /// Project Repository
        /// </summary>
        IRepository<Project> ProjectRepository { get; }

        /// <summary>
        /// Test Repository
        /// </summary>
        IRepository<Test> TestRepository { get; }
        
        /// <summary>
        /// Method that uses generics to obtain the current entity repository.
        /// Ex: GetRepository-Auth-(); returns AuthRepository
        /// </summary>
        /// <typeparam name="T">Model entity type</typeparam>
        /// <returns>IRepository-T-</returns>
        IRepository<T> GetRepository<T>() where T : class;

        void Seed();

        /// <summary>
        /// Save all changes to the context
        /// </summary>
        void Save();
    }
}
