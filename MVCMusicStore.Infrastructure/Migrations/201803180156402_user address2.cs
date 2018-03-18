namespace MVCMusicStore.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useraddress2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserAddresses", name: "ApplicationUser_Id", newName: "UserAddressId");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_ApplicationUser_Id", newName: "IX_UserAddressId");
            DropPrimaryKey("dbo.UserAddresses");
            AlterColumn("dbo.UserAddresses", "Address1", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "State", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "Country", c => c.String(nullable: false));
            AddPrimaryKey("dbo.UserAddresses", "UserAddressId");
            DropColumn("dbo.UserAddresses", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAddresses", "ApplicationUserId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.UserAddresses");
            AlterColumn("dbo.UserAddresses", "Country", c => c.String());
            AlterColumn("dbo.UserAddresses", "State", c => c.String());
            AlterColumn("dbo.UserAddresses", "ZipCode", c => c.String());
            AlterColumn("dbo.UserAddresses", "City", c => c.String());
            AlterColumn("dbo.UserAddresses", "Address1", c => c.String());
            AddPrimaryKey("dbo.UserAddresses", "ApplicationUserId");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_UserAddressId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.UserAddresses", name: "UserAddressId", newName: "ApplicationUser_Id");
        }
    }
}
