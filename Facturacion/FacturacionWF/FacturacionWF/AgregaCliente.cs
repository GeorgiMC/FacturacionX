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
    public partial class AgregaCliente : Form
    {
        ClienteLogica clienteLogica = new ClienteLogica();
        string tipoForma = "";
        public AgregaCliente()
        {
            InitializeComponent();
        }

        public AgregaCliente(string forma)
        {
            InitializeComponent();
            tipoForma = forma;
        }

        private void AgregaCliente_Load(object sender, EventArgs e)
        {
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
            dgvClientes.DataSource = clienteLogica.ObtenerCliente(Global.GlobalUser.cia, txtCliente.Text);
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            switch (tipoForma)
            {
                case "F":
                    Factura fac = (Factura)Owner;
                    fac.txtCodCliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    fac.txtNombreCliente.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    fac.agegarCliente();
                    this.Close();
                break;
                case "P":
                    Pedido ped = (Pedido)Owner;
                    ped.txtCodCliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    ped.txtNombreCliente.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    this.Close();
                break;
                case "D":
                    Devolucion dev = (Devolucion)Owner;
                    dev.txtCodCliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    dev.txtNombreCliente.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    this.Close();
                break;
                case "FP":
                    FacturarPedido fped = (FacturarPedido)Owner;
                    fped.txtCodCliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    fped.txtNombreCliente.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    this.Close();
                break;
                case "C":
                    Compra com = (Compra)Owner;
                    com.txtCodCliente.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    com.txtNombreCliente.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    this.Close();
                break;
            }
        }
    }
}
