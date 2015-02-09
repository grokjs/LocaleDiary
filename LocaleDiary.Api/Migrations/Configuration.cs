using LocaleDiary.Api.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LocaleDiary.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LocaleDiary.Api.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LocaleDiary.Api.Infrastructure.ApplicationDbContext context)
        {
            var manager = 
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "LocaleDiaryAdmin",
                Email = "admin@localdiary.com",
                EmailConfirmed = true,
                FirstName = "Alexander",
                LastName = "DiMauro",
                JoinDate = DateTime.Now
            };

            manager.Create(user, "NduCk?JaD4,)mP7vca");
        }
    }
}
