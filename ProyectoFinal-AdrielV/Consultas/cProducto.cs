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
using Entidades;



namespace ProyectoFinal_AdrielV.Consultas
{
    public partial class cProducto : Form
    {
        private List<Productos> Lista;
        public cProducto()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Productos>();
            RepositorioBase<Productos> r = new RepositorioBase<Productos>();
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
                                listado = r.GetList(p => p.ProductoId == id);
                            }
                            break;
                        case "Descripcion":
                            if (!System.Text.RegularExpressions.Regex.IsMatch(CriteriotextBox.Text, "^[a-zA-Z ]"))
                            {
                                MessageBox.Show("No numeros en los Descripcion.");
                            }
                            else
                            {
                                listado = r.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
                            }
                            break;
                  
                            
                        case "Precios":
                            int parseee;
                            if (!int.TryParse(CriteriotextBox.Text, out parseee))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                int precio = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Precio == precio);
                            }
                            break;
                        case "Ganancias":
                            int parseeee;
                            if (!int.TryParse(CriteriotextBox.Text, out parseeee))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                int Ganacia = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Ganancia == Ganacia);
                            }
                            break;


                    }
                    listado = listado.Where(c => c.FechaIngreso.Date >= DesdedateTimePicker.Value.Date && c.FechaIngreso.Date <= HastadateTimePicker.Value.Date).ToList();
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
                    listado = listado.Where(c => c.FechaIngreso.Date >= DesdedateTimePicker.Value.Date && c.FechaIngreso.Date <= HastadateTimePicker.Value.Date).ToList();
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
                                listado = r.GetList(p => p.ProductoId == id);
                            }
                            break;
                        case "Descripcion":
                            if (!System.Text.RegularExpressions.Regex.IsMatch(CriteriotextBox.Text, "^[a-zA-Z ]"))
                            {
                                MessageBox.Show("No numeros en los Descripcion.");
                            }
                            else
                            {
                                listado = r.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
                            }
                            break;
                   
                        case "Precios":
                            int parseee;
                            if (!int.TryParse(CriteriotextBox.Text, out parseee))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                int precio = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Precio == precio);
                            }
                            break;
                        case "Ganancias":
                            int parseeee;
                            if (!int.TryParse(CriteriotextBox.Text, out parseeee))
                            {
                                MessageBox.Show("Solo numeros.");
                            }
                            else
                            {
                                int Ganacia = Convert.ToInt32(CriteriotextBox.Text);
                                listado = r.GetList(p => p.Ganancia == Ganacia);
                            }
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
