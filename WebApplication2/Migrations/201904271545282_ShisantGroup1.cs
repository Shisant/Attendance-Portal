namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShisantGroup1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "AttendDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "AttendDate");
        }
    }
}
