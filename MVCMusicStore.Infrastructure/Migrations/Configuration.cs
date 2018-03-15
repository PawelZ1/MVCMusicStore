namespace MVCMusicStore.Infrastructure.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCMusicStore.Core.Models;
    using MVCMusicStore.Infrastructure.Service;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCMusicStore.Infrastructure.EF.MVCMusicStoreDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCMusicStore.Infrastructure.EF.MVCMusicStoreDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ApplicationUserManager _userMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            // Seeding user roles
            // _roleManager.CreateAsync(new IdentityRole());
        }
    }
}
