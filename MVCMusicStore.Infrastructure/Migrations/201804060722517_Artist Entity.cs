namespace MVCMusicStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtistEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Guid(nullable: false),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Artists");
        }
    }
}
