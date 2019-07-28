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
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();


            Usuarios us = new Usuarios()
            {
                UsuarioId = 0,
                Usuario = "Juan123",
                Clave = "12345",
                Nombres ="Adriel",
                Email = "johnsiel1@gmail.com",
                FechaCreacion = DateTime.Now
            };
            Assert.IsTrue(db.Guardar(us));
        }
    }
}