namespace MVCMusicStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityconnections2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
        }
    }
}
