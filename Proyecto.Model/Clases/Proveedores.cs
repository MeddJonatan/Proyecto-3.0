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
    [Table("Proveedores")]
    public class Proveedores
    {
        // Constructor
        public Proveedores()
        {
            Entradas = new HashSet<Proyecto.Model.Clases.Entradas>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Proveedor { get; set; }

        [Required(ErrorMessage = "La descripción de la razón social es requerida.")]
        [Index("RazonSocial", IsUnique = true)]
        [DisplayName("Razon Social")]
        [StringLength(255, ErrorMessage = "La descripción de la razón social no puede tener más de 255 caracteres.")]
        public string RazonSocial { get; set; }

        [Required]
        //[RegularExpression(@"^\d{4}-\d{4}-\d{4}-\d{4}$", ErrorMessage = "El código debe estar en el formato XXXX-XXXX-XXXX-XXXX")]
        [Index("CodigoTributario", IsUnique = true)]
        [DisplayName("Codigo Tributario")]
        [StringLength(19, ErrorMessage = "El código no puede tener más de 19 caracteres.")]
        public string CodigoTributario { get; set; }

        // Relaciones
        public virtual ICollection<Proyecto.Model.Clases.Entradas> Entradas { get; set; }
    }
}