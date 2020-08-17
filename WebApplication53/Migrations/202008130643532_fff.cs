namespace WebApplication53.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Xxx", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Xxx");
        }
    }
}
