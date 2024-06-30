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
    [Table("EmpresasTelefonicas")]
    public class EmpresasTelefonicas
    {
        // Constructor
        public EmpresasTelefonicas()
        {
            this.NumerosTelefonicos = new HashSet<Proyecto.Model.Clases.NumerosTelefonicos>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_EmpresaTelefonica { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa telefónica es requerido.")]
        [Index(IsUnique = true)]
        [DisplayName("Nombre Empresa Telefonica")]
        [StringLength(100, ErrorMessage = "El nombre de la empresa no puede tener más de 100 caracteres.")]
        public string Nombre_EmpresaTelefonica { get; set; }


        // Relación uno a muchos con NumerosTelefonicos
        public virtual ICollection<Proyecto.Model.Clases.NumerosTelefonicos> NumerosTelefonicos { get; set; }
    }
}