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
    [Table("TiposEntradas")]
    public class TiposEntradas
    {
        // Constructor
        public TiposEntradas ()
        {
            this.Entradas = new HashSet<Proyecto.Model.Clases.Entradas>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_TipoEntrada { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessage = "El codigo de tipo entrada es requerido.")]
        [DisplayName("Codigo Tipo de Entrada")]
        [StringLength(10, ErrorMessage = "El codigo de tipo entrada no puede tener más de 10 caracteres.")]
        public string Codigo_TipoEntrada { get; set; }

        [Required(ErrorMessage = "La descripcion [Nombre] es requerido.")]
        [DisplayName("Descripcion Tipo de Entrada")]
        [StringLength(50, ErrorMessage = "La descripcion [Nombre] no puede tener más de 50 caracteres.")]
        public string Descripcion_TipoEntrada { get; set; }


        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.Entradas> Entradas { get; set; }
    }
}
