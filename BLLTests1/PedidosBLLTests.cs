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
            Pedidos p = new Pedidos();

            p.PedidosId = 1;
            p.Cliente = "Mercedez";
            p.FormaPedido = "Contado";
            p.FechaPedido = DateTime.Now;
            p.ITBIS = 3;
            p.SubTotal = 80;
            p.Total = 83;
         
            IRepositorio<Pedidos> repositorio = new RepositorioBase<Pedidos>();
            bool paso = false;
            paso = repositorio.Guardar(p);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Pedidos> repositorio = new RepositorioBase<Pedidos>();
            bool paso = false;
            Pedidos c = repositorio.Buscar(2);
            c.Total = 58234;
            paso = repositorio.Modificar(c);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Pedidos> repositorio = new RepositorioBase<Pedidos>();
            Pedidos c = repositorio.Buscar(2);
            Assert.IsNotNull(c);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Pedidos> repositorio = new RepositorioBase<Pedidos>();
            List<Pedidos> lista = new List<Pedidos>();
            lista = repositorio.GetList(c => true);
            Assert.IsNotNull(lista);
        }
        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Pedidos> repositorio = new RepositorioBase<Pedidos>();
            bool paso = false;
            paso = repositorio.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}