namespace WebApplication53.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rr2w : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmpId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "EmployeeId");
            AddPrimaryKey("dbo.Employees", "EmpId");
        }
    }
}
