﻿using System;
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

        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public PedidoDetalle()
        {
            Id = 0;
            Producto = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }
    }
}
