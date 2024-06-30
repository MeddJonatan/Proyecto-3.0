using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Proyecto.Model.Clases
{
    [Table("MarcasProductos")]
    public class MarcasProductos
    {
        // Constructor
        public MarcasProductos()
        {
            this.Productos = new HashSet<Proyecto.Model.Clases.Productos>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_MarcaProducto { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessage = "El código de la marca del producto es requerido.")]
        [DisplayName("Codigo de Marca de Producto")]
        [StringLength(10, ErrorMessage = "El código de la marca del producto no puede tener más de 10 caracteres.")]
        public string Codigo_MarcaProducto { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessage = "El nombre de la marca del producto es requerido.")]
        [DisplayName("Nombre de la Marca de Producto")]
        [StringLength(100, ErrorMessage = "El nombre de la marca del producto no puede tener más de 100 caracteres.")]
        public string Nombre_MarcaProducto { get; set; }


        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.Productos> Productos { get; set; }
    }
}