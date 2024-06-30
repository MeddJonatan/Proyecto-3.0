using Proyecto.Model.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model.Clases
{
    [Table("DetalleEntradas")]
    public class DetalleEntradas
    {
        // Constructor
        public DetalleEntradas()
        {
   
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_DetalleEntrada { get; set; }

        [Required(ErrorMessage = "La Cantidad de entrada es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de entrada debe ser un valor positivo.")]
        public int Cantidad_DetalleEntrada { get; set; }

        [Required(ErrorMessage = "El precio de entrada es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio de entrada debe ser un valor positivo.")]
        public double Precio_DetalleEntrada { get; set; }


        // Relaciones
        //[ForeignKey("ID_Entrada")]
        [Required(ErrorMessage = "La entrada es requerida.")]
        public int ID_Entrada { get; set; }
        public virtual Proyecto.Model.Clases.Entradas Entrada { get; set; }


        //[ForeignKey("ID_Producto")]
        [Required(ErrorMessage = "El producto es requerido.")]
        public int ID_Producto { get; set; }
        public virtual Proyecto.Model.Clases.Productos Productos { get; set; }
    }
}