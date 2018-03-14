using Backeame.Data.Access;
using System;
using System.Linq;
using Backeame.Data.Entities;

namespace Backeame.Data.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private BackeameContext context;
        private AuthRepository authRepository;
        private BackerRepository backerRepository;
        private GenericRepository<Project> projectRepository;
        private GenericRepository<Test> testRepository;
        private bool disposed = false;

        public UnitOfWork(BackeameContext context)
        {
            this.context = context;
        }

        public IAuthRepository AuthRepository
        {
            get
            {
                if (this.authRepository == null)
                {
                    this.authRepository = new AuthRepository(context);
                }
                return authRepository;
            }
        }

        public IRepository<Backer> BackerRepository
        {
            get
            {
                if (this.backerRepository == null)
                {
                    this.backerRepository = new BackerRepository(context);
                }
                return backerRepository;
            }
        }

        public IRepository<Project> ProjectRepository
        {
            get
            {
                if (this.projectRepository == null)
                {
                    this.projectRepository = new GenericRepository<Project>(context);
                }
                return projectRepository;
            }
        }

        public IRepository<Test> TestRepository
        {
            get
            {
                if (this.testRepository == null)
                {
                    this.testRepository = new GenericRepository<Test>(context);
                }
                return testRepository;
            }
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var props = this.GetType()
                .GetProperties();
            var prop = props
                .Where(p => p
                    .PropertyType
                    .IsConstructedGenericType && p.PropertyType.GenericTypeArguments.Contains(typeof(T)))
                .First().GetValue(this);
            return (IRepository<T>)prop;
        }

        public void Seed()
        {
            TestData.Create(context);
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
