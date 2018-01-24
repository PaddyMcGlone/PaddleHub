namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPaddleandPaddleTypemodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paddles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Paddler_Id = c.String(maxLength: 128),
                        PaddleType_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Paddler_Id)
                .ForeignKey("dbo.PaddleTypes", t => t.PaddleType_Id)
                .Index(t => t.Paddler_Id)
                .Index(t => t.PaddleType_Id);
            
            CreateTable(
                "dbo.PaddleTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paddles", "PaddleType_Id", "dbo.PaddleTypes");
            DropForeignKey("dbo.Paddles", "Paddler_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Paddles", new[] { "PaddleType_Id" });
            DropIndex("dbo.Paddles", new[] { "Paddler_Id" });
            DropTable("dbo.PaddleTypes");
            DropTable("dbo.Paddles");
        }
    }
}
