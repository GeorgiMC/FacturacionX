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
    public partial class FacturarPedido : Form
    {
        public FacturarPedido()
        {
            InitializeComponent();
        }

        private void btnBuscarClie_Click(object sender, EventArgs e)
        {
            ListaClientes frm = new ListaClientes();
            AddOwnedForm(frm);
            frm.ShowDialog();
        }
    }
}
