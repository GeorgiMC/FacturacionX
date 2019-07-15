using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionWF
{
    public partial class InicioSesion : Form
    {
        UsuarioLogica usuLogica = new UsuarioLogica();
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (usuLogica.ValidaUsuario(txtUsuario.Text,txtContrasena.Text) == true)
            {
                MenuPrincipal frm = new MenuPrincipal();
                frm.Show();
                //this.Close();
            }else
            {
                txtContrasena.Text = "";
                MessageBox.Show("Datos invalidos por favor revisar los datos","Error",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }

        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            
        }
    }
}
