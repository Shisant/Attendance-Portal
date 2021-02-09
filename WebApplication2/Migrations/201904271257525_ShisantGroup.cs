namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ShisantGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                {
                    attendenceId = c.Int(nullable: false, identity: true),
                    attendenceRemark = c.String(),
                    timeTableId = c.Int(nullable: false),
                    StudentId = c.Int(nullable: false),
                    CourseId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.attendenceId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Timetables", t => t.timeTableId, cascadeDelete: true)
                .Index(t => t.timeTableId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);

            CreateTable(
                "dbo.StudentFaculties",
                c => new
                {
                    studentFacultyId = c.Int(nullable: false, identity: true),
                    facultyId = c.Int(nullable: false),
                    studentId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.studentFacultyId)
                .ForeignKey("dbo.Faculties", t => t.facultyId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.studentId, cascadeDelete: true)
                .Index(t => t.facultyId)
                .Index(t => t.studentId);

        }

    }
}
