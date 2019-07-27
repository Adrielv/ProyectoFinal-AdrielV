using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;

namespace ProyectoFinal_AdrielV.Consultas
{
    public partial class cPedidos : Form
    {
        private List<Pedidos> Lista;
        public cPedidos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Pedidos>();
            RepositorioBase<Pedidos> r = new RepositorioBase<Pedidos>();
            if (checkBox.Checked == true)
            {
                if (CriteriotextBox.Text.Trim().Length > 0)
                {
                    switch (FiltrocomboBox.Text)
                    {
                        case "Todo":
                            listado = r.GetList(p => true);
                            break;
                        case "ID":
                            int parse;
                            if (!int.TryParse(CriteriotextBox.Text, out parse))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                int id = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.PedidosId == id);
                            }
                            break;
                        case "Clientes":
                           
                            listado = r.GetList(p => p.Cliente.Contains(CriteriotextBox.Text));
                            break;
                          

                        case "FormaPedidos":
                            listado = r.GetList(p => p.FormaPedido.Contains(CriteriotextBox.Text));
                            break;
                    }
                    listado = listado.Where(c => c.FechaPedido.Date >= DesdedateTimePicker.Value.Date && c.FechaPedido.Date <= HastadateTimePicker.Value.Date).ToList();
                }
                else
                {
                    if (FiltrocomboBox.Text == string.Empty)
                    {
                        MessageBox.Show("El filtro no puede estar vacio.");
                    }
                    else
                       if ((string)FiltrocomboBox.Text != "Todo")
                    {
                        if (CriteriotextBox.Text == string.Empty)
                        {
                            MessageBox.Show("Al seleccionar uno de ID, Usuario, Nombres o Email necesita escribir algo en el criterio.");
                        }
                    }
                    listado = r.GetList(p => true);
                    listado = listado.Where(c => c.FechaPedido.Date >= DesdedateTimePicker.Value.Date && c.FechaPedido.Date <= HastadateTimePicker.Value.Date).ToList();
                }
                Lista = listado;
                ConsultadataGridView.DataSource = listado;
            }
            else
            {
                if (CriteriotextBox.Text.Trim().Length > 0)
                {
                    switch (FiltrocomboBox.Text)
                    {
                        case "Todo":
                            listado = r.GetList(p => true);
                            break;
                        case "ID":
                            int parse;
                            if (!int.TryParse(CriteriotextBox.Text, out parse))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                int id = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.PedidosId == id);
                            }
                            break;
                        case "Clientes":
                            listado = r.GetList(p => p.Cliente.Contains(CriteriotextBox.Text));
                            break;

                        case "FormaPedidos":
                            listado = r.GetList(p => p.FormaPedido.Contains(CriteriotextBox.Text));
                            break;

                    }
                }
                else
                {
                    if (FiltrocomboBox.Text == string.Empty)
                    {
                        MessageBox.Show("El filtro no puede estar vacio.");
                    }
                    else
                       if ((string)FiltrocomboBox.Text != "Todo")
                    {
                        if (CriteriotextBox.Text == string.Empty)
                        {
                            MessageBox.Show("Al seleccionar uno de ID, Usuario, Nombres o Email necesita escribir algo en el criterio.");
                        }
                    }
                    else
                    {
                        listado = r.GetList(p => true);
                    }

                }
                Lista = listado;
                ConsultadataGridView.DataSource = listado;
            }
        }

     
    }
}
