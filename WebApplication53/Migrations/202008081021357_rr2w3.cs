namespace WebApplication53.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rr2w3 : DbMigration
    {
        public override void Up()
        {
          
      
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "EmpId");
            AddPrimaryKey("dbo.Employees", "EmployeeId");
        }
    }
}
