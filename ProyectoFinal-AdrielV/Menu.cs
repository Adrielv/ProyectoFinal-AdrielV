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

        private void PedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rPedidos pe = new Registros.rPedidos();
            pe.Show();
        }

 
        private void PedidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.cPedidos pe = new Consultas.cPedidos();
            pe.Show();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.cProducto pe = new Consultas.cProducto();
            pe.Show();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros.rLogIn lo = new Registros.rLogIn();
            lo.Show();
        }

        private void ClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consultas.cCliente clw = new Consultas.cCliente();
            clw.Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutVillarSolutions AB = new AboutVillarSolutions();
            AB.Show();
        }

        private void ProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.cProveedor pv = new Consultas.cProveedor();
            pv.Show();
        }
    }
}
