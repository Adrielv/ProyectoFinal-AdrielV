﻿using BLL;
using DAL;
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

namespace ProyectoFinal_AdrielV.Registros
{
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {

            IDnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            NombreDeUsuariotextBox.Text = string.Empty;
            ClavetextBox.Text = string.Empty;
            ConfirmarClavetextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            FechaDeCreaciondateTimePicker.Value = DateTime.Now;
            MyErrorProvider.Clear();

        }
        private Usuarios LlenaClase()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = Convert.ToInt32(IDnumericUpDown.Value);
            usuarios.Nombres = NombrestextBox.Text;
            usuarios.Usuario = NombreDeUsuariotextBox.Text;
            usuarios.Clave = Eramake.eCryptography.Encrypt(ClavetextBox.Text);
            usuarios.Email = EmailtextBox.Text;
            usuarios.FechaCreacion = FechaDeCreaciondateTimePicker.Value;


            return usuarios;
        }

        private void LlenaCampo(Usuarios usuarios)
        {
            IDnumericUpDown.Value = usuarios.UsuarioId;
            NombrestextBox.Text = usuarios.Nombres;
            NombreDeUsuariotextBox.Text = usuarios.Usuario;
            ClavetextBox.Text = usuarios.Clave;
            ConfirmarClavetextBox.Text = usuarios.Clave;
            EmailtextBox.Text = usuarios.Email;
            FechaDeCreaciondateTimePicker.Value = usuarios.FechaCreacion;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = Repositorio.Buscar((int)IDnumericUpDown.Value);
            return (usuarios != null);
        }
        public static bool RepetirUser(string descripcion)
        {
            RepositorioBase<Usuarios> r = new RepositorioBase<Usuarios>();
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Usuarios.Any(p => p.Usuario.Equals(descripcion)))
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
        public static bool RepetirUsuario(string descripcion)
        {
            RepositorioBase<Usuarios> r = new RepositorioBase<Usuarios>();
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
              
                if (db.Usuarios.Any(p => p.Usuario.Equals(descripcion)))
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

            if (RepetirUsuario(NombreDeUsuariotextBox.Text))
            {
                MyErrorProvider.SetError(NombreDeUsuariotextBox, "No se debe repetir los usuarios.");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(NombrestextBox.Text))
            {
                MyErrorProvider.SetError(NombrestextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NombreDeUsuariotextBox.Text))
            {
                MyErrorProvider.SetError(NombreDeUsuariotextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ClavetextBox.Text))
            {
                MyErrorProvider.SetError(ClavetextBox, "No puede ser vacio.");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(EmailtextBox.Text))
            {
                MyErrorProvider.SetError(EmailtextBox, "No puede ser vacio.");
                paso = false;
            }
            if (FechaDeCreaciondateTimePicker.Value > DateTime.Now)
            {
                MyErrorProvider.SetError(FechaDeCreaciondateTimePicker, "No se puede registrar esta fecha.");
                paso = false;
            }
            if (RepetirUser(NombreDeUsuariotextBox.Text))
            {
                MyErrorProvider.SetError(NombreDeUsuariotextBox, "No se debe repetir los usuarios.");
                paso = false;
            }
            if (ConfirmarClavetextBox.Text != ClavetextBox.Text)
            {
                MyErrorProvider.SetError(ConfirmarClavetextBox, "La clave no coincide.");
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

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            usuarios = Repositorio.Buscar(id);
            if (usuarios != null)
                LlenaCampo(usuarios);
            else
                MessageBox.Show("No encontrado.");
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();

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

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            bool paso = false;
            usuarios = LlenaClase();

            if (!Validar())
                return;

            if (IDnumericUpDown.Value == 0)
                paso = Repositorio.Guardar(usuarios);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Repositorio.Modificar(usuarios);
            }

            if (paso)
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void NombrestextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void NombreDeUsuariotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void EmailtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
