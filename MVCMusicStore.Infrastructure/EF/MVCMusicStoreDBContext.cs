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
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

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
            users.HasOptional(s => s.Address).WithRequired(p => p.ApplicationUser);
            users.Property(s => s.FirstName).IsOptional().HasMaxLength(100);
            users.Property(s => s.Surname).IsOptional().HasMaxLength(100);

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

            userAddress.HasRequired(s => s.ApplicationUser).WithOptional(p => p.Address);
            userAddress.Property(s => s.Address1).IsRequired().HasMaxLength(200);
            userAddress.Property(s => s.Address2).IsOptional().HasMaxLength(200);
            userAddress.Property(s => s.City).IsRequired().HasMaxLength(50);
            userAddress.Property(s => s.Country).IsRequired().HasMaxLength(50);
            userAddress.Property(s => s.State).IsRequired().HasMaxLength(50);
            userAddress.Property(s => s.ZipCode).IsRequired().HasMaxLength(20);
            userAddress.Property(s => s.UpdatedAt).IsRequired();

            //Artists table
            var artist = modelBuilder.Entity<Artist>();

            artist.ToTable("Artists");
            artist.HasKey<Guid>(s => s.ArtistId);
            artist.HasMany(s => s.Albums).WithMany(p => p.Artists);
            artist.Property(s => s.ArtistId).IsRequired();
            artist.Property(s => s.Name).IsRequired().HasMaxLength(200);
            artist.Property(s => s.Country).IsOptional().HasMaxLength(100);
            artist.Property(s => s.UpdatedAt).IsRequired();

            //Albums table
            var albums = modelBuilder.Entity<Album>();

            albums.ToTable("Albums");
            albums.HasKey<Guid>(s => s.AlbumId);
            albums.HasRequired(s => s.Genre).WithMany(p => p.Albums).HasForeignKey(x => x.GenreId);
            albums.Property(s => s.Title).IsRequired().HasMaxLength(300);
            albums.Property(s => s.Price).IsRequired().HasPrecision(8, 2);
            albums.Property(s => s.UpdatedAt).IsRequired();

            //Genres table
            var genres = modelBuilder.Entity<Genre>();
            genres.ToTable("Genres");
            genres.HasKey<Guid>(s => s.GenreId);
            genres.Property(s => s.Name).IsRequired().HasMaxLength(50);
            genres.Property(s => s.UpdatedAt).IsRequired();
        }
    }
}
