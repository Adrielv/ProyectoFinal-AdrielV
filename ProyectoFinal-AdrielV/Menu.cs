﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_AdrielV
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rUsuarios u = new Registros.rUsuarios();
            u.Show();
        }

        private void UsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.cUsuario cu = new Consultas.cUsuario();
            cu.Show();
        }

        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rCliente c = new Registros.rCliente();
            c.Show();
        }

        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rProductos p = new Registros.rProductos();
            p.Show();
        }
    }
}