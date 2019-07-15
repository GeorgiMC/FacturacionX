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
    public partial class ListaArticulo : Form
    {
        ArticuloLogica articuloLogica = new ArticuloLogica(); 
        public ListaArticulo()
        {
            InitializeComponent();
        }

        private void ListaArticulo_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            dgvArticulos.AutoGenerateColumns = false;
            dgvArticulos.DataSource = articuloLogica.SeleccionarArticulos(Global.GlobalUser.cia);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo frm = new Articulo();
            MenuPrincipal f1 = Application.OpenForms.OfType<MenuPrincipal>().SingleOrDefault();
            f1.AbrirPantall(frm);
        }

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
