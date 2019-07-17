using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal  Costo { get; set; }

        public decimal Ganancia { get; set; }

        public Productos()
        {
            ProductoId = 0;
            NombreProducto = string.Empty;
            FechaIngreso = DateTime.Now;
            Precio = 0;
            Cantidad = 0;
            Costo = 0;
            Ganancia = 0;
        }
    }
}
