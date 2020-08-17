namespace WebApplication53.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Many2Many2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorColleges",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        CollegeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.CollegeId })
                .ForeignKey("dbo.Colleges", t => t.CollegeId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.CollegeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorColleges", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorColleges", "CollegeId", "dbo.Colleges");
            DropIndex("dbo.DoctorColleges", new[] { "CollegeId" });
            DropIndex("dbo.DoctorColleges", new[] { "DoctorId" });
            DropTable("dbo.DoctorColleges");
        }
    }
}
