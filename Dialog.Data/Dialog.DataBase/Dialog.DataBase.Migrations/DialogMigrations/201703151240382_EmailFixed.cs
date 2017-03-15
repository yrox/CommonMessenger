namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailFixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserReferences", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserReferences", "Email", c => c.Int(nullable: false));
        }
    }
}
