namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingpostcodetoregisterpage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Postcode");
        }
    }
}
