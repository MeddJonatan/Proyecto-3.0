namespace Proyecto.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriasProductos",
                c => new
                    {
                        ID_CategoriaProducto = c.Int(nullable: false, identity: true),
                        Codigo_CategoriaProducto = c.String(nullable: false, maxLength: 5),
                        Nombre_CategoriaProducto = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID_CategoriaProducto)
                .Index(t => t.Codigo_CategoriaProducto, unique: true)
                .Index(t => t.Nombre_CategoriaProducto, unique: true);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ID_Producto = c.Int(nullable: false, identity: true),
                        Codigo_Producto = c.String(nullable: false, maxLength: 10),
                        NombreProducto = c.String(nullable: false, maxLength: 100),
                        ID_CategoriaProducto = c.Int(nullable: false),
                        ID_MarcaProducto = c.Int(nullable: false),
                        ID_UnidadMedida = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Producto)
                .ForeignKey("dbo.CategoriasProductos", t => t.ID_CategoriaProducto, cascadeDelete: true)
                .ForeignKey("dbo.MarcasProductos", t => t.ID_MarcaProducto, cascadeDelete: true)
                .ForeignKey("dbo.UnidadesMedidas", t => t.ID_UnidadMedida, cascadeDelete: true)
                .Index(t => t.Codigo_Producto, unique: true)
                .Index(t => t.ID_CategoriaProducto)
                .Index(t => t.ID_MarcaProducto)
                .Index(t => t.ID_UnidadMedida);
            
            CreateTable(
                "dbo.DetalleEntradas",
                c => new
                    {
                        ID_DetalleEntrada = c.Int(nullable: false, identity: true),
                        Cantidad_DetalleEntrada = c.Int(nullable: false),
                        Precio_DetalleEntrada = c.Double(nullable: false),
                        ID_Entrada = c.Int(nullable: false),
                        ID_Producto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_DetalleEntrada)
                .ForeignKey("dbo.Entradas", t => t.ID_Entrada, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.ID_Producto, cascadeDelete: true)
                .Index(t => t.ID_Entrada)
                .Index(t => t.ID_Producto);
            
            CreateTable(
                "dbo.Entradas",
                c => new
                    {
                        ID_Entrada = c.Int(nullable: false, identity: true),
                        CodigoEntrada = c.String(nullable: false, maxLength: 20),
                        FechaEntrada = c.DateTime(nullable: false),
                        ID_Proveedor = c.Int(nullable: false),
                        ID_TipoEntrada = c.Int(nullable: false),
                        ID_Empleado = c.Int(nullable: false),
                        Empleado_ID_DatoUsuario = c.Int(),
                        Tiendas_ID_Tienda = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Entrada)
                .ForeignKey("dbo.Empleados", t => t.Empleado_ID_DatoUsuario)
                .ForeignKey("dbo.Proveedores", t => t.ID_Proveedor, cascadeDelete: true)
                .ForeignKey("dbo.TiposEntradas", t => t.ID_TipoEntrada, cascadeDelete: true)
                .ForeignKey("dbo.Tiendas", t => t.Tiendas_ID_Tienda)
                .Index(t => t.CodigoEntrada, unique: true)
                .Index(t => t.ID_Proveedor)
                .Index(t => t.ID_TipoEntrada)
                .Index(t => t.Empleado_ID_DatoUsuario)
                .Index(t => t.Tiendas_ID_Tienda);
            
            CreateTable(
                "dbo.DatosUsuarios",
                c => new
                    {
                        ID_DatoUsuario = c.Int(nullable: false, identity: true),
                        PrimerNombre = c.String(nullable: false, maxLength: 50),
                        SegundoNombre = c.String(maxLength: 50),
                        PrimerApellido = c.String(nullable: false, maxLength: 50),
                        SegundoApellido = c.String(maxLength: 50),
                        Edad = c.Int(nullable: false),
                        ID_NumTelefono = c.Int(nullable: false),
                        ID_Genero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_DatoUsuario)
                .ForeignKey("dbo.Generos", t => t.ID_Genero, cascadeDelete: true)
                .ForeignKey("dbo.NumerosTelefonicos", t => t.ID_NumTelefono, cascadeDelete: true)
                .Index(t => t.ID_NumTelefono)
                .Index(t => t.ID_Genero);
            
            CreateTable(
                "dbo.DocumentoIdentidad",
                c => new
                    {
                        ID_DocumentoIdentidad = c.Int(nullable: false, identity: true),
                        Codigo_DocumentoIdentidad = c.String(nullable: false, maxLength: 14),
                        FechaEmision_DocumentoIdentidad = c.DateTime(nullable: false),
                        FechaFinalizacion_DocumentoIdentidad = c.DateTime(nullable: false),
                        ID_TipoDocumentoIdentidad = c.Int(nullable: false),
                        DatosUsuarios_ID_DatoUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.ID_DocumentoIdentidad)
                .ForeignKey("dbo.TipoDocumentoIdentidad", t => t.ID_TipoDocumentoIdentidad, cascadeDelete: true)
                .ForeignKey("dbo.DatosUsuarios", t => t.DatosUsuarios_ID_DatoUsuario)
                .Index(t => t.Codigo_DocumentoIdentidad, unique: true)
                .Index(t => t.ID_TipoDocumentoIdentidad)
                .Index(t => t.DatosUsuarios_ID_DatoUsuario);
            
            CreateTable(
                "dbo.TipoDocumentoIdentidad",
                c => new
                    {
                        ID_TipoDocumentoIdentidad = c.Int(nullable: false, identity: true),
                        Codigo_TipoDocumento = c.String(nullable: false, maxLength: 10),
                        Descripcion_TipoDocumentoIdentidad = c.String(nullable: false, maxLength: 100),
                        ID_Pais = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_TipoDocumentoIdentidad)
                .ForeignKey("dbo.Paises", t => t.ID_Pais, cascadeDelete: true)
                .Index(t => t.Codigo_TipoDocumento, unique: true)
                .Index(t => t.ID_Pais);
            
            CreateTable(
                "dbo.Paises",
                c => new
                    {
                        ID_Pais = c.Int(nullable: false, identity: true),
                        Codigo_Pais = c.String(nullable: false, maxLength: 3),
                        Nombre_Pais = c.String(nullable: false, maxLength: 100),
                        Nacionalidad = c.String(nullable: false, maxLength: 100),
                        Sufijo_Pais = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.ID_Pais)
                .Index(t => t.Codigo_Pais, unique: true)
                .Index(t => t.Nombre_Pais, unique: true);
            
            CreateTable(
                "dbo.Generos",
                c => new
                    {
                        ID_Genero = c.Int(nullable: false, identity: true),
                        Descripcion_Genero = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID_Genero);
            
            CreateTable(
                "dbo.NumerosTelefonicos",
                c => new
                    {
                        ID_NumTelefono = c.Int(nullable: false, identity: true),
                        NumeroTelefono = c.String(nullable: false),
                        ID_EmpresaTelefonica = c.Int(nullable: false),
                        Tiendas_ID_Tienda = c.Int(),
                    })
                .PrimaryKey(t => t.ID_NumTelefono)
                .ForeignKey("dbo.EmpresasTelefonicas", t => t.ID_EmpresaTelefonica, cascadeDelete: true)
                .ForeignKey("dbo.Tiendas", t => t.Tiendas_ID_Tienda)
                .Index(t => t.ID_EmpresaTelefonica)
                .Index(t => t.Tiendas_ID_Tienda);
            
            CreateTable(
                "dbo.Salidas",
                c => new
                    {
                        ID_Salida = c.Int(nullable: false, identity: true),
                        FechaSalida = c.DateTime(nullable: false),
                        ID_TipoSalida = c.Int(nullable: false),
                        ID_Empleado = c.Int(nullable: false),
                        ID_Cliente = c.Int(nullable: false),
                        Clientes_ID_DatoUsuario = c.Int(),
                        Empleados_ID_DatoUsuario = c.Int(),
                        Tiendas_ID_Tienda = c.Int(),
                    })
                .PrimaryKey(t => t.ID_Salida)
                .ForeignKey("dbo.Clientes", t => t.Clientes_ID_DatoUsuario)
                .ForeignKey("dbo.Empleados", t => t.Empleados_ID_DatoUsuario)
                .ForeignKey("dbo.TiposSalidas", t => t.ID_TipoSalida, cascadeDelete: true)
                .ForeignKey("dbo.Tiendas", t => t.Tiendas_ID_Tienda)
                .Index(t => t.ID_TipoSalida)
                .Index(t => t.Clientes_ID_DatoUsuario)
                .Index(t => t.Empleados_ID_DatoUsuario)
                .Index(t => t.Tiendas_ID_Tienda);
            
            CreateTable(
                "dbo.DetalleSalidas",
                c => new
                    {
                        ID_DetalleSalida = c.Int(nullable: false, identity: true),
                        Cantidad_DetalleSalida = c.Int(nullable: false),
                        Precio_DetalleSalida = c.Double(nullable: false),
                        ID_Salida = c.Int(nullable: false),
                        ID_Producto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_DetalleSalida)
                .ForeignKey("dbo.Productos", t => t.ID_Producto, cascadeDelete: true)
                .ForeignKey("dbo.Salidas", t => t.ID_Salida, cascadeDelete: true)
                .Index(t => t.ID_Salida)
                .Index(t => t.ID_Producto);
            
            CreateTable(
                "dbo.TiposSalidas",
                c => new
                    {
                        ID_TipoSalida = c.Int(nullable: false, identity: true),
                        Codigo_TipoSalida = c.String(nullable: false, maxLength: 10),
                        Descripcion_TipoSalida = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_TipoSalida)
                .Index(t => t.Codigo_TipoSalida, unique: true);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        ID_Proveedor = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(nullable: false, maxLength: 255),
                        CodigoTributario = c.String(nullable: false, maxLength: 14),
                    })
                .PrimaryKey(t => t.ID_Proveedor)
                .Index(t => t.RazonSocial, unique: true, name: "RazonSocial")
                .Index(t => t.CodigoTributario, unique: true, name: "CodigoTributario");
            
            CreateTable(
                "dbo.TiposEntradas",
                c => new
                    {
                        ID_TipoEntrada = c.Int(nullable: false, identity: true),
                        Codigo_TipoEntrada = c.String(nullable: false, maxLength: 10),
                        Descripcion_TipoEntrada = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_TipoEntrada)
                .Index(t => t.Codigo_TipoEntrada, unique: true);
            
            CreateTable(
                "dbo.MarcasProductos",
                c => new
                    {
                        ID_MarcaProducto = c.Int(nullable: false, identity: true),
                        Codigo_MarcaProducto = c.String(nullable: false, maxLength: 10),
                        Nombre_MarcaProducto = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID_MarcaProducto)
                .Index(t => t.Codigo_MarcaProducto, unique: true)
                .Index(t => t.Nombre_MarcaProducto, unique: true);
            
            CreateTable(
                "dbo.UnidadesMedidas",
                c => new
                    {
                        ID_UnidadMedida = c.Int(nullable: false, identity: true),
                        Abreviatura_UnidadMedida = c.String(nullable: false, maxLength: 5),
                        Descripcion_UnidadMedida = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID_UnidadMedida)
                .Index(t => t.Abreviatura_UnidadMedida, unique: true)
                .Index(t => t.Descripcion_UnidadMedida, unique: true);
            
            CreateTable(
                "dbo.EmpresasTelefonicas",
                c => new
                    {
                        ID_EmpresaTelefonica = c.Int(nullable: false, identity: true),
                        Nombre_EmpresaTelefonica = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID_EmpresaTelefonica)
                .Index(t => t.Nombre_EmpresaTelefonica, unique: true);
            
            CreateTable(
                "dbo.Tiendas",
                c => new
                    {
                        ID_Tienda = c.Int(nullable: false, identity: true),
                        Codigo_Tienda = c.String(nullable: false, maxLength: 10),
                        Nombre_Tienda = c.String(nullable: false, maxLength: 100),
                        Direccion_Tienda = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID_Tienda)
                .Index(t => t.Codigo_Tienda, unique: true)
                .Index(t => t.Nombre_Tienda, unique: true);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID_DatoUsuario = c.Int(nullable: false),
                        ID_Cliente = c.Int(nullable: false, identity: true),
                        NO_Cliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_DatoUsuario)
                .ForeignKey("dbo.DatosUsuarios", t => t.ID_DatoUsuario)
                .Index(t => t.ID_DatoUsuario)
                .Index(t => t.NO_Cliente, unique: true);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        ID_DatoUsuario = c.Int(nullable: false),
                        Tiendas_ID_Tienda = c.Int(),
                        ID_Empleado = c.Int(nullable: false, identity: true),
                        NO_Empleado = c.Int(nullable: false),
                        Codigo_Empleado = c.String(nullable: false, maxLength: 20),
                        NO_INSS = c.String(nullable: false),
                        Estado_Empleado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_DatoUsuario)
                .ForeignKey("dbo.DatosUsuarios", t => t.ID_DatoUsuario)
                .ForeignKey("dbo.Tiendas", t => t.Tiendas_ID_Tienda)
                .Index(t => t.ID_DatoUsuario)
                .Index(t => t.Tiendas_ID_Tienda)
                .Index(t => t.NO_Empleado, unique: true)
                .Index(t => t.Codigo_Empleado, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "Tiendas_ID_Tienda", "dbo.Tiendas");
            DropForeignKey("dbo.Empleados", "ID_DatoUsuario", "dbo.DatosUsuarios");
            DropForeignKey("dbo.Clientes", "ID_DatoUsuario", "dbo.DatosUsuarios");
            DropForeignKey("dbo.Salidas", "Tiendas_ID_Tienda", "dbo.Tiendas");
            DropForeignKey("dbo.NumerosTelefonicos", "Tiendas_ID_Tienda", "dbo.Tiendas");
            DropForeignKey("dbo.Entradas", "Tiendas_ID_Tienda", "dbo.Tiendas");
            DropForeignKey("dbo.NumerosTelefonicos", "ID_EmpresaTelefonica", "dbo.EmpresasTelefonicas");
            DropForeignKey("dbo.Productos", "ID_UnidadMedida", "dbo.UnidadesMedidas");
            DropForeignKey("dbo.Productos", "ID_MarcaProducto", "dbo.MarcasProductos");
            DropForeignKey("dbo.DetalleEntradas", "ID_Producto", "dbo.Productos");
            DropForeignKey("dbo.Entradas", "ID_TipoEntrada", "dbo.TiposEntradas");
            DropForeignKey("dbo.Entradas", "ID_Proveedor", "dbo.Proveedores");
            DropForeignKey("dbo.Salidas", "ID_TipoSalida", "dbo.TiposSalidas");
            DropForeignKey("dbo.Salidas", "Empleados_ID_DatoUsuario", "dbo.Empleados");
            DropForeignKey("dbo.DetalleSalidas", "ID_Salida", "dbo.Salidas");
            DropForeignKey("dbo.DetalleSalidas", "ID_Producto", "dbo.Productos");
            DropForeignKey("dbo.Salidas", "Clientes_ID_DatoUsuario", "dbo.Clientes");
            DropForeignKey("dbo.DatosUsuarios", "ID_NumTelefono", "dbo.NumerosTelefonicos");
            DropForeignKey("dbo.DatosUsuarios", "ID_Genero", "dbo.Generos");
            DropForeignKey("dbo.DocumentoIdentidad", "DatosUsuarios_ID_DatoUsuario", "dbo.DatosUsuarios");
            DropForeignKey("dbo.Entradas", "Empleado_ID_DatoUsuario", "dbo.Empleados");
            DropForeignKey("dbo.TipoDocumentoIdentidad", "ID_Pais", "dbo.Paises");
            DropForeignKey("dbo.DocumentoIdentidad", "ID_TipoDocumentoIdentidad", "dbo.TipoDocumentoIdentidad");
            DropForeignKey("dbo.DetalleEntradas", "ID_Entrada", "dbo.Entradas");
            DropForeignKey("dbo.Productos", "ID_CategoriaProducto", "dbo.CategoriasProductos");
            DropIndex("dbo.Empleados", new[] { "Codigo_Empleado" });
            DropIndex("dbo.Empleados", new[] { "NO_Empleado" });
            DropIndex("dbo.Empleados", new[] { "Tiendas_ID_Tienda" });
            DropIndex("dbo.Empleados", new[] { "ID_DatoUsuario" });
            DropIndex("dbo.Clientes", new[] { "NO_Cliente" });
            DropIndex("dbo.Clientes", new[] { "ID_DatoUsuario" });
            DropIndex("dbo.Tiendas", new[] { "Nombre_Tienda" });
            DropIndex("dbo.Tiendas", new[] { "Codigo_Tienda" });
            DropIndex("dbo.EmpresasTelefonicas", new[] { "Nombre_EmpresaTelefonica" });
            DropIndex("dbo.UnidadesMedidas", new[] { "Descripcion_UnidadMedida" });
            DropIndex("dbo.UnidadesMedidas", new[] { "Abreviatura_UnidadMedida" });
            DropIndex("dbo.MarcasProductos", new[] { "Nombre_MarcaProducto" });
            DropIndex("dbo.MarcasProductos", new[] { "Codigo_MarcaProducto" });
            DropIndex("dbo.TiposEntradas", new[] { "Codigo_TipoEntrada" });
            DropIndex("dbo.Proveedores", "CodigoTributario");
            DropIndex("dbo.Proveedores", "RazonSocial");
            DropIndex("dbo.TiposSalidas", new[] { "Codigo_TipoSalida" });
            DropIndex("dbo.DetalleSalidas", new[] { "ID_Producto" });
            DropIndex("dbo.DetalleSalidas", new[] { "ID_Salida" });
            DropIndex("dbo.Salidas", new[] { "Tiendas_ID_Tienda" });
            DropIndex("dbo.Salidas", new[] { "Empleados_ID_DatoUsuario" });
            DropIndex("dbo.Salidas", new[] { "Clientes_ID_DatoUsuario" });
            DropIndex("dbo.Salidas", new[] { "ID_TipoSalida" });
            DropIndex("dbo.NumerosTelefonicos", new[] { "Tiendas_ID_Tienda" });
            DropIndex("dbo.NumerosTelefonicos", new[] { "ID_EmpresaTelefonica" });
            DropIndex("dbo.Paises", new[] { "Nombre_Pais" });
            DropIndex("dbo.Paises", new[] { "Codigo_Pais" });
            DropIndex("dbo.TipoDocumentoIdentidad", new[] { "ID_Pais" });
            DropIndex("dbo.TipoDocumentoIdentidad", new[] { "Codigo_TipoDocumento" });
            DropIndex("dbo.DocumentoIdentidad", new[] { "DatosUsuarios_ID_DatoUsuario" });
            DropIndex("dbo.DocumentoIdentidad", new[] { "ID_TipoDocumentoIdentidad" });
            DropIndex("dbo.DocumentoIdentidad", new[] { "Codigo_DocumentoIdentidad" });
            DropIndex("dbo.DatosUsuarios", new[] { "ID_Genero" });
            DropIndex("dbo.DatosUsuarios", new[] { "ID_NumTelefono" });
            DropIndex("dbo.Entradas", new[] { "Tiendas_ID_Tienda" });
            DropIndex("dbo.Entradas", new[] { "Empleado_ID_DatoUsuario" });
            DropIndex("dbo.Entradas", new[] { "ID_TipoEntrada" });
            DropIndex("dbo.Entradas", new[] { "ID_Proveedor" });
            DropIndex("dbo.Entradas", new[] { "CodigoEntrada" });
            DropIndex("dbo.DetalleEntradas", new[] { "ID_Producto" });
            DropIndex("dbo.DetalleEntradas", new[] { "ID_Entrada" });
            DropIndex("dbo.Productos", new[] { "ID_UnidadMedida" });
            DropIndex("dbo.Productos", new[] { "ID_MarcaProducto" });
            DropIndex("dbo.Productos", new[] { "ID_CategoriaProducto" });
            DropIndex("dbo.Productos", new[] { "Codigo_Producto" });
            DropIndex("dbo.CategoriasProductos", new[] { "Nombre_CategoriaProducto" });
            DropIndex("dbo.CategoriasProductos", new[] { "Codigo_CategoriaProducto" });
            DropTable("dbo.Empleados");
            DropTable("dbo.Clientes");
            DropTable("dbo.Tiendas");
            DropTable("dbo.EmpresasTelefonicas");
            DropTable("dbo.UnidadesMedidas");
            DropTable("dbo.MarcasProductos");
            DropTable("dbo.TiposEntradas");
            DropTable("dbo.Proveedores");
            DropTable("dbo.TiposSalidas");
            DropTable("dbo.DetalleSalidas");
            DropTable("dbo.Salidas");
            DropTable("dbo.NumerosTelefonicos");
            DropTable("dbo.Generos");
            DropTable("dbo.Paises");
            DropTable("dbo.TipoDocumentoIdentidad");
            DropTable("dbo.DocumentoIdentidad");
            DropTable("dbo.DatosUsuarios");
            DropTable("dbo.Entradas");
            DropTable("dbo.DetalleEntradas");
            DropTable("dbo.Productos");
            DropTable("dbo.CategoriasProductos");
        }
    }
}
