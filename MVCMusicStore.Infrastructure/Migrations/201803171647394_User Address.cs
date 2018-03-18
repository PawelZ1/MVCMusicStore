namespace MVCMusicStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        ApplicationUserId = c.Guid(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ApplicationUserId)
                .ForeignKey("dbo.Users", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddresses", "ApplicationUser_Id", "dbo.Users");
            DropIndex("dbo.UserAddresses", new[] { "ApplicationUser_Id" });
            DropTable("dbo.UserAddresses");
        }
    }
}
