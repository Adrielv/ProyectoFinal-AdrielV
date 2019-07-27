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
    public partial class rProveedores : Form
    {
        public rProveedores()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {

            IDnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
        

            MyErrorProvider.Clear();

        }
        private Proveedores LlenaClase()
        {
            Proveedores proveedores = new Proveedores();

            proveedores.ProveedorId = Convert.ToInt32(IDnumericUpDown.Value);
            proveedores.Nombres = NombrestextBox.Text;

            proveedores.Email = EmailtextBox.Text;
            proveedores.Direccion = DirecciontextBox.Text;
            proveedores.Telefono = TelefonomaskedTextBox.Text;


            return proveedores;
        }

        private void LlenaCampo(Proveedores proveedores)
        {
            IDnumericUpDown.Value = proveedores.ProveedorId;
            NombrestextBox.Text = proveedores.Nombres;
           
            DirecciontextBox.Text = proveedores.Direccion;
            EmailtextBox.Text = proveedores.Email;
            TelefonomaskedTextBox.Text = proveedores.Telefono;
         
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
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores proveedores = Repositorio.Buscar((int)IDnumericUpDown.Value);
            return (proveedores != null);
        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores proveedores = new Proveedores();
            bool paso = false;
            proveedores = LlenaClase();

            if (!Validar())
                return;

            if (IDnumericUpDown.Value == 0)
                paso = Repositorio.Guardar(proveedores);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Repositorio.Modificar(proveedores);
            }

            if (paso)
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Elimianarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
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
            RepositorioBase<Proveedores> Repositorio = new RepositorioBase<Proveedores>();
            Proveedores proveedores = new Proveedores();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            proveedores = Repositorio.Buscar(id);

            if (proveedores != null)
                LlenaCampo(proveedores);
            else
                MessageBox.Show("No encontrado.");
        }
    }
}
