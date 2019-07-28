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
    public partial class Proveedor1Report : Form
    {
        private List<Proveedores> ListaProveedor;
        public Proveedor1Report(List<Proveedores> Proveedor)
        {
            this.ListaProveedor = Proveedor;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ProveedorReport listado = new ProveedorReport();
            listado.SetDataSource(ListaProveedor);

            crystalReportViewer1.ReportSource = ListaProveedor;
            crystalReportViewer1.Refresh();
        }
    }
}
