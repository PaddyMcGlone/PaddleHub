namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addinguseraddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(nullable: false, maxLength: 30),
                        AddressLine2 = c.String(nullable: false, maxLength: 30),
                        AddressLine3 = c.String(nullable: false, maxLength: 30),
                        Postcode = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "AddressId");
            AddForeignKey("dbo.AspNetUsers", "AddressId", "dbo.UserAddresses", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "AddressLine1");
            DropColumn("dbo.AspNetUsers", "AddressLine2");
            DropColumn("dbo.AspNetUsers", "AddressLine3");
            DropColumn("dbo.AspNetUsers", "Postcode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.AspNetUsers", "AddressLine3", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "AddressLine2", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "AddressLine1", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.AspNetUsers", "AddressId", "dbo.UserAddresses");
            DropIndex("dbo.AspNetUsers", new[] { "AddressId" });
            DropColumn("dbo.AspNetUsers", "AddressId");
            DropTable("dbo.UserAddresses");
        }
    }
}
