namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualMtaContact : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Contacts", "MetaContact_Id", c => c.Int());
            //AddColumn("dbo.Messages", "MetaContact_Id", c => c.Int());
            //CreateIndex("dbo.Contacts", "MetaContact_Id");
            //CreateIndex("dbo.Messages", "MetaContact_Id");
            //AddForeignKey("dbo.Contacts", "MetaContact_Id", "dbo.MetaContacts", "Id");
            //AddForeignKey("dbo.Messages", "MetaContact_Id", "dbo.MetaContacts", "Id");
            //DropColumn("dbo.Contacts", "MetaContactId");
            //DropColumn("dbo.Messages", "MetaContactId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Messages", "MetaContactId", c => c.Int(nullable: false));
            //AddColumn("dbo.Contacts", "MetaContactId", c => c.Int());
            //DropForeignKey("dbo.Messages", "MetaContact_Id", "dbo.MetaContacts");
            //DropForeignKey("dbo.Contacts", "MetaContact_Id", "dbo.MetaContacts");
            //DropIndex("dbo.Messages", new[] { "MetaContact_Id" });
            //DropIndex("dbo.Contacts", new[] { "MetaContact_Id" });
            //DropColumn("dbo.Messages", "MetaContact_Id");
            //DropColumn("dbo.Contacts", "MetaContact_Id");
        }
    }
}
