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
    [Table("Tiendas")]
    public class Tiendas
    {
        // Constructor
        public Tiendas()
        {
            this.NumerosTelefonicos = new HashSet<Proyecto.Model.Clases.NumerosTelefonicos>();
            this.Entradas = new HashSet<Proyecto.Model.Clases.Entradas>();
            this.Empleados = new HashSet<Proyecto.Model.Clases.Empleados>();
            this.Salidas = new HashSet<Proyecto.Model.Clases.Salidas>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Tienda { get; set; }

        [Required(ErrorMessage = "El código de tienda es requerido.")]
        [StringLength(10, ErrorMessage = "El código de la tienda no puede tener más de 10 caracteres.")]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "El código de la tienda solo puede contener letras mayúsculas y números.")]
        [DisplayName("Codigo de la Tienda")]
        [Index(IsUnique = true)]
        public string Codigo_Tienda { get; set; }

        [Required(ErrorMessage = "El nombre de la tienda es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre de la tienda no puede tener más de 100 caracteres.")]
        [DisplayName("Nombre de la Tienda")]
        [Index(IsUnique = true)]
        public string Nombre_Tienda { get; set; }

        [Required(ErrorMessage = "La dirección de la tienda es requerida.")]
        [DisplayName("Direccion de la Tienda")]
        [StringLength(200, ErrorMessage = "La dirección de la tienda no puede tener más de 200 caracteres.")]
        public string Direccion_Tienda { get; set; }
        

        // Relaciones uno a muchos
        public virtual ICollection<Proyecto.Model.Clases.NumerosTelefonicos> NumerosTelefonicos { get; set; }
        public virtual ICollection<Proyecto.Model.Clases.Entradas> Entradas { get; set; }
        public virtual ICollection<Proyecto.Model.Clases.Empleados> Empleados { get; set; }
        public virtual ICollection<Proyecto.Model.Clases.Salidas> Salidas { get; set; }
    }
}