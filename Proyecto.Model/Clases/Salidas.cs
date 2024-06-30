using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model.Clases
{
    [Table("Salidas")]
    public class Salidas
    {
        // Constructor
        public Salidas()
        {
            this.DetallesSalidas = new HashSet<Proyecto.Model.Clases.DetalleSalidas>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Salida { get; set; }

        [Required(ErrorMessage = "La fecha de salida es requerida.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Salidas), "ValidarFechaSalida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime FechaSalida { get; set; }


        // Relaciones
        //[ForeignKey("ID_TipoSalida")]
        [Required(ErrorMessage = "El tipo de salida es requerido.")]
        public int ID_TipoSalida { get; set; }
        public virtual Proyecto.Model.Clases.TiposSalidas TiposSalidas { get; set; }

        //[ForeignKey("ID_Empleado")]
        [Required(ErrorMessage = "El empleado que registró la salida es requerido.")]
        public int ID_Empleado { get; set; }
        public virtual Proyecto.Model.Clases.Empleados Empleados { get; set; }

        //[ForeignKey("ID_Cliente")]
        [Required(ErrorMessage = "El cliente que registró la salida es requerido.")]
        public int ID_Cliente { get; set; }
        public virtual Proyecto.Model.Clases.Clientes Clientes { get; set; }

        public virtual ICollection<Proyecto.Model.Clases.DetalleSalidas> DetallesSalidas { get; set; }


        // Validaciones
        // Verifica que la fecha no sea un día no laborable, por ejemplo, un fin de semana o festivo
        public static ValidationResult ValidarFechaSalida(DateTime fechaEntrada, ValidationContext context)
        {
            if (fechaEntrada.DayOfWeek == DayOfWeek.Saturday || fechaEntrada.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("La fecha de entrada no puede ser un día no laborable.");
            }
            return ValidationResult.Success;
        }


        public void ValidarFechaSalida(DateTime fechaEntrada)
        {
            if (this.FechaSalida < fechaEntrada)
            {
                throw new InvalidOperationException("La fecha de salida no puede ser anterior a la fecha de entrada.");
            }
        }
    }
}