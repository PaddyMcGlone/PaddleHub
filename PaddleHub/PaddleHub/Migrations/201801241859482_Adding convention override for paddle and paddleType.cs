namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingconventionoverrideforpaddleandpaddleType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Paddles", "Paddler_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Paddles", "PaddleType_Id", "dbo.PaddleTypes");
            DropIndex("dbo.Paddles", new[] { "Paddler_Id" });
            DropIndex("dbo.Paddles", new[] { "PaddleType_Id" });
            AlterColumn("dbo.Paddles", "Location", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Paddles", "Paddler_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Paddles", "PaddleType_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.PaddleTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Paddles", "Paddler_Id");
            CreateIndex("dbo.Paddles", "PaddleType_Id");
            AddForeignKey("dbo.Paddles", "Paddler_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Paddles", "PaddleType_Id", "dbo.PaddleTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paddles", "PaddleType_Id", "dbo.PaddleTypes");
            DropForeignKey("dbo.Paddles", "Paddler_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Paddles", new[] { "PaddleType_Id" });
            DropIndex("dbo.Paddles", new[] { "Paddler_Id" });
            AlterColumn("dbo.PaddleTypes", "Name", c => c.String());
            AlterColumn("dbo.Paddles", "PaddleType_Id", c => c.Byte());
            AlterColumn("dbo.Paddles", "Paddler_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Paddles", "Location", c => c.String());
            CreateIndex("dbo.Paddles", "PaddleType_Id");
            CreateIndex("dbo.Paddles", "Paddler_Id");
            AddForeignKey("dbo.Paddles", "PaddleType_Id", "dbo.PaddleTypes", "Id");
            AddForeignKey("dbo.Paddles", "Paddler_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
