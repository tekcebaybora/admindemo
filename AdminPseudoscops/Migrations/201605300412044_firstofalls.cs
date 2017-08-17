namespace AdminPseudoscops.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstofalls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        DeviceId = c.String(nullable: false, maxLength: 75),
                        DeviceKey = c.String(maxLength: 250),
                        Location = c.String(nullable: false, maxLength: 75),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId);
            
            CreateTable(
                "dbo.EventHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        IsInside = c.Int(nullable: false),
                        DeviceId = c.String(nullable: false, maxLength: 75),
                        EventTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GateAccessUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.GateAccessUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Name = c.String(maxLength: 75),
                        Surname = c.String(maxLength: 75),
                        Mail = c.String(maxLength: 75),
                        Status = c.String(maxLength: 75),
                        Info = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserNFCTags",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        PhysicalTag = c.String(nullable: false, maxLength: 75),
                        VirtualTag = c.String(maxLength: 75),
                        Status = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.GateAccessUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventHistories", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.UserNFCTags", "UserId", "dbo.GateAccessUsers");
            DropForeignKey("dbo.EventHistories", "UserId", "dbo.GateAccessUsers");
            DropIndex("dbo.UserNFCTags", new[] { "UserId" });
            DropIndex("dbo.EventHistories", new[] { "DeviceId" });
            DropIndex("dbo.EventHistories", new[] { "UserId" });
            DropTable("dbo.UserNFCTags");
            DropTable("dbo.GateAccessUsers");
            DropTable("dbo.EventHistories");
            DropTable("dbo.Devices");
        }
    }
}
