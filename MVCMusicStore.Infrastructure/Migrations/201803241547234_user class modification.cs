namespace MVCMusicStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userclassmodification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "Surname", c => c.String());
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
