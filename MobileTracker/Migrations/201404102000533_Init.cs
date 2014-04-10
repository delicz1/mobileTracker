namespace MobileTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Imei = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        EventTypeId = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeId, cascadeDelete: true)
                .Index(t => t.DeviceId)
                .Index(t => t.EventTypeId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.EventTypeId);
            
            CreateTable(
                "dbo.Gps",
                c => new
                    {
                        GpsId = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.GpsId)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        GroupId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Time = c.Int(nullable: false),
                        DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
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
