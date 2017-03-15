namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewRef : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserReferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accounts", "UserReference_Id", c => c.Int());
            AddColumn("dbo.MetaContacts", "UserReference_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "UserReference_Id");
            CreateIndex("dbo.MetaContacts", "UserReference_Id");
            AddForeignKey("dbo.Accounts", "UserReference_Id", "dbo.UserReferences", "Id");
            AddForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.UserReferences", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.UserReferences");
            DropForeignKey("dbo.Accounts", "UserReference_Id", "dbo.UserReferences");
            DropIndex("dbo.MetaContacts", new[] { "UserReference_Id" });
            DropIndex("dbo.Accounts", new[] { "UserReference_Id" });
            DropColumn("dbo.MetaContacts", "UserReference_Id");
            DropColumn("dbo.Accounts", "UserReference_Id");
            DropTable("dbo.UserReferences");
        }
    }
}
