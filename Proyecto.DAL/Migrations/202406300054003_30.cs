namespace Proyecto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Empleados", "Estado_Empleado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleados", "Estado_Empleado", c => c.Boolean(nullable: false));
        }
    }
}
