using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace ProyectoFinal_AdrielV.Registros
{
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void Limpiar()
        {

            IDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            PrecionumericUpDown.Value = 0;
            CantidadnumericUpDown.Value = 0;
            CostonumericUpDown.Value = 0;
            GanancianumericUpDown.Value = 0;
            FechaIngresodateTimePicker.Value = DateTime.Now;
            ProveedorescomboBox.Text = string.Empty;
            ITBISnumericUpDown.Value = 0;
            MyErrorProvider.Clear();

        }

        private void LlenarComboBox()
        {
            RepositorioBase<Proveedores> db = new RepositorioBase<Proveedores>();
            var listado2 = new List<Proveedores>();
            listado2 = db.GetList(p => true);
            ProveedorescomboBox.DataSource = listado2;
            ProveedorescomboBox.DisplayMember = "Nombres";
            ProveedorescomboBox.ValueMember = "ProveedorId";

        }

        private Productos LlenaClase()
        {
            Productos productos = new Productos();
            productos.ProductoId = Convert.ToInt32(IDnumericUpDown.Value);
            productos.FechaIngreso = FechaIngresodateTimePicker.Value;
            productos.Descripcion = DescripciontextBox.Text;
            productos.Precio = PrecionumericUpDown.Value;
            productos.Cantidad = (int)CantidadnumericUpDown.Value;
            productos.Costo = (int)CostonumericUpDown.Value;
            productos.Ganancia = (int)GanancianumericUpDown.Value;
            productos.NombresProveedor = ProveedorescomboBox.Text;
            productos.ITBIS = ITBISnumericUpDown.Value;
            
          

            return productos;
        }

        private void LlenaCampo(Productos productos)
        {
            IDnumericUpDown.Value = productos.ProductoId;      
            FechaIngresodateTimePicker.Value = productos.FechaIngreso;
            DescripciontextBox.Text = productos.Descripcion;
            PrecionumericUpDown.Value = productos.Precio;
            CantidadnumericUpDown.Value = productos.Cantidad;
            CostonumericUpDown.Value = productos.Costo;
            GanancianumericUpDown.Value = productos.Ganancia;
            ProveedorescomboBox.Text = productos.NombresProveedor;
            ITBISnumericUpDown.Value = productos.ITBIS;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos productos = Repositorio.Buscar((int)IDnumericUpDown.Value);
            return (productos != null);
        }
       
       
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyErrorProvider.SetError(DescripciontextBox, "No puede ser vacio.");
                paso = false;
            }
            if (PrecionumericUpDown.Value==0)
            {
                MyErrorProvider.SetError(PrecionumericUpDown, "No puede ser 0");
                paso = false;
            }
            if (CantidadnumericUpDown.Value==0)
            {
                MyErrorProvider.SetError(CantidadnumericUpDown, "No puede ser 0");
                paso = false;
            }
            if (CostonumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CostonumericUpDown, "No puede ser 0");
                paso = false;
            }
            if (FechaIngresodateTimePicker.Value > DateTime.Now)
            {
                MyErrorProvider.SetError(FechaIngresodateTimePicker, "No se puede registrar esta fecha.");
                paso = false;
            }
            if (GanancianumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(GanancianumericUpDown, "No puede ser 0");
                paso = false;
            }

            return paso;
        }
        private bool ValidarEliminar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (IDnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(IDnumericUpDown, "Busquelo y luego eliminelo.");
                IDnumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            bool paso = false;
            productos = LlenaClase();

            if (!Validar())
                return;

            if (IDnumericUpDown.Value == 0)
                paso = Repositorio.Guardar(productos);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Repositorio.Modificar(productos);
            }

            if (paso)
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            MyErrorProvider.Clear();
            if (!ValidarEliminar())
                return;

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (Repositorio.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No existe.");
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> Repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            productos = Repositorio.Buscar(id);
            if (productos != null)
                LlenaCampo(productos);
            else
                MessageBox.Show("No encontrado.");
        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {
           double itbs = 0.18;
            ITBISnumericUpDown.Value = PrecionumericUpDown.Value * (decimal)itbs;

            if (CostonumericUpDown.Value < PrecionumericUpDown.Value)
            {
                GanancianumericUpDown.Value = PrecionumericUpDown.Value - CostonumericUpDown.Value;
            }
            else
            {
                GanancianumericUpDown.Value = 0;
            }
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CostonumericUpDown.Value < PrecionumericUpDown.Value)
            {
                GanancianumericUpDown.Value = PrecionumericUpDown.Value - CostonumericUpDown.Value;
            }else
            {
                GanancianumericUpDown.Value = 0;
            }
        }
    }
}
