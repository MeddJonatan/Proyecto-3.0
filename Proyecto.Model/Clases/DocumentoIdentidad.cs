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
    [Table("DocumentoIdentidad")]
    public class DocumentoIdentidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_DocumentoIdentidad { get; set; }

        [Required(ErrorMessage = "El código del documento de identidad es requerido.")]
        [RegularExpression(@"^\d{3}-\d{5}-\d{4}$", ErrorMessage = "El código debe estar en el formato XXX-XXXXX-XXXX")]
        [DisplayName("Codigo Documento de Identidad")]
        [StringLength(14, ErrorMessage = "El código del documento de identidad no puede tener más de 14 caracteres.")]
        [Index(IsUnique = true)]
        public string Codigo_DocumentoIdentidad { get; set; }

        [Required(ErrorMessage = "La fecha de emisión es requerida.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DisplayName("Fecha de emision")]
        [DataType(DataType.Date)]
        public DateTime FechaEmision_DocumentoIdentidad { get; set; }

        [Required(ErrorMessage = "La fecha de expiración es requerida.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DisplayName("Fecha de Expiración")]
        [CustomValidation(typeof(DocumentoIdentidad), "ValidateExpirationDate")]
        [DataType(DataType.Date)]
        public DateTime FechaFinalizacion_DocumentoIdentidad { get; set; }


        // Relaciones
        //[ForeignKey("ID_TipoDocumentoIdentidad")]
        [Required(ErrorMessage = "El tipo de documento de identidad es requerido.")]
        public int ID_TipoDocumentoIdentidad { get; set; }

        public virtual Proyecto.Model.Clases.TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }


        // Validacion
        public static ValidationResult ValidateExpirationDate(DateTime expirationDate, ValidationContext context)
        {
            if (expirationDate < DateTime.Now)
            {
                return new ValidationResult("La fecha de expiración no puede ser anterior a la fecha actual.");
            }
            return ValidationResult.Success;
        }
    }
}