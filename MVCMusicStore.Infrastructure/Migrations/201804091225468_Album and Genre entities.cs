namespace MVCMusicStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumandGenreentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 300),
                        Price = c.Decimal(nullable: false, precision: 8, scale: 2),
                        UpdatedAt = c.DateTime(nullable: false),
                        GenreId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.ArtistAlbums",
                c => new
                    {
                        Artist_ArtistId = c.Guid(nullable: false),
                        Album_AlbumId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_ArtistId, t.Album_AlbumId })
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => t.Artist_ArtistId)
                .Index(t => t.Album_AlbumId);
            
            AddColumn("dbo.Artists", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Artists", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Artists", "Country", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserAddresses", "Address1", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.UserAddresses", "Address2", c => c.String(maxLength: 200));
            AlterColumn("dbo.UserAddresses", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserAddresses", "ZipCode", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.UserAddresses", "State", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserAddresses", "Country", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.ArtistAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.ArtistAlbums", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.ArtistAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.ArtistAlbums", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Albums", new[] { "GenreId" });
            AlterColumn("dbo.UserAddresses", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "State", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "Address2", c => c.String());
            AlterColumn("dbo.UserAddresses", "Address1", c => c.String(nullable: false));
            AlterColumn("dbo.Artists", "Country", c => c.String());
            AlterColumn("dbo.Artists", "Name", c => c.String());
            DropColumn("dbo.Artists", "UpdatedAt");
            DropTable("dbo.ArtistAlbums");
            DropTable("dbo.Genres");
            DropTable("dbo.Albums");
        }
    }
}
