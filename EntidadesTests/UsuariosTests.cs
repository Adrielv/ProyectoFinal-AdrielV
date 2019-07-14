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
    public class UsuariosTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios u = new Usuarios();
            u.UsuarioId = 1;
            u.Usuario = "Adriel0988";
            u.Clave = "adr123";
            u.Nombres = "Adriel villar";
            u.Email = "Adrielprog@gmail.com";
            u.FechaCreacion = DateTime.Now;

            RepositorioBase<Usuarios> r = new RepositorioBase<Usuarios>();
            bool paso = false;
            paso = r.Guardar(u);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Usuarios> repositoriobase = new RepositorioBase<Usuarios>();
            bool paso = false;
            Usuarios u = repositoriobase.Buscar(1);
            u.Usuario = "Adrielvv";
            paso = repositoriobase.Modificar(u);
            Assert.AreEqual(true, paso);
        }
        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Usuarios> repositoriobase = new RepositorioBase<Usuarios>();
            Usuarios u = repositoriobase.Buscar(1);
            Assert.IsNotNull(u);
        }
        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Usuarios> repositoriobase = new RepositorioBase<Usuarios>();
            List<Usuarios> lista = new List<Usuarios>();
            lista = repositoriobase.GetList(e => true);
            Assert.IsNotNull(lista);
        }
        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Usuarios> repositoriobase = new RepositorioBase<Usuarios>();
            bool paso = false;
            paso = repositoriobase.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}