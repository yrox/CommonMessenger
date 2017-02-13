namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdinUserRef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserReferences", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Text");
            DropColumn("dbo.UserReferences", "UserId");
        }
    }
}
