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
    public partial class ListadoPedidos : Form
    {
        public ListadoPedidos()
        {
            InitializeComponent();
        }

        private void ListadoPedidos_Load(object sender, EventArgs e)
        {
            this.txtCodCliente.GotFocus += OnFocus;
            this.txtCodCliente.LostFocus += OnDefocus;
            this.txtNombre.GotFocus += OnFocusN;
            this.txtNombre.LostFocus += OnDefocusN;
            this.txtDocumento.GotFocus += OnFocusD;
            this.txtCodCliente.LostFocus += OnDefocusD;
            cboEstado.Items.Add("Pendiente");
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("Facturado");
            cboEstado.Items.Add("Nula");
        }


        private void OnFocus(object sender, EventArgs e)
        {
            txtCodCliente.Text = "";
        }

        private void OnDefocus(object sender, EventArgs e)
        {
            if (txtCodCliente.Text == "")
                txtCodCliente.Text = "Codigo Cliente";
        }
        private void OnFocusN(object sender, EventArgs e)
        {
            txtNombre.Text = "";
        }

        private void OnDefocusN(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
                txtNombre.Text = "Nombre Cliente";
        }
        private void OnFocusD(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
        }

        private void OnDefocusD(object sender, EventArgs e)
        {
            if (txtDocumento.Text == "")
                txtDocumento.Text = "Documento";
        }
    }
}
