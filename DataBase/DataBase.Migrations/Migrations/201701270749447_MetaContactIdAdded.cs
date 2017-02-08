namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetaContactIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "MetaContactId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "MetaContactId");
        }
    }
}
