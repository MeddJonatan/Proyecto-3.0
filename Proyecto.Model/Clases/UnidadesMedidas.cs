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
    [Table("UnidadesMedidas")]
    public class UnidadesMedidas
    {
        // Constructor
        public UnidadesMedidas()
        {
            this.Productos = new HashSet<Proyecto.Model.Clases.Productos>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_UnidadMedida { get; set; }

        [Required(ErrorMessage = "La Abreviatura es requerida.")]
        [Index(IsUnique = true)]
        [DisplayName("Abreviatura Unidad de Medida")]
        [StringLength(5, ErrorMessage = "La Abreviatura no puede tener más de 05 caracteres.")]
        public string Abreviatura_UnidadMedida { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [Index(IsUnique = true)]
        [DisplayName("Descripción Unidad de Medida")]
        [StringLength(20, ErrorMessage = "La Descripcion no puede tener más de 20 caracteres.")]
        public string Descripcion_UnidadMedida { get; set; }

        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.Productos> Productos { get; set; }
    }
}