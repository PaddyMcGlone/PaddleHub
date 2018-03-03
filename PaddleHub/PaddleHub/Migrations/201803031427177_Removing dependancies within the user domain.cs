namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removingdependancieswithintheuserdomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        DateOfBirth = c.DateTime(nullable: false),
                        CANIMembershipNumber = c.String(nullable: false, maxLength: 4),
                        MedicalDetails = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserDetailsId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "UserDetailsId");
            AddForeignKey("dbo.AspNetUsers", "UserDetailsId", "dbo.UserDetails", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "CANIMembershipNumber");
            DropColumn("dbo.AspNetUsers", "MedicalDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MedicalDetails", c => c.String());
            AddColumn("dbo.AspNetUsers", "CANIMembershipNumber", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.AspNetUsers", "UserDetailsId", "dbo.UserDetails");
            DropIndex("dbo.AspNetUsers", new[] { "UserDetailsId" });
            DropColumn("dbo.AspNetUsers", "UserDetailsId");
            DropTable("dbo.UserDetails");
        }
    }
}
