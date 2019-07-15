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
    public partial class Inven : Form
    {
        public Inven()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ListaArticulo frm = new ListaArticulo();
            frm.StartPosition = FormStartPosition.CenterScreen;
            AddOwnedForm(frm);
            frm.ShowDialog();
        }
    }
}
