namespace Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Email = c.String(),
                        MobileNO = c.String(),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeProjects",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ProjectId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectDetails = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.EmployeeProjects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeProjects", new[] { "ProjectId" });
            DropIndex("dbo.EmployeeProjects", new[] { "EmployeeId" });
            DropTable("dbo.Projects");
            DropTable("dbo.EmployeeProjects");
            DropTable("dbo.Employees");
        }
    }
}
