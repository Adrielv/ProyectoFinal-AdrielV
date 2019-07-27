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
        public static bool Guardar(Pedidos pedidos)
        {
            bool paso = false;
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            Contexto db = new Contexto();
            try
            {
                if (db.Pedidos.Add(pedidos) != null)
                {
                    foreach (var item in pedidos.Productos)
                    {
                        var producto = prod.Buscar(item.ProductoId);
                        producto.Cantidad -= item.Cantidad;
                        prod.Modificar(producto);
                    }
                    paso = db.SaveChanges() > 0;
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
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            try
            {
                var venta = db.Pedidos.Find(id);
                foreach (var item in venta.Productos)
                {
                    var producto = prod.Buscar(item.ProductoId);
                    producto.Cantidad += item.Cantidad;
                    prod.Modificar(producto);
                }
                db.Entry(venta).State = EntityState.Deleted;
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
        public static bool Modificar(Pedidos pedidos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Pedidos> vent = new RepositorioBase<Pedidos>();
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            try
            {
                var pedidoss = vent.Buscar(pedidos.PedidosId);


                if (pedidos != null)
                {
                    foreach (var item in pedidos.Productos)
                    {
                        db.Productos.Find(item.ProductoId).Cantidad += item.Cantidad;

                        if (!pedidos.Productos.ToList().Exists(v => v.Id == item.Id))
                        {

                            db.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in pedidos.Productos)
                    {
                        db.Productos.Find(item.ProductoId).Cantidad -= item.Cantidad;
                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        db.Entry(item).State = estado;
                    }

                    db.Entry(pedidos).State = EntityState.Modified;
                }

                if (db.SaveChanges() > 0)
                {
                    paso = true;
                }
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

    }
}
