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
    public partial class ListadoFacturas : Form
    {
        public ListadoFacturas()
        {
            InitializeComponent();
            this.txtCodCliente.GotFocus += OnFocus;
            this.txtCodCliente.LostFocus += OnDefocus;
        }

        private void OnFocus(object sender, EventArgs e)
        {
            txtCodCliente.Text = "";
        }

        private void OnDefocus(object sender, EventArgs e)
        {
            if(txtCodCliente.Text == "")
                txtCodCliente.Text = "Codigo Cliente";
        }
    }
}
