﻿using System;
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
using ProyectoFinal_AdrielV.Reportes;

namespace ProyectoFinal_AdrielV.Consultas
{
    public partial class cCliente : Form
    {
        private List<Clientes> Lista;
        public cCliente()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Clientes>();
            RepositorioBase<Clientes> r = new RepositorioBase<Clientes>();
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
                                listado = r.GetList(p => p.ClienteId == id);
                            }
                            break;
                        case "Nombres":
                           
                                listado = r.GetList(p => p.Nombres.Contains(CriteriotextBox.Text));
                            break;

                        case "Cedula":
                            listado = r.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                            break;
                        case "Email":
                            listado = r.GetList(p => p.Email.Contains(CriteriotextBox.Text));
                            break;
                        case "Celular":
                           
                                listado = r.GetList(p => p.Celular.Contains(CriteriotextBox.Text));                           
                            break;
                        case "Telefono":
                            listado = r.GetList(p => p.Telefono.Contains(CriteriotextBox.Text));
                            break;
                    }
                    listado = listado.Where(c => c.FechaCreacion.Date >= DesdedateTimePicker.Value.Date && c.FechaCreacion.Date <= HastadateTimePicker.Value.Date).ToList();
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
                    listado = listado.Where(c => c.FechaCreacion.Date >= DesdedateTimePicker.Value.Date && c.FechaCreacion.Date <= HastadateTimePicker.Value.Date).ToList();
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
                                listado = r.GetList(p => p.ClienteId == id);
                            }
                            break;
                        case "Nombres":
                            if (!System.Text.RegularExpressions.Regex.IsMatch(CriteriotextBox.Text, "^[a-zA-Z ]"))
                            {
                                MessageBox.Show("No numeros en los nombres.");
                            }
                            else
                            {
                                listado = r.GetList(p => p.Nombres.Contains(CriteriotextBox.Text));
                            }
                            break;

                        case "Cedula":
                            listado = r.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                            break;
                        case "Email":
                            listado = r.GetList(p => p.Email.Contains(CriteriotextBox.Text));
                            break;
                        case "Celular":

                            listado = r.GetList(p => p.Celular.Contains(CriteriotextBox.Text));
                            break;
                        case "Telefono":
                            listado = r.GetList(p => p.Telefono.Contains(CriteriotextBox.Text));
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

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (ConsultadataGridView.RowCount == 0)
            {
                MessageBox.Show("No se puede imprimir");
                return;
            }
            else
            {
                Cliente1Report r = new Cliente1Report(Lista);
                r.ShowDialog();
            }
        }
    }
}
