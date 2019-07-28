using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class PedidosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {

            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();


            Pedidos us = new Pedidos()
            {
                PedidosId = 0,
                FechaPedido = DateTime.Now,
                Cliente = "juan",
                FormaPedido = "Contado",
                Total = 1000,
                SubTotal = 750,
                ITBIS = 250
            };
            Assert.IsTrue(db.Guardar(us));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();

            Assert.IsTrue(db.Eliminar(2));
        }
    }
}