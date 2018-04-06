namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingiscancelledtothepaddledomainmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paddles", "IsCancelled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paddles", "IsCancelled");
        }
    }
}
