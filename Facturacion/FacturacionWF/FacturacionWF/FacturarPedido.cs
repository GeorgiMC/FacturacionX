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
        public string articuloSeleccionado = "";
        public FacturarPedido()
        {
            InitializeComponent();
        }

        private void btnBuscarClie_Click(object sender, EventArgs e)
        {
            AgregaCliente frm = new AgregaCliente("FP");
            frm.StartPosition = FormStartPosition.CenterScreen;
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregaArticulo frm = new AgregaArticulo("FP");
            frm.StartPosition = FormStartPosition.CenterScreen;
            AddOwnedForm(frm);
            frm.ShowDialog();
        }
    }
}
