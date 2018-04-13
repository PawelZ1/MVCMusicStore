namespace MVCMusicStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityconnections5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropIndex("dbo.Albums", new[] { "GenreId" });
            AlterColumn("dbo.Albums", "GenreId", c => c.Guid());
            CreateIndex("dbo.Albums", "GenreId");
            AddForeignKey("dbo.Albums", "GenreId", "dbo.Genres", "GenreId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropIndex("dbo.Albums", new[] { "GenreId" });
            AlterColumn("dbo.Albums", "GenreId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Albums", "GenreId");
            AddForeignKey("dbo.Albums", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
        }
    }
}
