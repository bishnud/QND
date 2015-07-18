namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "LastName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "LastName", c => c.String());
            AlterColumn("dbo.Employee", "FirstName", c => c.String());
        }
    }
}
