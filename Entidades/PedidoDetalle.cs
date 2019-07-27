using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoDetalle
    {
        [Key]
        public int Id { get; set; }

     

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

       public decimal Impuesto { get; set; }

        public PedidoDetalle()
        {
            Id = 0;
         
            ProductoId = 0;
            Cantidad = 0;
            Precio = 0;
            Impuesto = 0;
        }
    }
}
