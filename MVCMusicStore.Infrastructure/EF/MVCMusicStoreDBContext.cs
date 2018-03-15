namespace MVCMusicStore.Infrastructure.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCMusicStore.Core.Models;

    public partial class MVCMusicStoreDBContext : IdentityDbContext<ApplicationUser>
    {
        public MVCMusicStoreDBContext()
            : base("name=MVCMusicStoreDBContext")
        {
        }

        public static MVCMusicStoreDBContext Create()
        {
            return new MVCMusicStoreDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Users table
            var users = modelBuilder.Entity<ApplicationUser>();
            users.ToTable("Users");

            //Roles table
            var roles = modelBuilder.Entity<IdentityRole>();
            roles.ToTable("Roles");

            //User roles table
            var userRoles = modelBuilder.Entity<IdentityUserRole>();
            userRoles.ToTable("UserRoles");

            //User logins table
            var userLogins = modelBuilder.Entity<IdentityUserLogin>();
            userLogins.ToTable("UserLogins");

            //User claims table
            var userClaims = modelBuilder.Entity<IdentityUserClaim>();
            userClaims.ToTable("UserClaims");
        }
    }
}
