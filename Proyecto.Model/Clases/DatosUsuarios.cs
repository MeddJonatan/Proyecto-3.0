using Proyecto.Model.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Proyecto.Model.Clases
{
    [Table("DatosUsuarios")]
    public class DatosUsuarios
    {
        // Constructor
        public DatosUsuarios()
        {
            this.DocumentoIdentidad = new HashSet <Proyecto.Model.Clases.DocumentoIdentidad>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_DatoUsuario { get; set; }

        [Required(ErrorMessage = "El primer nombre es requerido.")]
        [DisplayName("Primer Nombre")]
        [StringLength(50, ErrorMessage = "El primer nombre no puede tener más de 50 caracteres.")]
        public string PrimerNombre { get; set; }

        [StringLength(50, ErrorMessage = "El segundo nombre no puede tener más de 50 caracteres.")]
        [DisplayName("Segundo Nombre")]
        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido.")]
        [StringLength(50, ErrorMessage = "El primer apellido no puede tener más de 50 caracteres.")]
        [DisplayName("Primer Apellido")]
        public string PrimerApellido { get; set; }

        [StringLength(50, ErrorMessage = "El segundo apellido no puede tener más de 50 caracteres.")]
        [DisplayName("Segundo Apellido")]
        public string SegundoApellido { get; set; }
        
        [Required]
        [Range(18, 120, ErrorMessage = "La edad debe estar entre 18 y 120 años.")]
        [DisplayName("Edad")]
        public int Edad { get; set; }

        
        // Relaciones
        //[ForeignKey("ID_NumTelefono")]
        [Required(ErrorMessage = "El número de teléfono es requerido.")]
        public int ID_NumTelefono { get; set; }
        public virtual Proyecto.Model.Clases.NumerosTelefonicos NumerosTelefonicos { get; set; }

        //[ForeignKey("ID_Genero")]
        [Required(ErrorMessage = "El género es requerido.")]
        public int ID_Genero { get; set; }
        public virtual Proyecto.Model.Clases.Generos Generos { get; set; }

        public virtual ICollection<Proyecto.Model.Clases.DocumentoIdentidad> DocumentoIdentidad { get; set; }
    }
}