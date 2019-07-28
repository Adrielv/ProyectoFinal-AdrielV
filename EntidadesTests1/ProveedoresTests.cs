using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace Entidades.Tests
{
    [TestClass()]
    public class ProveedoresTests
    {
        [TestMethod()]
        public void ProveedoresTest()
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
    }
}