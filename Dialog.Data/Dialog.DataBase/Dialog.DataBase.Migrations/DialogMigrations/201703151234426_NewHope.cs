namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewHope : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "UserReference_Id", "dbo.Users");
            DropForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "UserReference_Id" });
            DropIndex("dbo.MetaContacts", new[] { "UserReference_Id" });
            DropColumn("dbo.Accounts", "UserReference_Id");
            DropColumn("dbo.MetaContacts", "UserReference_Id");
            //DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Users",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Email = c.Int(nullable: false),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MetaContacts", "UserReference_Id", c => c.Int());
            AddColumn("dbo.Accounts", "UserReference_Id", c => c.Int());
            CreateIndex("dbo.MetaContacts", "UserReference_Id");
            CreateIndex("dbo.Accounts", "UserReference_Id");
            AddForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Accounts", "UserReference_Id", "dbo.Users", "Id");
        }
    }
}
