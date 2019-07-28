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
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();


            Usuarios us = new Usuarios()
            {
                UsuarioId = 0,
                Nombres = "Adriel",
                Email = "Adriel1@gmail.com",
                Usuario = "Adriel123",
                Clave = "12345",         
                FechaCreacion = DateTime.Now
            };
            Assert.IsTrue(db.Guardar(us));
   
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