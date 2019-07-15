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
    public partial class ListaClientes : Form
    {
        ClienteLogica clienteLogica = new ClienteLogica(); 
        public ListaClientes()
        {
            InitializeComponent();
            cargaDatos();
        }

        public void cargaDatos()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = clienteLogica.SeleccionarClientes(Global.GlobalUser.cia);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = clienteLogica.ObtenerCliente(Global.GlobalUser.cia,txtCliente.Text);
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            string codigo = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            Cliente frm = new Cliente("M", codigo);
            frm.Show();
        }

        private void txtAgregar_Click(object sender, EventArgs e)
        {
            Cliente frm = new Cliente();
            MenuPrincipal f1 = Application.OpenForms.OfType<MenuPrincipal>().SingleOrDefault();
            f1.AbrirPantall(frm);
        }

        public void usar()
        {
            Factura frm = (Factura)Owner;
            frm.lblSubtotal.Text = txtCliente.Text;
            this.Close();
        }
    }
}
