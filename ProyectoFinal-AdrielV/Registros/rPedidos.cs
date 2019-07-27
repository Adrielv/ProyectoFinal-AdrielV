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


namespace ProyectoFinal_AdrielV.Registros
{
    public partial class rPedidos : Form
    {
        public List<PedidoDetalle> Detalle { get; set; }
        public rPedidos()
        {
            InitializeComponent();
            LlenarComboBox();
            LLenarComboBox2();
            Limpiar();
            PedidocomboBox.Text = null;
            ClientecomboBox.Text = null;
         //   ProductocomboBox.Text = null;
            this.Detalle = new List<PedidoDetalle>();
        }
        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            PedidocomboBox.Text = null;
            ClientecomboBox.Text = null;
            ProductocomboBox.Text = null;
            CantidadnumericUpDown.Value = 0;
            CantidadaExistentenumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            ITBISnumericUpDown.Value = 0;
            subTotalnumericUpDown.Value = 0;
            TotalnumericUpDown.Value = 0;
            ProductocomboBox.Text = null;
            this.Detalle = new List<PedidoDetalle>();
            MyErrorProvider.Clear();
            CargarGrid();
        }

        private Pedidos LlenaClase()
        {
            Pedidos pedidos = new Pedidos();
            pedidos.Productos = this.Detalle;

            
           pedidos.Cliente = ClientecomboBox.Text;
               

          
            pedidos.PedidosId = Convert.ToInt32(IDnumericUpDown.Value);
            pedidos.FormaPedido = PedidocomboBox.Text;
            pedidos.FechaPedido = FechadateTimePicker.Value;
            pedidos.ITBIS = ITBISnumericUpDown.Value;
            pedidos.SubTotal = subTotalnumericUpDown.Value;
            pedidos.Total = TotalnumericUpDown.Value;


            return pedidos;

        }
        private void LlenaCampo(Pedidos pedidos)
        {

            IDnumericUpDown.Value = pedidos.PedidosId;
            PedidocomboBox.Text = pedidos.FormaPedido;
           
            ClientecomboBox.Text = pedidos.Cliente;
            FechadateTimePicker.Value = pedidos.FechaPedido;    //falta precio y cantidad
           // PrecionumericUpDown.Value = 
            ITBISnumericUpDown.Value = pedidos.ITBIS;
            subTotalnumericUpDown.Value = pedidos.SubTotal;
            TotalnumericUpDown.Value = pedidos.Total;
            this.Detalle = pedidos.Productos;
            CargarGrid();
  

        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();
            Pedidos pedidos = db.Buscar((int)IDnumericUpDown.Value);
            return (pedidos != null);
        }
        private void CargarGrid()
        {
            InformacionesdataGridView.DataSource = null;
            InformacionesdataGridView.DataSource = Detalle;
        }
        //fALTA VALIDACIONES
        private bool Validar()
        {

            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(PedidocomboBox.Text))
            {
                MyErrorProvider.SetError(PedidocomboBox, "El campo Estudiante no puede estar vacio");
                PedidocomboBox.Focus();
                paso = false;

            }

            if (string.IsNullOrWhiteSpace(ClientecomboBox.Text))
            {
                MyErrorProvider.SetError(ClientecomboBox, "El campo Estudiante no puede estar vacio");
                ClientecomboBox.Focus();
                paso = false;

            }
         
            return paso;
        }

        private void LlenarComboBox()
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            var listado2 = new List<Productos>();
            listado2 = db.GetList(p => true);
            ProductocomboBox.DataSource = listado2;
            ProductocomboBox.DisplayMember = "Descripcion";
            ProductocomboBox.ValueMember = "ProductoId";

        }

        private void LLenarComboBox2()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            var listado = new List<Clientes>();
            listado = db.GetList(l => true);
            ClientecomboBox.DataSource = listado;
            ClientecomboBox.DisplayMember = "Nombres";
            ClientecomboBox.ValueMember = "ClienteId";
        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Pedidos pedidos;
            bool paso = false;

            if (!Validar())
                return;

            pedidos = LlenaClase();
       
            if (IDnumericUpDown.Value == 0)
            {
                paso = PedidosBLL.Guardar(pedidos);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Estudiante que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               paso = PedidosBLL.Modificar(pedidos);

            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //  LlenaClase();
            this.Refresh();
            Limpiar();
            
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();

           

            if (IDnumericUpDown.Value > 0)
            {
                if (PedidosBLL.Eliminar((int)IDnumericUpDown.Value))
                {
                    MessageBox.Show("Eliminado");
                }
                else
                {
                    MyErrorProvider.SetError(IDnumericUpDown, "No se puede elimina, porque no existe");
                }
            }
            else
            {
                MyErrorProvider.SetError(IDnumericUpDown, "Selecione que pedido quiere eliminar");
                IDnumericUpDown.Focus();
            }

            Limpiar();
        }

        private void EliminarLineabutton_Click(object sender, EventArgs e)
        {
            if (InformacionesdataGridView.Rows.Count > 0 && InformacionesdataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(InformacionesdataGridView.CurrentRow.Index);
                CargarGrid();
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            if (ProductocomboBox.Text == string.Empty)
            {
                MessageBox.Show("Agrege un producto");
                return;
            }
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos productos = db.Buscar((int)ProductocomboBox.SelectedValue);
            if (InformacionesdataGridView.DataSource != null)
                this.Detalle = (List<PedidoDetalle>)InformacionesdataGridView.DataSource;

            Productos p = ProductocomboBox.SelectedItem as Productos;

            this.Detalle.Add(new PedidoDetalle()
            {

                ProductoId = (int)ProductocomboBox.SelectedValue,
                Precio = Convert.ToDecimal(PrecionumericUpDown.Value),
                Cantidad = (int)(CantidadnumericUpDown.Value),
                Id = (int)IDnumericUpDown.Value,
                Impuesto =  p.ITBIS * CantidadnumericUpDown.Value

            });
            CalcularItbis();
            CalcularSubtotal();
            CalcularTotal();


            CargarGrid();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Pedidos> db = new RepositorioBase<Pedidos>();
            int id;
            Pedidos pedidos = new Pedidos();


            int.TryParse(IDnumericUpDown.Text, out id);
            Limpiar();

            pedidos = db.Buscar(id);

            if (pedidos != null)
            {
                LlenaCampo(pedidos);
            }
            else
            {
                MessageBox.Show("Pedido no existe");
            }
        }

        private void ProductocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Productos p = ProductocomboBox.SelectedItem as Productos;
            if (p != null)
            {
                PrecionumericUpDown.Text = Convert.ToString(p.Precio);
                CantidadaExistentenumericUpDown.Text = Convert.ToString(p.Cantidad);
            }
        }
        public void CalcularItbis()
        {
            decimal itbis = 0;
            foreach (var item in Detalle)
            {
                itbis += item.Impuesto;
            }
            ITBISnumericUpDown.Text = itbis.ToString();
        }

        public void CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Detalle)
            {
                total += (item.Precio * item.Cantidad) + item.Impuesto;
            }
            TotalnumericUpDown.Text = total.ToString();
        }

        public void CalcularSubtotal()
        {
            decimal subtotal = 0;
            foreach (var item in Detalle)
            {
                subtotal += item.Precio * item.Cantidad;
            }
           subTotalnumericUpDown.Text = subtotal.ToString();
        }
    }
}
