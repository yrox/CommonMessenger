namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetaContactEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MetaContacts");
        }
    }
}
