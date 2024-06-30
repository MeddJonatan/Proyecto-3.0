using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto.Model.Clases
{
    [Table("DetalleSalidas")]
    public class DetalleSalidas
    {
        // Constructor
        public DetalleSalidas()
        {

        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_DetalleSalida { get; set; }

        [Required(ErrorMessage = "La Cantidad de salida es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de salida debe ser un valor positivo.")]
        public int Cantidad_DetalleSalida { get; set; }

        [Required(ErrorMessage = "El precio de salida es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio de salida debe ser un valor positivo.")]
        [DataType(DataType.Currency)]
        public double Precio_DetalleSalida { get; set; }

        
        // Relaciones con otras entidades
        //[ForeignKey("ID_Salida")]
        [Required(ErrorMessage = "La salida es requerida.")]
        public int ID_Salida { get; set; }
        public virtual Proyecto.Model.Clases.Salidas Salidas { get; set; }

        //[ForeignKey("ID_Producto")]
        [Required(ErrorMessage = "El producto es requerido.")]
        public int ID_Producto { get; set; }
        public virtual Proyecto.Model.Clases.Productos Productos { get; set; }      
    }
}