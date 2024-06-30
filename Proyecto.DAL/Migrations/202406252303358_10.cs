namespace Proyecto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Proveedores", "CodigoTributario");
            AlterColumn("dbo.Proveedores", "CodigoTributario", c => c.String(nullable: false, maxLength: 16));
            CreateIndex("dbo.Proveedores", "CodigoTributario", unique: true, name: "CodigoTributario");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Proveedores", "CodigoTributario");
            AlterColumn("dbo.Proveedores", "CodigoTributario", c => c.String(nullable: false, maxLength: 14));
            CreateIndex("dbo.Proveedores", "CodigoTributario", unique: true, name: "CodigoTributario");
        }
    }
}
