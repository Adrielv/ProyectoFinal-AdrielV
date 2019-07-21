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
using Entidades;

namespace ProyectoFinal_AdrielV.Registros
{
    public partial class rCliente : Form
    {
        public rCliente()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {

            IDnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            CedulatextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            TelefonotextBox.Text = string.Empty;
            CelulartextBox.Text = string.Empty;
            FechaCreaciondateTimePicker.Value = DateTime.Now;

            MyErrorProvider.Clear();

        }
        private Clientes LlenaClase()
        {
            Clientes clientes = new Clientes();

            clientes.ClienteId = Convert.ToInt32(IDnumericUpDown.Value);
            clientes.Nombres = NombrestextBox.Text;
            clientes.Cedula = CedulatextBox.Text;
            clientes.Email = EmailtextBox.Text;
            clientes.Direccion = DirecciontextBox.Text;
            clientes.Telefono = TelefonotextBox.Text;
            clientes.Celular = CelulartextBox.Text;
            clientes.FechaCreacion = FechaCreaciondateTimePicker.Value;

            return clientes;
        }

        private void LlenaCampo(Clientes clientes)
        {
            IDnumericUpDown.Value = clientes.ClienteId;
            NombrestextBox.Text = clientes.Nombres;
            CedulatextBox.Text = clientes.Cedula;
            DirecciontextBox.Text = clientes.Direccion;
            EmailtextBox.Text = clientes.Email;
            TelefonotextBox.Text = clientes.Telefono;
            CelulartextBox.Text = clientes.Celular;
            FechaCreaciondateTimePicker.Value = clientes.FechaCreacion;
        }
      

        public static bool RepetirEmail(string descripcion)
        {
            RepositorioBase<Clientes> r = new RepositorioBase<Clientes>();
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Clientes.Any(p => p.Email.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombrestextBox.Text))
            {
                MyErrorProvider.SetError(NombrestextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulatextBox.Text))
            {
                MyErrorProvider.SetError(CedulatextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                MyErrorProvider.SetError(DirecciontextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(EmailtextBox.Text))
            {
                MyErrorProvider.SetError(EmailtextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonotextBox.Text))
            {
                MyErrorProvider.SetError(TelefonotextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CelulartextBox.Text))
            {
                MyErrorProvider.SetError(CelulartextBox, "No puede ser vacio.");
                paso = false;
            }
       
            if (RepetirEmail(EmailtextBox.Text))
            {
                MyErrorProvider.SetError(EmailtextBox, "No se debe usar el mismo email que otro.");
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

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = Repositorio.Buscar((int)IDnumericUpDown.Value);
            return (clientes != null);
        }


        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes();
            bool paso = false;
            clientes = LlenaClase();

            if (!Validar())
                return;

            if (IDnumericUpDown.Value == 0)
                paso = Repositorio.Guardar(clientes);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Repositorio.Modificar(clientes);
            }

            if (paso)
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Elimianarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>();
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


        private void Buscarbutton_Click_1(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> Repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            clientes = Repositorio.Buscar(id);

            if (clientes != null)
                LlenaCampo(clientes);
            else
                MessageBox.Show("No encontrado.");
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
