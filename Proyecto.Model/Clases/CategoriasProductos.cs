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
    [Table("CategoriasProductos")]
    public class CategoriasProductos
    {
        // Constructor
        public CategoriasProductos()
        {
            this.Productos = new HashSet<Proyecto.Model.Clases.Productos>();
        }


        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_CategoriaProducto { get; set; }

        [Required(ErrorMessage = "El código de la categoria de producto es requerido.")]
        [Index(IsUnique = true)]
        [DisplayName("Código de la Categoría")]
        [StringLength(5, ErrorMessage = "El código de la categoria de producto no puede tener más de 05 caracteres.")]
        public string Codigo_CategoriaProducto { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria de producto es requerido.")]
        [Index(IsUnique = true)]
        [DisplayName("Nombre de la Categoria")]
        [StringLength(100, ErrorMessage = "El nombre de la categoria de producto no puede tener más de 100 caracteres.")]
        public string Nombre_CategoriaProducto { get; set; }


        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.Productos> Productos { get; set; }
    }
}