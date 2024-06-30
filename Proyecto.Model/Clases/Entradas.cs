using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model.Clases
{
    [Table("Entradas")]
    public class Entradas
    {
        // Constructor
        public Entradas()
        {
            DetallesEntrada = new HashSet<Proyecto.Model.Clases.DetalleEntradas>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Entrada { get; set; }

        [Required(ErrorMessage = "El codigo de entrada es requerido.")]
        [StringLength(20, ErrorMessage = "El codigo de entrada no puede tener más de 20 caracteres.")]
        [Index(IsUnique = true)]
        public string CodigoEntrada { get; set; }

        [Required(ErrorMessage = "La fecha de entrada es requerida.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime FechaEntrada { get; set; }


        // Relaciones
        //[ForeignKey("ID_Proveedor")]
        [Required(ErrorMessage = "El proveedor es requerido.")]
        public int ID_Proveedor { get; set; }
        public virtual Proyecto.Model.Clases.Proveedores Proveedor { get; set; }

        //[ForeignKey("ID_TipoEntrada")]
        [Required(ErrorMessage = "El tipo de entrada es requerido.")]
        public int ID_TipoEntrada { get; set; }
        public virtual Proyecto.Model.Clases.TiposEntradas TiposEntradas { get; set; }

        //[ForeignKey("ID_Empleado")]
        [Required(ErrorMessage = "El empleado que registró la entrada es requerido.")]
        public int ID_Empleado { get; set; }
        public virtual Proyecto.Model.Clases.Empleados Empleado { get; set; }

        public virtual ICollection<Proyecto.Model.Clases.DetalleEntradas> DetallesEntrada { get; set; }
    }
}