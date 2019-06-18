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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Factura frm = (Factura)Owner;
            frm.lblSubtotal.Text = txtCodCliente.Text;
            this.Close();
        }

        public void cargaDatos()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = clienteLogica.SeleccionarClientes("001");
        }
    }
}
