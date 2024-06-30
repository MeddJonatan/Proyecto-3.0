using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Model.Clases;
using System.ComponentModel;

namespace Proyecto.Model.Clases
{
    [Table("Paises")]
    public class Paises
    {
        // Constructor
        public Paises()
        {
            this.TipoDocumentoIdentidades = new HashSet<Proyecto.Model.Clases.TipoDocumentoIdentidad>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Pais { get; set; }

        [Required(ErrorMessage = "El código de país es requerido.")]
        [StringLength(3, ErrorMessage = "El código de país debe ser de 3 letras mayúsculas.")]
        [DisplayName("Codigo del Pais")]
        [RegularExpression(@"^[A-Z]{2,3}$", ErrorMessage = "El código de país debe ser de 2 o 3 letras mayúsculas.")]
        [Index(IsUnique = true)]
        public string Codigo_Pais { get; set; }

        [Required(ErrorMessage = "El nombre del país es requerido.")]
        [DisplayName("Nombre del Pais")]
        [StringLength(100, ErrorMessage = "El nombre del país no puede tener más de 100 caracteres.")]
        [Index(IsUnique = true)]
        public string Nombre_Pais { get; set; }

        [Required]
        [DisplayName("Nacionalidad")]
        [StringLength(100, ErrorMessage = "La nacionalidad no puede tener más de 100 caracteres.")]
        public string Nacionalidad { get; set; }

        [Required]
        [DisplayName("Sufijo del Pais")]
        [StringLength(10, ErrorMessage = "El sufijo del país no puede tener más de 10 caracteres.")]
        public string Sufijo_Pais { get; set; }


        // Relación de uno a muchos con TipoDocumentoIdentidad
        public virtual ICollection<Proyecto.Model.Clases.TipoDocumentoIdentidad> TipoDocumentoIdentidades { get; set; }
    }
}