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

namespace ProyectoFinal_AdrielV.Reportes
{
    public partial class Pedido1Report : Form
    {
        private List<Pedidos> ListaPedidos;
        public Pedido1Report(List<Pedidos> pedidos)
        {
            this.ListaPedidos = pedidos;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            PedidosReport listado = new PedidosReport();
            listado.SetDataSource(ListaPedidos);

            crystalReportViewer1.ReportSource = ListaPedidos;
            crystalReportViewer1.Refresh();
        }
    }
}
