using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_AdrielV.Registros
{
    public partial class rLogIn : Form
    {
        public rLogIn()
        {
            InitializeComponent();
        }

        private void Entrarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Expression<Func<Usuarios, bool>> filtro = x => true;
            List<Usuarios> usuario = new List<Usuarios>();
            var username = UsuariotextBox.Text;
            var password = ClavetextBox.Text;
            filtro = x => x.Usuario.Equals(username);
            usuario = Repositorio.GetList(filtro);
            if (usuario.Count > 0)
            {
                if (usuario.Exists(x => x.Usuario.Equals(username)))
                {
                    if (usuario.Exists(x => x.Clave.Equals(Eramake.eCryptography.Encrypt(password))))
                    {
                        Menu f = new Menu();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Clave incorrecta.", "VillarSolution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else
            {
                if (UsuariotextBox.Text == string.Empty)
                    MessageBox.Show("Ingrese un usuario.", "VillarSolution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
        }
    }
}
