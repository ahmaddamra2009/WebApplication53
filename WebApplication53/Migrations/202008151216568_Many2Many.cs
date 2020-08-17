namespace WebApplication53.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Many2Many : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colleges",
                c => new
                    {
                        CollegeId = c.Int(nullable: false, identity: true),
                        CollegeName = c.String(),
                    })
                .PrimaryKey(t => t.CollegeId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                        DoctorCity = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "dbo.DoctorColleges",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        CollegeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.CollegeId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Colleges", t => t.CollegeId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.CollegeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorColleges", "CollegeId", "dbo.Colleges");
            DropForeignKey("dbo.DoctorColleges", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.DoctorColleges", new[] { "CollegeId" });
            DropIndex("dbo.DoctorColleges", new[] { "DoctorId" });
            DropTable("dbo.DoctorColleges");
            DropTable("dbo.Doctors");
            DropTable("dbo.Colleges");
        }
    }
}
