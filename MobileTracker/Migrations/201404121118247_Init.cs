namespace MobileTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Gps",
                c => new
                    {
                        GpsId = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GpsId)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);      
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.Devices", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.AspNetUsers", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gps", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "DeviceId", "dbo.Devices");
            DropIndex("dbo.Messages", new[] { "DeviceId" });
            DropIndex("dbo.Devices", new[] { "GroupId" });
            DropIndex("dbo.AspNetUsers", new[] { "GroupId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Gps", new[] { "DeviceId" });
            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropIndex("dbo.Events", new[] { "DeviceId" });
            DropTable("dbo.Messages");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Groups");
            DropTable("dbo.Gps");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
            DropTable("dbo.Devices");
        }
    }
}
