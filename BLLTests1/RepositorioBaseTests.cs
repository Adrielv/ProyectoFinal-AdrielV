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
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Proveedores p = new Proveedores();

            p.ProveedorId = 1;
            p.Nombres = "juan";
            p.Direccion = "calle";
            p.Email = "jau@";
            p.Telefono = "121231231";
            p.UsuarioId = 1;

            IRepositorio<Proveedores> repositorio = new RepositorioBase<Proveedores>();
            bool paso = false;
            paso = repositorio.Guardar(p);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>();
            bool paso = false;
            Proveedores c = repositorio.Buscar(2);
            c.Telefono = "8095881234";
            paso = repositorio.Modificar(c);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>();
            Proveedores c = repositorio.Buscar(2);
            Assert.IsNotNull(c);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>();
            List<Proveedores> lista = new List<Proveedores>();
            lista = repositorio.GetList(c => true);
            Assert.IsNotNull(lista);
        }
        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>();
            bool paso = false;
            paso = repositorio.Eliminar(5);
            Assert.AreEqual(true, paso);
        }
    }
}