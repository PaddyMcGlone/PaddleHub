namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePaddleTypestable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PADDLETYPES(ID, NAME) VALUES (1, 'River running')");
            Sql("INSERT INTO PADDLETYPES(ID, NAME) VALUES (2, 'Freestyle')");
            Sql("INSERT INTO PADDLETYPES(ID, NAME) VALUES (3, 'Creeking')");
            Sql("INSERT INTO PADDLETYPES(ID, NAME) VALUES (4, 'Recreational')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM PADDLESTYPES WHERE ID IN (1,2,3,4)");
        }
    }
}
