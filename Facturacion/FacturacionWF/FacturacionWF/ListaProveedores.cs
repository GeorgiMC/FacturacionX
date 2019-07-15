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
    public partial class ListaProveedores : Form
    {
        ProveedorLogica proveedorLogica = new ProveedorLogica();
        public ListaProveedores()
        {
            InitializeComponent();
        }

        private void ListaProveedores_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            dgvProveedor.AutoGenerateColumns = false;
            dgvProveedor.DataSource = proveedorLogica.SeleccionarProveedores(Global.GlobalUser.cia);
        }

        private void dgvProveedor_DoubleClick(object sender, EventArgs e)
        {
            string codigo = dgvProveedor.CurrentRow.Cells[0].Value.ToString();
            Proveedor frm = new Proveedor("M", codigo);
            frm.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor frm = new Proveedor();
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvProveedor.AutoGenerateColumns = false;
            dgvProveedor.DataSource = proveedorLogica.ObtenerProveedores(Global.GlobalUser.cia,txtBuscar.Text);
        }
    }
}
