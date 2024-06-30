using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model.Clases
{
    [Table("Productos")]
    public class Productos
    {
        // Constructor
        public Productos()
        {
            this.DetalleEntradas = new HashSet<Proyecto.Model.Clases.DetalleEntradas>();
            this.DetalleSalidas = new HashSet<Proyecto.Model.Clases.DetalleSalidas>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Producto { get; set; }

        [Required(ErrorMessage = "El codigo del producto es obligatorio")]
        [StringLength(10, ErrorMessage = "El codigo no puede exceder los 10 caracteres")]
        [DisplayName("Codigo Producto")]
        [Index(IsUnique = true)]
        public string Codigo_Producto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [DisplayName("Nombre Producto")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string NombreProducto { get; set; }


        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.DetalleEntradas> DetalleEntradas { get; set; }
        public virtual ICollection<Proyecto.Model.Clases.DetalleSalidas> DetalleSalidas { get; set; }

        //[ForeignKey("ID_CategoriaProducto")]
        public int ID_CategoriaProducto { get; set; }
        public virtual Proyecto.Model.Clases.CategoriasProductos CategoriasProductos { get; set; }

        //[ForeignKey("ID_MarcaProducto")]
        public int ID_MarcaProducto { get; set; }
        public virtual Proyecto.Model.Clases.MarcasProductos MarcasProductos { get; set; }

        //[ForeignKey("ID_UnidadMedida")]
        public int ID_UnidadMedida { get; set; }
        public virtual Proyecto.Model.Clases.UnidadesMedidas UnidadesMedidas { get; set; }
    }
}