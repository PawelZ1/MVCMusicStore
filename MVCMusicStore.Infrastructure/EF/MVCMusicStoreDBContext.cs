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
            Database.SetInitializer(new CreateDatabaseIfNotExists<MVCMusicStoreDBContext>());
        }

        public DbSet<UserAddress> UserAddresses { get; set; }

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
            users.HasOptional(s => s.Address).WithRequired(s => s.ApplicationUser);

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

            //User Address table
            var userAddress = modelBuilder.Entity<UserAddress>();
            userAddress.Property(s => s.Address1).IsRequired();
            userAddress.Property(s => s.City).IsRequired();
            userAddress.Property(s => s.Country).IsRequired();
            userAddress.Property(s => s.State).IsRequired();
            userAddress.Property(s => s.ZipCode).IsRequired();
            userAddress.Property(s => s.UpdatedAt).IsRequired();
        }
    }
}
