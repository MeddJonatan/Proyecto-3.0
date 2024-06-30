using System;
using Proyecto.Model.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Proyecto.DAL.Context
{
    public class ProyectoContext : DbContext
    {
        public DbSet<Proyecto.Model.Clases.Generos> Generos { get; set; }
        public DbSet<Proyecto.Model.Clases.Paises> Paises { get; set; }
        public DbSet<Proyecto.Model.Clases.Tiendas> Tiendas { get; set; }
        public DbSet<Proyecto.Model.Clases.NumerosTelefonicos> NumerosTelefonicos { get; set; }
        public DbSet<Proyecto.Model.Clases.EmpresasTelefonicas> EmpresasTelefonicas { get; set; }
        public DbSet<Proyecto.Model.Clases.DatosUsuarios> DatosUsuarios { get; set; }
        public DbSet<Proyecto.Model.Clases.TipoDocumentoIdentidad> Tipo_DocumentoIdentidad { get; set; }
        public DbSet<Proyecto.Model.Clases.DocumentoIdentidad> DocumentoIdentidad { get; set; }
        public DbSet<Proyecto.Model.Clases.Entradas> Entradas { get; set; }
        public DbSet<Proyecto.Model.Clases.DetalleEntradas> DetalleEntradas { get; set; }
        public DbSet<Proyecto.Model.Clases.Proveedores> Proveedores { get; set; }
        public DbSet<Proyecto.Model.Clases.Productos> Productos { get; set; }
        public DbSet<Proyecto.Model.Clases.UnidadesMedidas> UnidadesMedidas { get; set; }
        public DbSet<Proyecto.Model.Clases.TiposEntradas> TiposEntradas { get; set; }
        public DbSet<Proyecto.Model.Clases.CategoriasProductos> CategoriasProductos { get; set; }
        public DbSet<Proyecto.Model.Clases.MarcasProductos> MarcasProductos { get; set; }
        public DbSet<Proyecto.Model.Clases.Salidas> Salidas { get; set; }
        public DbSet<Proyecto.Model.Clases.TiposSalidas> TiposSalidas { get; set; }
        public DbSet<Proyecto.Model.Clases.DetalleSalidas> DetalleSalidas { get; set; }
        public DbSet<Proyecto.Model.Clases.Clientes> Clientes { get; set; }
        public DbSet<Proyecto.Model.Clases.Empleados> Empleados { get; set; }
    }
}