namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAttendancetothecontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        PaddleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttendeeId, t.PaddleID })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Paddles", t => t.PaddleID)
                .Index(t => t.AttendeeId)
                .Index(t => t.PaddleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "PaddleID", "dbo.Paddles");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "PaddleID" });
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropTable("dbo.Attendances");
        }
    }
}
