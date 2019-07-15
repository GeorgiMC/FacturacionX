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
    public partial class ListaUsuarios : Form
    {
        UsuarioLogica usuarioLogica = new UsuarioLogica();
        public ListaUsuarios()
        {
            InitializeComponent();
        }

        private void ListaUsuarios_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.DataSource = usuarioLogica.SeleccionarArticulos(Global.GlobalUser.cia);
        }

        private void txtAgregar_Click(object sender, EventArgs e)
        {
            Usuario frm = new Usuario();
            frm.Show();
        }
    }
}
