using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PedidosBLL
    {
     /*   public static bool Modificar(Pedidos pedidos)
        {
            bool paso = false;
            Contexto db = new Contexto();
         //   RepositorioBase<Estudiante> dbEst = new RepositorioBase<Estudiantes>();


            try
            {

                var estudiante = dbEst.Buscar(inscripcion.EstudianteId);
                var anterior = new RepositorioBase<Inscripcion>().Buscar(inscripcion.InscripcionId);
                estudiante.Balance -= anterior.MontoTotal;

                foreach (var item in anterior.Asignaturas)
                {
                    if (!inscripcion.Asignaturas.Any(A => A.Id == item.Id))
                    {
                        db.Entry(item).State = EntityState.Deleted;

                    }

                }

                foreach (var item in inscripcion.Asignaturas)
                {
                    if (item.Id == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                }


                inscripcion.CalcularMonto();
                estudiante.Balance += inscripcion.MontoTotal;
                dbEst.Modificar(estudiante);

                db.Entry(inscripcion).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }*/
        public static bool Guardar(Pedidos pedidos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
              //  RepositorioBase<Estudiantes> dbEst = new RepositorioBase<Estudiantes>();

                if (db.Pedidos.Add(pedidos) != null)
                {
                  /* var estudiante = dbEst.Buscar(inscripcion.EstudianteId);

                    inscripcion.CalcularMonto();
                    estudiante.Balance += inscripcion.MontoTotal;*/
                    paso = db.SaveChanges() > 0;
                  //  dbEst.Modificar(estudiante);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
         //   RepositorioBase<Estudiantes> dbEst = new RepositorioBase<Estudiantes>();
            try
            {
                var Inscripcion = db.Pedidos.Find(id);
            //    var estudiante = dbEst.Buscar(Inscripcion.EstudianteId);
            //    estudiante.Balance = estudiante.Balance - Inscripcion.MontoTotal;
             //   dbEst.Modificar(estudiante);
                db.Entry(Inscripcion).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
    }
}
