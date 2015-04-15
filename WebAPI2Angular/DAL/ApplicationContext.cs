using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI2Angular.Migrations;
using WebAPI2Angular.Models;

namespace WebAPI2Angular.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=ApplicationContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Configuration>());
        }
        public DbSet<Person> Persons { get; set; }
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = HttpContext.Current != null && HttpContext.Current.User != null
                ? HttpContext.Current.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).Created = DateTime.Now;
                    ((BaseEntity)entity.Entity).Creator = currentUsername;
                }

                ((BaseEntity)entity.Entity).Modified = DateTime.Now;
                ((BaseEntity)entity.Entity).Modifier = currentUsername;
            }

            return base.SaveChanges();
        }
    }
}