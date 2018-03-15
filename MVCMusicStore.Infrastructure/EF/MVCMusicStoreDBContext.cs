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
            //Users table
            var users = modelBuilder.Entity<ApplicationUser>();

            users.ToTable("Users");

            base.OnModelCreating(modelBuilder);
        }
    }
}
