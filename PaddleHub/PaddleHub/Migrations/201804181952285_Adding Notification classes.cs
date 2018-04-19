namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNotificationclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        NotificationType = c.Int(nullable: false),
                        OriginalDateTime = c.DateTime(),
                        OriginalLocation = c.String(),
                        Paddle_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paddles", t => t.Paddle_Id, cascadeDelete: true)
                .Index(t => t.Paddle_Id);
            
            CreateTable(
                "dbo.UserNotifcations",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifcations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifcations", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "Paddle_Id", "dbo.Paddles");
            DropIndex("dbo.UserNotifcations", new[] { "NotificationId" });
            DropIndex("dbo.UserNotifcations", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "Paddle_Id" });
            DropTable("dbo.UserNotifcations");
            DropTable("dbo.Notifications");
        }
    }
}
