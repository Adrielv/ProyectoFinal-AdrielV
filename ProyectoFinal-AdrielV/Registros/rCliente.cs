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
            CedulamaskedTextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CelularmaskedTextBox.Text = string.Empty;
            FechaCreaciondateTimePicker.Value = DateTime.Now;

            MyErrorProvider.Clear();

        }
        private Clientes LlenaClase()
        {
            Clientes clientes = new Clientes();

            clientes.ClienteId = Convert.ToInt32(IDnumericUpDown.Value);
            clientes.Nombres = NombrestextBox.Text;
            clientes.Cedula = CedulamaskedTextBox.Text;
            clientes.Email = EmailtextBox.Text;
            clientes.Direccion = DirecciontextBox.Text;
            clientes.Telefono = TelefonomaskedTextBox.Text;
            clientes.Celular = CelularmaskedTextBox.Text;
            clientes.FechaCreacion = FechaCreaciondateTimePicker.Value;

            return clientes;
        }

        private void LlenaCampo(Clientes clientes)
        {
            IDnumericUpDown.Value = clientes.ClienteId;
            NombrestextBox.Text = clientes.Nombres;
            CedulamaskedTextBox.Text = clientes.Cedula;
            DirecciontextBox.Text = clientes.Direccion;
            EmailtextBox.Text = clientes.Email;
            TelefonomaskedTextBox.Text = clientes.Telefono;
           CelularmaskedTextBox.Text = clientes.Celular;
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
        public static bool RepetirNombre(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Clientes.Any(p => p.Nombres.Equals(descripcion)))
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
        public static bool RepetirCedula(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Clientes.Any(p => p.Cedula.Equals(descripcion)))
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
        public static bool RepetirTelefono(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Clientes.Any(p => p.Telefono.Equals(descripcion)))
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
        private bool ValidarRepeticion()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (RepetirNombre(NombrestextBox.Text))
            {
                MyErrorProvider.SetError(NombrestextBox, "No se pueden repetir.");
                paso = false;
            }
            if ( RepetirCedula(CedulamaskedTextBox.Text))
            {
                MyErrorProvider.SetError(CedulamaskedTextBox, "No se pueden repetir.");
                paso = false;
            }
            if (RepetirTelefono(TelefonomaskedTextBox.Text))
            {
                MyErrorProvider.SetError(TelefonomaskedTextBox, "No se pueden repetir.");
                paso = false;
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
            if (!CedulamaskedTextBox.MaskCompleted)
            {
                MyErrorProvider.SetError(CedulamaskedTextBox, "No puede ser vacio.");
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
            if (!TelefonomaskedTextBox.MaskCompleted)
            {
                MyErrorProvider.SetError(TelefonomaskedTextBox, "No puede ser vacio.");
                paso = false;
            }
            if (!CedulamaskedTextBox.MaskCompleted)
            {
                MyErrorProvider.SetError(CedulamaskedTextBox, "No puede ser vacio.");
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
            {
                if (!ValidarRepeticion())
                    return; 

                paso = Repositorio.Guardar(clientes);
            }
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

        private void NombrestextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
