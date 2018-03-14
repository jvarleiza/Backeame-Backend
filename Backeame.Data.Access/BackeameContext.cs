using Backeame.Data.Entities;
using Backeame.Data.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Backeame.Data.Access
{
    /// <summary>
    /// Database context
    /// </summary>
    public class BackeameContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Reference to Backers table
        /// </summary>
        public DbSet<Backer> Backers { get; set; }
        /// <summary>
        /// Reference to projects table
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Reference to categories table
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Reference to categories table
        /// </summary>
        public DbSet<Reward> Rewards { get; set; }
        /// <summary>
        /// Reference to test table
        /// </summary>
        public DbSet<Test> Test { get; set; }

        public BackeameContext():base("BackeameContext", throwIfV1Schema:false)           
        {
            //Configuration.ProxyCreationEnabled = false;

            //The following is done to force EntityFramwork.SqlServer to be deployed with the rest of the solution
            var x = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Reward>().Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Backer>().ToTable("Backer");

            modelBuilder.Entity<Project>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Project");
            });

            modelBuilder.Entity<Category>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Category");
            });
            modelBuilder.Entity<Reward>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Reward");
            });
            modelBuilder.Entity<Reward>()
                    .HasRequired<Project>(r => r.Project) // Student entity requires Standard 
                    .WithMany(s => s.Rewards);


            modelBuilder.Entity<Project>()
                .HasMany(u => u.Categories)
                .WithMany() // <- no parameter here because there is no navigation property
                .Map(m =>
                {
                    m.MapLeftKey("ProjectId");
                    m.MapRightKey("CategoryId");
                    m.ToTable("ProjectCategory");
                });


            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        /// <summary>
        /// Creates instance of the database.
        /// </summary>
        /// <returns></returns>
        public static BackeameContext Create()
        {
            return new BackeameContext();
        }
    }

    #region Extension methods for getting non-deleted
    public static class ContextExtensions
    {
        /// <summary>
        /// Automatically applies the filter for deleted entries.
        /// </summary>
        /// <typeparam name="TEntity">Entity Class Name</typeparam>
        /// <param name="set">Entity DbSet</param>
        /// <returns></returns>
        public static IQueryable<TEntity> GetNonDeleted<TEntity>(this IQueryable<TEntity> set) where TEntity : BaseEntity
        {
            return set.Where(entity => entity.IsDeleted == false);
        }
        public static IQueryable<TEntity> GetNonDeleted<TEntity>(this IQueryable<TEntity> set, bool softDelete) where TEntity : ISoftDelete
        {
            return set.Where(entity => entity.IsDeleted == false);
        }
    }
    #endregion
}