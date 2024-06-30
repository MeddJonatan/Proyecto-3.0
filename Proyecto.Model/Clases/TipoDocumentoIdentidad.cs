using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Proyecto.Model.Clases
{
    [Table("TipoDocumentoIdentidad")]
    public class TipoDocumentoIdentidad
    {
        // Constructor
        public TipoDocumentoIdentidad()
        {
            this.DocumentosIdentidad = new HashSet<Proyecto.Model.Clases.DocumentoIdentidad>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_TipoDocumentoIdentidad { get; set; }

        [Required(ErrorMessage = "El código del tipo de documento es requerido.")]
        [StringLength(10, ErrorMessage = "El código del tipo de documento no puede tener más de 10 caracteres.")]
        [DisplayName("Codigo Tipo Documento de Identidad")]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "El código debe consistir solo en letras mayúsculas y números.")]
        [Index(IsUnique = true)]
        public string Codigo_TipoDocumento { get; set; }

        [Required(ErrorMessage = "La descripción del tipo de documento es requerida.")]
        [DisplayName("Tipo de Documento de Identidad")]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres.")]
        public string Descripcion_TipoDocumentoIdentidad { get; set; }

        // Relaciones
        //[ForeignKey("ID_Pais")]
        [Required(ErrorMessage = "El ID del pais es requerido.")]
        public int ID_Pais { get; set; }
        public virtual Proyecto.Model.Clases.Paises Paises { get; set; }

        public virtual ICollection<Proyecto.Model.Clases.DocumentoIdentidad> DocumentosIdentidad { get; set; }       
    }
}