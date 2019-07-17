using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedidos
    {
        [Key]
        public int PedidosId { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }

        public Pedidos()
        {
            PedidosId = 0;
            FechaPedido = DateTime.Now;
            Total = 0;
            SubTotal = 0;
            ITBIS = 0;
        }
    }
}
