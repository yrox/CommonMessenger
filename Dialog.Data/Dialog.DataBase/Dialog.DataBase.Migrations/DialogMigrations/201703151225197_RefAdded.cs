namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefAdded : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserReferences");
        }

        public override void Down()
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
        }
    }
}
