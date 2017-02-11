namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetaContactIdNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "MetaContactId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "MetaContactId", c => c.Int(nullable: false));
        }
    }
}
