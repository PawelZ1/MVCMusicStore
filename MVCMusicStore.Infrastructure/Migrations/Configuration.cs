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

            ApplicationUserManager _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Seeding user roles
            IdentityRole master = new IdentityRole("Master Admin");
            IdentityRole admin = new IdentityRole("Admin");
            IdentityRole user = new IdentityRole("User");

            if (!_roleManager.RoleExists(master.Name))
                _roleManager.Create(master);

            if (!_roleManager.RoleExists(admin.Name))
                _roleManager.Create(admin);

            if (!_roleManager.RoleExists(user.Name))
                _roleManager.Create(user);

            // Seeding Master Admin

            if (_userManager.FindByName("MasterAdmin@email.com") == null)
                _userManager.Create(new ApplicationUser { UserName = "MasterAdmin@email.com", Email = "MasterAdmin@email.com" }, "Admin1");
            var masterAdmin = _userManager.FindByName("MasterAdmin@email.com");

            if (!_userManager.IsInRole(masterAdmin.Id, master.Name))
                _userManager.AddToRole(masterAdmin.Id, master.Name);

            //Seeding
            base.Seed(context);
        }
    }
}
