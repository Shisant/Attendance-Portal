namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShisantGroup2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Contact", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Staffs", "Contact", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "Contact", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Contact", c => c.Int(nullable: false));
        }
    }
}
