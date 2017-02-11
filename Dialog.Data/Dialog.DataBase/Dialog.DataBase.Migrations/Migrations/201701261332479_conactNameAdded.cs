namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conactNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Name");
        }
    }
}
