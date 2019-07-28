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
    public partial class Factura1Report : Form
    {
        private List<PedidoDetalle> ListaPedidos;
        public Factura1Report(List<PedidoDetalle> detalles)
        {
            this.ListaPedidos = detalles;
            InitializeComponent();
        }
        
        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
           FacturaReport listado = new FacturaReport();
            listado.SetDataSource(ListaPedidos);

            crystalReportViewer1.ReportSource = ListaPedidos;
            crystalReportViewer1.Refresh();
        }
    }
}
