namespace WebApplication53.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fffdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Period = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        City = c.String(),
                        StudentImg = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "StudentId", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
