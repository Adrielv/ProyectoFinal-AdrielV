﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_AdrielV.Reportes
{
    public partial class Cliente1Report : Form
    {
        private List<Clientes> ListaClientes;
        public Cliente1Report(List<Clientes> clientes)
        {
            this.ListaClientes = clientes;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ClienteReport listado = new ClienteReport();
            listado.SetDataSource(ListaClientes);

            crystalReportViewer1.ReportSource = ListaClientes;
            crystalReportViewer1.Refresh();
        }
    }
}
