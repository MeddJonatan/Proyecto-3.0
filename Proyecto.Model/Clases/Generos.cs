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
    [Table("Generos")]
    public class Generos
    {
        // Constructor
        public Generos()
        {
            this.DatosUsuarios = new HashSet<Proyecto.Model.Clases.DatosUsuarios>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Genero { get; set; }

        [Required(ErrorMessage = "La descripción del género es requerida.")]
        [StringLength(30, ErrorMessage = "La descripción del género no puede tener más de 30 caracteres.")]
        [DisplayName("Género")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "La descripción del género solo puede contener letras y espacios.")]
        public string Descripcion_Genero { get; set; }


        // Relación de uno a muchos con DatosUsuario
        public virtual ICollection<Proyecto.Model.Clases.DatosUsuarios> DatosUsuarios { get; set; }
    }
}