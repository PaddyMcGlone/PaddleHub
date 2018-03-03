namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatingtheuserdomainmodeltocontainrequiredcanidata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "AddressLine1", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "AddressLine2", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "AddressLine3", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "CANIMembershipNumber", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.AspNetUsers", "MedicalDetails", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MedicalDetails");
            DropColumn("dbo.AspNetUsers", "CANIMembershipNumber");
            DropColumn("dbo.AspNetUsers", "AddressLine3");
            DropColumn("dbo.AspNetUsers", "AddressLine2");
            DropColumn("dbo.AspNetUsers", "AddressLine1");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
        }
    }
}
