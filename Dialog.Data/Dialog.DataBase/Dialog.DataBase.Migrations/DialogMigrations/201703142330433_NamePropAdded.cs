namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamePropAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MetaContacts", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MetaContacts", "Name");
        }
    }
}
