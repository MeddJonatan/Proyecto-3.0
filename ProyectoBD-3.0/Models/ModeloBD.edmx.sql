
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/04/2024 20:50:18
-- Generated from EDMX file: C:\Users\JJona\Documentos\Universidad\2024\I-Semestre\ProgramaciónBasesdeDatos\ProyectoSemestre\Proyecto-3.0\ProyectoBD-3.0\Models\ModeloBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_PF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GeneroSet'
CREATE TABLE [dbo].[GeneroSet] (
    [ID_Genero] bigint IDENTITY(1,1) NOT NULL,
    [NO_Genero] bigint  NOT NULL,
    [Descripcion_Genero] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PaisesSet'
CREATE TABLE [dbo].[PaisesSet] (
    [ID_Pais] bigint IDENTITY(1,1) NOT NULL,
    [NO_Pais] bigint  NOT NULL,
    [Codigo_Pais] nvarchar(max)  NOT NULL,
    [Nombre_Pais] nvarchar(max)  NOT NULL,
    [Nacionalidad] nvarchar(max)  NOT NULL,
    [Sufijo_Pais] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TiendasSet'
CREATE TABLE [dbo].[TiendasSet] (
    [ID_Tienda] bigint IDENTITY(1,1) NOT NULL,
    [NO_Tienda] bigint  NOT NULL,
    [Codigo_Tienda] nvarchar(max)  NOT NULL,
    [Nombre_Tienda] nvarchar(max)  NOT NULL,
    [Direccion_Tienda] nvarchar(max)  NOT NULL,
    [ID_Ciudad] bigint  NOT NULL,
    [ID_NumTelefono] bigint  NOT NULL,
    [ID_Entrada] bigint  NOT NULL,
    [ID_Empleado] bigint  NOT NULL,
    [ID_Salida] bigint  NOT NULL
);
GO

-- Creating table 'NumerosTelefonicosSet'
CREATE TABLE [dbo].[NumerosTelefonicosSet] (
    [ID_NumTelefono] bigint IDENTITY(1,1) NOT NULL,
    [NumeroTelefono] nvarchar(max)  NOT NULL,
    [ID_EmpresaTelefonica] bigint  NOT NULL,
    [Tiendas_ID_Tienda] bigint  NOT NULL,
    [EmpresaTelefonica_ID_EmpresaTelefonica] bigint  NOT NULL,
    [DatosUsuarios_ID_DatoUsuario] bigint  NOT NULL
);
GO

-- Creating table 'EmpresasTelefonicasSet'
CREATE TABLE [dbo].[EmpresasTelefonicasSet] (
    [ID_EmpresaTelefonica] bigint IDENTITY(1,1) NOT NULL,
    [NO_EmpresaTelefonica] bigint  NOT NULL,
    [Nombre_EmpresaTelefonica] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DatosUsuariosSet'
CREATE TABLE [dbo].[DatosUsuariosSet] (
    [ID_DatoUsuario] bigint IDENTITY(1,1) NOT NULL,
    [PrimerNombre] nvarchar(max)  NOT NULL,
    [SegundoNombre] nvarchar(max)  NOT NULL,
    [PrimerApellido] nvarchar(max)  NOT NULL,
    [SegundoApellido] nvarchar(max)  NOT NULL,
    [Edad] smallint  NOT NULL,
    [ID_NumTelefono] bigint  NOT NULL,
    [ID_Genero] bigint  NOT NULL,
    [ID_DocumentoIdentidad] bigint  NOT NULL,
    [Genero_ID_Genero] bigint  NOT NULL
);
GO

-- Creating table 'Tipo_DocumentoIdentidadSet'
CREATE TABLE [dbo].[Tipo_DocumentoIdentidadSet] (
    [ID_TipoDocumentoIdentidad] bigint IDENTITY(1,1) NOT NULL,
    [NO_TipoDocumentoIdentidad] nvarchar(max)  NOT NULL,
    [Descripcion_TipoDocumentoIdentidad] nvarchar(max)  NOT NULL,
    [ID_Pais] bigint  NOT NULL,
    [Paises_ID_Pais] bigint  NOT NULL
);
GO

-- Creating table 'DocumentoIdentidadSet'
CREATE TABLE [dbo].[DocumentoIdentidadSet] (
    [ID_DocumentoIdentidad] bigint IDENTITY(1,1) NOT NULL,
    [Codigo_DocumentoIdentidad] nvarchar(max)  NOT NULL,
    [FechaEmision_DocumentoIdentidad] datetime  NOT NULL,
    [FechaFinalizacion_DocumentoIdentidad] datetime  NOT NULL,
    [ID_TipoDocumentoIdentidad] bigint  NOT NULL,
    [DatosUsuarios_ID_DatoUsuario] bigint  NOT NULL,
    [Tipo_DocumentoIdentidad_ID_TipoDocumentoIdentidad] bigint  NOT NULL
);
GO

-- Creating table 'EntradasSet'
CREATE TABLE [dbo].[EntradasSet] (
    [ID_Entrada] bigint IDENTITY(1,1) NOT NULL,
    [NO_Entrada] bigint  NOT NULL,
    [CodigoEntrada] nvarchar(max)  NOT NULL,
    [FechaEntrada] datetime  NOT NULL,
    [ID_Proveedor] bigint  NOT NULL,
    [ID_TipoEntrada] bigint  NOT NULL,
    [ID_PagoEntrada] bigint  NOT NULL,
    [ID_Empleado] bigint  NOT NULL,
    [Empleados_ID_DatoUsuario] bigint  NOT NULL,
    [Tiendas_ID_Tienda] bigint  NOT NULL,
    [Proveedores_ID_Proveedor] bigint  NOT NULL,
    [TipoEntrada_ID_TipoEntrada] bigint  NOT NULL
);
GO

-- Creating table 'Detalle_EntradasSet'
CREATE TABLE [dbo].[Detalle_EntradasSet] (
    [ID_DetalleEntrada] bigint IDENTITY(1,1) NOT NULL,
    [Cantidad_DetalleEntrada] bigint  NOT NULL,
    [Precio_DetalleEntrada] bigint  NOT NULL,
    [ID_Entrada] bigint  NOT NULL,
    [ID_Producto] bigint  NOT NULL,
    [Entradas_ID_Entrada] bigint  NOT NULL,
    [Productos_ID_Producto] bigint  NOT NULL
);
GO

-- Creating table 'ProveedoresSet'
CREATE TABLE [dbo].[ProveedoresSet] (
    [ID_Proveedor] bigint IDENTITY(1,1) NOT NULL,
    [RazonSocial] nvarchar(max)  NOT NULL,
    [CodigoTributario] nvarchar(max)  NOT NULL,
    [ID_NumTelefono] bigint  NOT NULL
);
GO

-- Creating table 'ProductosSet'
CREATE TABLE [dbo].[ProductosSet] (
    [ID_Producto] bigint IDENTITY(1,1) NOT NULL,
    [Codigo_Producto] nvarchar(max)  NOT NULL,
    [Nombre_Producto] nvarchar(max)  NOT NULL,
    [ID_MarcaProducto] bigint  NOT NULL,
    [ID_UnidadMedida] bigint  NOT NULL,
    [ID_SubCategoriaProducto] bigint  NOT NULL,
    [UnidadesMedidas_ID_UnidadMedida] bigint  NOT NULL,
    [MarcasProductos_ID_MarcaProducto] bigint  NOT NULL,
    [SubCategoriasProductos_ID_SubCategoriaProducto] bigint  NOT NULL
);
GO

-- Creating table 'UnidadesMedidasSet'
CREATE TABLE [dbo].[UnidadesMedidasSet] (
    [ID_UnidadMedida] bigint IDENTITY(1,1) NOT NULL,
    [NO_UnidadMedidad] bigint  NOT NULL,
    [Codigo_UnidadMedida] nvarchar(max)  NOT NULL,
    [Abreviatura_UnidadMedida] nvarchar(max)  NOT NULL,
    [Descripcion_UnidadMedida] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TipoEntradaSet'
CREATE TABLE [dbo].[TipoEntradaSet] (
    [ID_TipoEntrada] bigint IDENTITY(1,1) NOT NULL,
    [NO_TipoEntrada] bigint  NOT NULL,
    [Codigo_TipoEntrada] nvarchar(max)  NOT NULL,
    [Descripcion_TipoEntrada] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoriasProductosSet'
CREATE TABLE [dbo].[CategoriasProductosSet] (
    [ID_CategoriaProducto] bigint IDENTITY(1,1) NOT NULL,
    [NO_CategoriaProducto] bigint  NOT NULL,
    [Codigo_CategoriaProducto] nvarchar(max)  NOT NULL,
    [Descripcion_CategoriaProducto] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SubCategoriasProductosSet'
CREATE TABLE [dbo].[SubCategoriasProductosSet] (
    [ID_SubCategoriaProducto] bigint IDENTITY(1,1) NOT NULL,
    [NO_SubCategoriaProducto] bigint  NOT NULL,
    [Codigo_SubCategoriaProducto] nvarchar(max)  NOT NULL,
    [Descripcion_SubCategoriaProducto] nvarchar(max)  NOT NULL,
    [ID_CategoriaProducto] bigint  NOT NULL,
    [CategoriasProductos_ID_CategoriaProducto] bigint  NOT NULL
);
GO

-- Creating table 'MarcasProductosSet'
CREATE TABLE [dbo].[MarcasProductosSet] (
    [ID_MarcaProducto] bigint IDENTITY(1,1) NOT NULL,
    [NO_MarcaProducto] bigint  NOT NULL,
    [Codigo_MarcaProducto] nvarchar(max)  NOT NULL,
    [Nombre_MarcaProducto] nvarchar(max)  NOT NULL,
    [Web_MarcaProducto] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SalidasSet'
CREATE TABLE [dbo].[SalidasSet] (
    [ID_Salida] bigint IDENTITY(1,1) NOT NULL,
    [NO_Salida] bigint  NOT NULL,
    [CodigoSalida] nvarchar(max)  NOT NULL,
    [FechaSalida] datetime  NOT NULL,
    [ID_TipoSalida] bigint  NOT NULL,
    [ID_Empleado] bigint  NOT NULL,
    [ID_Cliente] bigint  NOT NULL,
    [Empleados_ID_DatoUsuario] bigint  NOT NULL,
    [Clientes_ID_DatoUsuario] bigint  NOT NULL,
    [TipoSalida_ID_TipoSalida] bigint  NOT NULL,
    [Tiendas_ID_Tienda] bigint  NOT NULL
);
GO

-- Creating table 'TipoSalidaSet'
CREATE TABLE [dbo].[TipoSalidaSet] (
    [ID_TipoSalida] bigint IDENTITY(1,1) NOT NULL,
    [NO_TipoSalida] bigint  NOT NULL,
    [Codigo_TipoSalida] nvarchar(max)  NOT NULL,
    [Descripcion_TipoSalida] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Detalle_SalidasSet'
CREATE TABLE [dbo].[Detalle_SalidasSet] (
    [ID_DetalleSalida] bigint IDENTITY(1,1) NOT NULL,
    [Cantidad_DetalleSalida] bigint  NOT NULL,
    [Precio_DetalleSalida] bigint  NOT NULL,
    [ID_Salida] bigint  NOT NULL,
    [ID_Producto] bigint  NOT NULL,
    [Salidas_ID_Salida] bigint  NOT NULL,
    [Productos_ID_Producto] bigint  NOT NULL
);
GO

-- Creating table 'DatosUsuariosSet_Empleados'
CREATE TABLE [dbo].[DatosUsuariosSet_Empleados] (
    [ID_Empleado] bigint IDENTITY(1,1) NOT NULL,
    [NO_Empleado] bigint  NOT NULL,
    [Codigo_Empleado] nvarchar(max)  NOT NULL,
    [NO_INSS] bigint  NOT NULL,
    [Estado_Empleado] bit  NOT NULL,
    [ID_DatoUsuario] bigint  NOT NULL,
    [Tiendas_ID_Tienda] bigint  NOT NULL
);
GO

-- Creating table 'DatosUsuariosSet_Clientes'
CREATE TABLE [dbo].[DatosUsuariosSet_Clientes] (
    [ID_Cliente] bigint IDENTITY(1,1) NOT NULL,
    [NO_Cliente] bigint  NOT NULL,
    [ID_DatoUsuario] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID_Genero] in table 'GeneroSet'
ALTER TABLE [dbo].[GeneroSet]
ADD CONSTRAINT [PK_GeneroSet]
    PRIMARY KEY CLUSTERED ([ID_Genero] ASC);
GO

-- Creating primary key on [ID_Pais] in table 'PaisesSet'
ALTER TABLE [dbo].[PaisesSet]
ADD CONSTRAINT [PK_PaisesSet]
    PRIMARY KEY CLUSTERED ([ID_Pais] ASC);
GO

-- Creating primary key on [ID_Tienda] in table 'TiendasSet'
ALTER TABLE [dbo].[TiendasSet]
ADD CONSTRAINT [PK_TiendasSet]
    PRIMARY KEY CLUSTERED ([ID_Tienda] ASC);
GO

-- Creating primary key on [ID_NumTelefono] in table 'NumerosTelefonicosSet'
ALTER TABLE [dbo].[NumerosTelefonicosSet]
ADD CONSTRAINT [PK_NumerosTelefonicosSet]
    PRIMARY KEY CLUSTERED ([ID_NumTelefono] ASC);
GO

-- Creating primary key on [ID_EmpresaTelefonica] in table 'EmpresasTelefonicasSet'
ALTER TABLE [dbo].[EmpresasTelefonicasSet]
ADD CONSTRAINT [PK_EmpresasTelefonicasSet]
    PRIMARY KEY CLUSTERED ([ID_EmpresaTelefonica] ASC);
GO

-- Creating primary key on [ID_DatoUsuario] in table 'DatosUsuariosSet'
ALTER TABLE [dbo].[DatosUsuariosSet]
ADD CONSTRAINT [PK_DatosUsuariosSet]
    PRIMARY KEY CLUSTERED ([ID_DatoUsuario] ASC);
GO

-- Creating primary key on [ID_TipoDocumentoIdentidad] in table 'Tipo_DocumentoIdentidadSet'
ALTER TABLE [dbo].[Tipo_DocumentoIdentidadSet]
ADD CONSTRAINT [PK_Tipo_DocumentoIdentidadSet]
    PRIMARY KEY CLUSTERED ([ID_TipoDocumentoIdentidad] ASC);
GO

-- Creating primary key on [ID_DocumentoIdentidad] in table 'DocumentoIdentidadSet'
ALTER TABLE [dbo].[DocumentoIdentidadSet]
ADD CONSTRAINT [PK_DocumentoIdentidadSet]
    PRIMARY KEY CLUSTERED ([ID_DocumentoIdentidad] ASC);
GO

-- Creating primary key on [ID_Entrada] in table 'EntradasSet'
ALTER TABLE [dbo].[EntradasSet]
ADD CONSTRAINT [PK_EntradasSet]
    PRIMARY KEY CLUSTERED ([ID_Entrada] ASC);
GO

-- Creating primary key on [ID_DetalleEntrada] in table 'Detalle_EntradasSet'
ALTER TABLE [dbo].[Detalle_EntradasSet]
ADD CONSTRAINT [PK_Detalle_EntradasSet]
    PRIMARY KEY CLUSTERED ([ID_DetalleEntrada] ASC);
GO

-- Creating primary key on [ID_Proveedor] in table 'ProveedoresSet'
ALTER TABLE [dbo].[ProveedoresSet]
ADD CONSTRAINT [PK_ProveedoresSet]
    PRIMARY KEY CLUSTERED ([ID_Proveedor] ASC);
GO

-- Creating primary key on [ID_Producto] in table 'ProductosSet'
ALTER TABLE [dbo].[ProductosSet]
ADD CONSTRAINT [PK_ProductosSet]
    PRIMARY KEY CLUSTERED ([ID_Producto] ASC);
GO

-- Creating primary key on [ID_UnidadMedida] in table 'UnidadesMedidasSet'
ALTER TABLE [dbo].[UnidadesMedidasSet]
ADD CONSTRAINT [PK_UnidadesMedidasSet]
    PRIMARY KEY CLUSTERED ([ID_UnidadMedida] ASC);
GO

-- Creating primary key on [ID_TipoEntrada] in table 'TipoEntradaSet'
ALTER TABLE [dbo].[TipoEntradaSet]
ADD CONSTRAINT [PK_TipoEntradaSet]
    PRIMARY KEY CLUSTERED ([ID_TipoEntrada] ASC);
GO

-- Creating primary key on [ID_CategoriaProducto] in table 'CategoriasProductosSet'
ALTER TABLE [dbo].[CategoriasProductosSet]
ADD CONSTRAINT [PK_CategoriasProductosSet]
    PRIMARY KEY CLUSTERED ([ID_CategoriaProducto] ASC);
GO

-- Creating primary key on [ID_SubCategoriaProducto] in table 'SubCategoriasProductosSet'
ALTER TABLE [dbo].[SubCategoriasProductosSet]
ADD CONSTRAINT [PK_SubCategoriasProductosSet]
    PRIMARY KEY CLUSTERED ([ID_SubCategoriaProducto] ASC);
GO

-- Creating primary key on [ID_MarcaProducto] in table 'MarcasProductosSet'
ALTER TABLE [dbo].[MarcasProductosSet]
ADD CONSTRAINT [PK_MarcasProductosSet]
    PRIMARY KEY CLUSTERED ([ID_MarcaProducto] ASC);
GO

-- Creating primary key on [ID_Salida] in table 'SalidasSet'
ALTER TABLE [dbo].[SalidasSet]
ADD CONSTRAINT [PK_SalidasSet]
    PRIMARY KEY CLUSTERED ([ID_Salida] ASC);
GO

-- Creating primary key on [ID_TipoSalida] in table 'TipoSalidaSet'
ALTER TABLE [dbo].[TipoSalidaSet]
ADD CONSTRAINT [PK_TipoSalidaSet]
    PRIMARY KEY CLUSTERED ([ID_TipoSalida] ASC);
GO

-- Creating primary key on [ID_DetalleSalida] in table 'Detalle_SalidasSet'
ALTER TABLE [dbo].[Detalle_SalidasSet]
ADD CONSTRAINT [PK_Detalle_SalidasSet]
    PRIMARY KEY CLUSTERED ([ID_DetalleSalida] ASC);
GO

-- Creating primary key on [ID_DatoUsuario] in table 'DatosUsuariosSet_Empleados'
ALTER TABLE [dbo].[DatosUsuariosSet_Empleados]
ADD CONSTRAINT [PK_DatosUsuariosSet_Empleados]
    PRIMARY KEY CLUSTERED ([ID_DatoUsuario] ASC);
GO

-- Creating primary key on [ID_DatoUsuario] in table 'DatosUsuariosSet_Clientes'
ALTER TABLE [dbo].[DatosUsuariosSet_Clientes]
ADD CONSTRAINT [PK_DatosUsuariosSet_Clientes]
    PRIMARY KEY CLUSTERED ([ID_DatoUsuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Empleados_ID_DatoUsuario] in table 'EntradasSet'
ALTER TABLE [dbo].[EntradasSet]
ADD CONSTRAINT [FK_EmpleadosEntradas]
    FOREIGN KEY ([Empleados_ID_DatoUsuario])
    REFERENCES [dbo].[DatosUsuariosSet_Empleados]
        ([ID_DatoUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadosEntradas'
CREATE INDEX [IX_FK_EmpleadosEntradas]
ON [dbo].[EntradasSet]
    ([Empleados_ID_DatoUsuario]);
GO

-- Creating foreign key on [Tiendas_ID_Tienda] in table 'DatosUsuariosSet_Empleados'
ALTER TABLE [dbo].[DatosUsuariosSet_Empleados]
ADD CONSTRAINT [FK_TiendasEmpleados]
    FOREIGN KEY ([Tiendas_ID_Tienda])
    REFERENCES [dbo].[TiendasSet]
        ([ID_Tienda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TiendasEmpleados'
CREATE INDEX [IX_FK_TiendasEmpleados]
ON [dbo].[DatosUsuariosSet_Empleados]
    ([Tiendas_ID_Tienda]);
GO

-- Creating foreign key on [Empleados_ID_DatoUsuario] in table 'SalidasSet'
ALTER TABLE [dbo].[SalidasSet]
ADD CONSTRAINT [FK_EmpleadosSalidas]
    FOREIGN KEY ([Empleados_ID_DatoUsuario])
    REFERENCES [dbo].[DatosUsuariosSet_Empleados]
        ([ID_DatoUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadosSalidas'
CREATE INDEX [IX_FK_EmpleadosSalidas]
ON [dbo].[SalidasSet]
    ([Empleados_ID_DatoUsuario]);
GO

-- Creating foreign key on [Genero_ID_Genero] in table 'DatosUsuariosSet'
ALTER TABLE [dbo].[DatosUsuariosSet]
ADD CONSTRAINT [FK_GeneroDatosUsuarios]
    FOREIGN KEY ([Genero_ID_Genero])
    REFERENCES [dbo].[GeneroSet]
        ([ID_Genero])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GeneroDatosUsuarios'
CREATE INDEX [IX_FK_GeneroDatosUsuarios]
ON [dbo].[DatosUsuariosSet]
    ([Genero_ID_Genero]);
GO

-- Creating foreign key on [Paises_ID_Pais] in table 'Tipo_DocumentoIdentidadSet'
ALTER TABLE [dbo].[Tipo_DocumentoIdentidadSet]
ADD CONSTRAINT [FK_PaisesTipo_DocumentoIdentidad]
    FOREIGN KEY ([Paises_ID_Pais])
    REFERENCES [dbo].[PaisesSet]
        ([ID_Pais])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaisesTipo_DocumentoIdentidad'
CREATE INDEX [IX_FK_PaisesTipo_DocumentoIdentidad]
ON [dbo].[Tipo_DocumentoIdentidadSet]
    ([Paises_ID_Pais]);
GO

-- Creating foreign key on [Tiendas_ID_Tienda] in table 'NumerosTelefonicosSet'
ALTER TABLE [dbo].[NumerosTelefonicosSet]
ADD CONSTRAINT [FK_TiendasNumerosTelefonicos]
    FOREIGN KEY ([Tiendas_ID_Tienda])
    REFERENCES [dbo].[TiendasSet]
        ([ID_Tienda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TiendasNumerosTelefonicos'
CREATE INDEX [IX_FK_TiendasNumerosTelefonicos]
ON [dbo].[NumerosTelefonicosSet]
    ([Tiendas_ID_Tienda]);
GO

-- Creating foreign key on [Tiendas_ID_Tienda] in table 'EntradasSet'
ALTER TABLE [dbo].[EntradasSet]
ADD CONSTRAINT [FK_TiendasEntradas]
    FOREIGN KEY ([Tiendas_ID_Tienda])
    REFERENCES [dbo].[TiendasSet]
        ([ID_Tienda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TiendasEntradas'
CREATE INDEX [IX_FK_TiendasEntradas]
ON [dbo].[EntradasSet]
    ([Tiendas_ID_Tienda]);
GO

-- Creating foreign key on [EmpresaTelefonica_ID_EmpresaTelefonica] in table 'NumerosTelefonicosSet'
ALTER TABLE [dbo].[NumerosTelefonicosSet]
ADD CONSTRAINT [FK_EmpresaTelefonicaNumerosTelefonicos]
    FOREIGN KEY ([EmpresaTelefonica_ID_EmpresaTelefonica])
    REFERENCES [dbo].[EmpresasTelefonicasSet]
        ([ID_EmpresaTelefonica])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaTelefonicaNumerosTelefonicos'
CREATE INDEX [IX_FK_EmpresaTelefonicaNumerosTelefonicos]
ON [dbo].[NumerosTelefonicosSet]
    ([EmpresaTelefonica_ID_EmpresaTelefonica]);
GO

-- Creating foreign key on [DatosUsuarios_ID_DatoUsuario] in table 'DocumentoIdentidadSet'
ALTER TABLE [dbo].[DocumentoIdentidadSet]
ADD CONSTRAINT [FK_DocumentoIdentidadDatosUsuarios]
    FOREIGN KEY ([DatosUsuarios_ID_DatoUsuario])
    REFERENCES [dbo].[DatosUsuariosSet]
        ([ID_DatoUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentoIdentidadDatosUsuarios'
CREATE INDEX [IX_FK_DocumentoIdentidadDatosUsuarios]
ON [dbo].[DocumentoIdentidadSet]
    ([DatosUsuarios_ID_DatoUsuario]);
GO

-- Creating foreign key on [DatosUsuarios_ID_DatoUsuario] in table 'NumerosTelefonicosSet'
ALTER TABLE [dbo].[NumerosTelefonicosSet]
ADD CONSTRAINT [FK_NumerosTelefonicosDatosUsuarios]
    FOREIGN KEY ([DatosUsuarios_ID_DatoUsuario])
    REFERENCES [dbo].[DatosUsuariosSet]
        ([ID_DatoUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NumerosTelefonicosDatosUsuarios'
CREATE INDEX [IX_FK_NumerosTelefonicosDatosUsuarios]
ON [dbo].[NumerosTelefonicosSet]
    ([DatosUsuarios_ID_DatoUsuario]);
GO

-- Creating foreign key on [Clientes_ID_DatoUsuario] in table 'SalidasSet'
ALTER TABLE [dbo].[SalidasSet]
ADD CONSTRAINT [FK_ClientesSalidas]
    FOREIGN KEY ([Clientes_ID_DatoUsuario])
    REFERENCES [dbo].[DatosUsuariosSet_Clientes]
        ([ID_DatoUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientesSalidas'
CREATE INDEX [IX_FK_ClientesSalidas]
ON [dbo].[SalidasSet]
    ([Clientes_ID_DatoUsuario]);
GO

-- Creating foreign key on [Tipo_DocumentoIdentidad_ID_TipoDocumentoIdentidad] in table 'DocumentoIdentidadSet'
ALTER TABLE [dbo].[DocumentoIdentidadSet]
ADD CONSTRAINT [FK_Tipo_DocumentoIdentidadDocumentoIdentidad]
    FOREIGN KEY ([Tipo_DocumentoIdentidad_ID_TipoDocumentoIdentidad])
    REFERENCES [dbo].[Tipo_DocumentoIdentidadSet]
        ([ID_TipoDocumentoIdentidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tipo_DocumentoIdentidadDocumentoIdentidad'
CREATE INDEX [IX_FK_Tipo_DocumentoIdentidadDocumentoIdentidad]
ON [dbo].[DocumentoIdentidadSet]
    ([Tipo_DocumentoIdentidad_ID_TipoDocumentoIdentidad]);
GO

-- Creating foreign key on [Proveedores_ID_Proveedor] in table 'EntradasSet'
ALTER TABLE [dbo].[EntradasSet]
ADD CONSTRAINT [FK_ProveedoresEntradas]
    FOREIGN KEY ([Proveedores_ID_Proveedor])
    REFERENCES [dbo].[ProveedoresSet]
        ([ID_Proveedor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedoresEntradas'
CREATE INDEX [IX_FK_ProveedoresEntradas]
ON [dbo].[EntradasSet]
    ([Proveedores_ID_Proveedor]);
GO

-- Creating foreign key on [TipoEntrada_ID_TipoEntrada] in table 'EntradasSet'
ALTER TABLE [dbo].[EntradasSet]
ADD CONSTRAINT [FK_TipoEntradaEntradas]
    FOREIGN KEY ([TipoEntrada_ID_TipoEntrada])
    REFERENCES [dbo].[TipoEntradaSet]
        ([ID_TipoEntrada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoEntradaEntradas'
CREATE INDEX [IX_FK_TipoEntradaEntradas]
ON [dbo].[EntradasSet]
    ([TipoEntrada_ID_TipoEntrada]);
GO

-- Creating foreign key on [Entradas_ID_Entrada] in table 'Detalle_EntradasSet'
ALTER TABLE [dbo].[Detalle_EntradasSet]
ADD CONSTRAINT [FK_EntradasDetalle_Entrada]
    FOREIGN KEY ([Entradas_ID_Entrada])
    REFERENCES [dbo].[EntradasSet]
        ([ID_Entrada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntradasDetalle_Entrada'
CREATE INDEX [IX_FK_EntradasDetalle_Entrada]
ON [dbo].[Detalle_EntradasSet]
    ([Entradas_ID_Entrada]);
GO

-- Creating foreign key on [Productos_ID_Producto] in table 'Detalle_EntradasSet'
ALTER TABLE [dbo].[Detalle_EntradasSet]
ADD CONSTRAINT [FK_ProductosDetalle_Entrada]
    FOREIGN KEY ([Productos_ID_Producto])
    REFERENCES [dbo].[ProductosSet]
        ([ID_Producto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductosDetalle_Entrada'
CREATE INDEX [IX_FK_ProductosDetalle_Entrada]
ON [dbo].[Detalle_EntradasSet]
    ([Productos_ID_Producto]);
GO

-- Creating foreign key on [UnidadesMedidas_ID_UnidadMedida] in table 'ProductosSet'
ALTER TABLE [dbo].[ProductosSet]
ADD CONSTRAINT [FK_UnidadesMedidasProductos]
    FOREIGN KEY ([UnidadesMedidas_ID_UnidadMedida])
    REFERENCES [dbo].[UnidadesMedidasSet]
        ([ID_UnidadMedida])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UnidadesMedidasProductos'
CREATE INDEX [IX_FK_UnidadesMedidasProductos]
ON [dbo].[ProductosSet]
    ([UnidadesMedidas_ID_UnidadMedida]);
GO

-- Creating foreign key on [MarcasProductos_ID_MarcaProducto] in table 'ProductosSet'
ALTER TABLE [dbo].[ProductosSet]
ADD CONSTRAINT [FK_MarcasProductosProductos]
    FOREIGN KEY ([MarcasProductos_ID_MarcaProducto])
    REFERENCES [dbo].[MarcasProductosSet]
        ([ID_MarcaProducto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MarcasProductosProductos'
CREATE INDEX [IX_FK_MarcasProductosProductos]
ON [dbo].[ProductosSet]
    ([MarcasProductos_ID_MarcaProducto]);
GO

-- Creating foreign key on [SubCategoriasProductos_ID_SubCategoriaProducto] in table 'ProductosSet'
ALTER TABLE [dbo].[ProductosSet]
ADD CONSTRAINT [FK_SubCategoriasProductosProductos]
    FOREIGN KEY ([SubCategoriasProductos_ID_SubCategoriaProducto])
    REFERENCES [dbo].[SubCategoriasProductosSet]
        ([ID_SubCategoriaProducto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubCategoriasProductosProductos'
CREATE INDEX [IX_FK_SubCategoriasProductosProductos]
ON [dbo].[ProductosSet]
    ([SubCategoriasProductos_ID_SubCategoriaProducto]);
GO

-- Creating foreign key on [CategoriasProductos_ID_CategoriaProducto] in table 'SubCategoriasProductosSet'
ALTER TABLE [dbo].[SubCategoriasProductosSet]
ADD CONSTRAINT [FK_CategoriasProductosSubCategoriasProductos]
    FOREIGN KEY ([CategoriasProductos_ID_CategoriaProducto])
    REFERENCES [dbo].[CategoriasProductosSet]
        ([ID_CategoriaProducto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriasProductosSubCategoriasProductos'
CREATE INDEX [IX_FK_CategoriasProductosSubCategoriasProductos]
ON [dbo].[SubCategoriasProductosSet]
    ([CategoriasProductos_ID_CategoriaProducto]);
GO

-- Creating foreign key on [TipoSalida_ID_TipoSalida] in table 'SalidasSet'
ALTER TABLE [dbo].[SalidasSet]
ADD CONSTRAINT [FK_TipoSalidaSalidas]
    FOREIGN KEY ([TipoSalida_ID_TipoSalida])
    REFERENCES [dbo].[TipoSalidaSet]
        ([ID_TipoSalida])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoSalidaSalidas'
CREATE INDEX [IX_FK_TipoSalidaSalidas]
ON [dbo].[SalidasSet]
    ([TipoSalida_ID_TipoSalida]);
GO

-- Creating foreign key on [Salidas_ID_Salida] in table 'Detalle_SalidasSet'
ALTER TABLE [dbo].[Detalle_SalidasSet]
ADD CONSTRAINT [FK_SalidasDetalle_Salidas]
    FOREIGN KEY ([Salidas_ID_Salida])
    REFERENCES [dbo].[SalidasSet]
        ([ID_Salida])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalidasDetalle_Salidas'
CREATE INDEX [IX_FK_SalidasDetalle_Salidas]
ON [dbo].[Detalle_SalidasSet]
    ([Salidas_ID_Salida]);
GO

-- Creating foreign key on [Productos_ID_Producto] in table 'Detalle_SalidasSet'
ALTER TABLE [dbo].[Detalle_SalidasSet]
ADD CONSTRAINT [FK_ProductosDetalle_Salidas]
    FOREIGN KEY ([Productos_ID_Producto])
    REFERENCES [dbo].[ProductosSet]
        ([ID_Producto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductosDetalle_Salidas'
CREATE INDEX [IX_FK_ProductosDetalle_Salidas]
ON [dbo].[Detalle_SalidasSet]
    ([Productos_ID_Producto]);
GO

-- Creating foreign key on [Tiendas_ID_Tienda] in table 'SalidasSet'
ALTER TABLE [dbo].[SalidasSet]
ADD CONSTRAINT [FK_TiendasSalidas]
    FOREIGN KEY ([Tiendas_ID_Tienda])
    REFERENCES [dbo].[TiendasSet]
        ([ID_Tienda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TiendasSalidas'
CREATE INDEX [IX_FK_TiendasSalidas]
ON [dbo].[SalidasSet]
    ([Tiendas_ID_Tienda]);
GO

-- Creating foreign key on [ID_DatoUsuario] in table 'DatosUsuariosSet_Empleados'
ALTER TABLE [dbo].[DatosUsuariosSet_Empleados]
ADD CONSTRAINT [FK_Empleados_inherits_DatosUsuarios]
    FOREIGN KEY ([ID_DatoUsuario])
    REFERENCES [dbo].[DatosUsuariosSet]
        ([ID_DatoUsuario])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_DatoUsuario] in table 'DatosUsuariosSet_Clientes'
ALTER TABLE [dbo].[DatosUsuariosSet_Clientes]
ADD CONSTRAINT [FK_Clientes_inherits_DatosUsuarios]
    FOREIGN KEY ([ID_DatoUsuario])
    REFERENCES [dbo].[DatosUsuariosSet]
        ([ID_DatoUsuario])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------