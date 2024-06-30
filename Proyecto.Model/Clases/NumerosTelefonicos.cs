using Proyecto.Model.Clases;
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
    public class NumerosTelefonicos
    {
        // Constructor
        public NumerosTelefonicos()
        {

        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_NumTelefono { get; set; }

        [Required(ErrorMessage = "El número de teléfono es requerido.")]
        [DisplayName("Número Telefonico")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "El número de teléfono debe ser válido según el formato internacional E.164.")]
        public string NumeroTelefono { get; set; }

        
        // Relaciones
        //[ForeignKey("ID_EmpresaTelefonica")]
        [Required(ErrorMessage = "El ID de la empresa telefónica asociada es requerido.")]
        public int ID_EmpresaTelefonica { get; set; }
        public virtual Proyecto.Model.Clases.EmpresasTelefonicas EmpresasTelefonicas { get; set; }
    }
}