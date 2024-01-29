namespace TaskManagmentSystem_TMS_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tasks", name: "Employees_Id", newName: "Employee_Id");
            RenameIndex(table: "dbo.Tasks", name: "IX_Employees_Id", newName: "IX_Employee_Id");
            AddColumn("dbo.Tasks", "Priority", c => c.String());
            AddColumn("dbo.Tasks", "SelectedEmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.Tasks", "setPrority");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "setPrority", c => c.String());
            DropColumn("dbo.Tasks", "SelectedEmployeeId");
            DropColumn("dbo.Tasks", "Priority");
            RenameIndex(table: "dbo.Tasks", name: "IX_Employee_Id", newName: "IX_Employees_Id");
            RenameColumn(table: "dbo.Tasks", name: "Employee_Id", newName: "Employees_Id");
        }
    }
}
