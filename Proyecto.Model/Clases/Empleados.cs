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
    [Table("Empleados")]
    public class Empleados : Proyecto.Model.Clases.DatosUsuarios
    {
        // Constructor
        public Empleados()
        {
            this.Entradas = new HashSet<Proyecto.Model.Clases.Entradas>();
            this.Salidas = new HashSet<Proyecto.Model.Clases.Salidas>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Empleado { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [DisplayName("Número de Empleado")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de empleado debe ser un valor positivo.")]
        public int NO_Empleado { get; set; }

        [Required(ErrorMessage = "El código de empleado es requerido.")]
        [Index(IsUnique = true)]
        [DisplayName("Codigo de Empleado")]
        [StringLength(20, ErrorMessage = "El código de empleado no puede exceder los 20 caracteres.")]
        public string Codigo_Empleado { get; set; }

        [Required]
        [DisplayName("Número de INSS")]
        [RegularExpression(@"^\d{4}-\d{4}-\d{4}$", ErrorMessage = "El número de INSS debe estar en el formato XXXX-XXXX-XXXX.")]
        //[Index(IsUnique = true)]
        public string NO_INSS { get; set; }

        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.Entradas> Entradas { get; set; } = new HashSet<Proyecto.Model.Clases.Entradas>();
        public virtual ICollection<Proyecto.Model.Clases.Salidas> Salidas { get; set; } = new HashSet<Proyecto.Model.Clases.Salidas>();
    }
}