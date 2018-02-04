namespace PaddleHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingForeignKeystoPaddlemodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Paddles", name: "Paddler_Id", newName: "PaddlerId");
            RenameColumn(table: "dbo.Paddles", name: "PaddleType_Id", newName: "PaddleTypeId");
            RenameIndex(table: "dbo.Paddles", name: "IX_Paddler_Id", newName: "IX_PaddlerId");
            RenameIndex(table: "dbo.Paddles", name: "IX_PaddleType_Id", newName: "IX_PaddleTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Paddles", name: "IX_PaddleTypeId", newName: "IX_PaddleType_Id");
            RenameIndex(table: "dbo.Paddles", name: "IX_PaddlerId", newName: "IX_Paddler_Id");
            RenameColumn(table: "dbo.Paddles", name: "PaddleTypeId", newName: "PaddleType_Id");
            RenameColumn(table: "dbo.Paddles", name: "PaddlerId", newName: "Paddler_Id");
        }
    }
}
