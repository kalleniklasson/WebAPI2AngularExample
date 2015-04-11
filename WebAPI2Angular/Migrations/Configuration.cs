using WebAPI2Angular.DAL;
using System.Data.Entity.Migrations;
using WebAPI2Angular.Models;

namespace WebAPI2Angular.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationContext context)
        {
            context.Persons.AddOrUpdate(p => p.FirstName, new Person { FirstName = "Niklas", LastName = "Karlsson" });
            context.Persons.AddOrUpdate(p => p.FirstName, new Person { FirstName = "Karl", LastName = "Niklasson" });
            context.SaveChanges();
        }
    }
}
