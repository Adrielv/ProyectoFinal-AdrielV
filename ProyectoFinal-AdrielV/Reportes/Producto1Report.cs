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
    public partial class Producto1Report : Form
    {
        private List<Productos> ListaProducto;
        public Producto1Report(List<Productos> productos)
        {
            this.ListaProducto = productos;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ProductoReport listado = new ProductoReport();
            listado.SetDataSource(ListaProducto);

            crystalReportViewer1.ReportSource = ListaProducto;
            crystalReportViewer1.Refresh();
        }
    }
}
