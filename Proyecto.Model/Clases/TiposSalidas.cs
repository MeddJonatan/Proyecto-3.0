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
    [Table("TiposSalidas")]
    public class TiposSalidas
    {
        // Constructor
        public TiposSalidas()
        {
            this.Salidas = new HashSet<Proyecto.Model.Clases.Salidas>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_TipoSalida { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessage = "El codigo de tipo salida es requerido.")]
        [DisplayName("Codigo Tipo de Salida")]
        [StringLength(10, ErrorMessage = "El codigo de tipo salida no puede tener más de 10 caracteres.")]
        public string Codigo_TipoSalida { get; set; }

        [Required(ErrorMessage = "La descripcion [Nombre] es requerido.")]
        [DisplayName("Descripción Tipo de Salida")]
        [StringLength(50, ErrorMessage = "La descripcion [Nombre] no puede tener más de 50 caracteres.")]
        public string Descripcion_TipoSalida { get; set; }


        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.Salidas> Salidas { get; set; }
    }
}