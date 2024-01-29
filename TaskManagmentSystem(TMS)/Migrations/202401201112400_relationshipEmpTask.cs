namespace TaskManagmentSystem_TMS_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipEmpTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        setPrority = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .Index(t => t.Employees_Id);            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "Employees_Id" });
            DropTable("dbo.Tasks");
        }
    }
}
