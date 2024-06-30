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
    [Table("Clientes")]
    public class Clientes : Proyecto.Model.Clases.DatosUsuarios
    {
        // Constructor
        public Clientes()
        {
            this.Salidas = new HashSet<Proyecto.Model.Clases.Salidas>();
        } 
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Cliente { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El número de cliente debe ser un valor positivo.")]
        [DisplayName("Numero de cliente")]
        [Index(IsUnique = true)]
        public int NO_Cliente { get; set; }


        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.Salidas> Salidas { get; set; } = new HashSet<Proyecto.Model.Clases.Salidas>();
    }
}