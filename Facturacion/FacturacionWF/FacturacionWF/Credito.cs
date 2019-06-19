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
    public partial class Credito : Form
    {
        public Credito()
        {
            InitializeComponent();
        }

        private void Credito_Load(object sender, EventArgs e)
        {
            int rowEscribir = dgvCredito.Rows.Count - 1;
            dgvCredito.Rows.Add();
            dgvCredito.Rows[0].DefaultCellStyle.BackColor = Color.LightBlue;
            dgvCredito.Rows[0].Cells[0].Value = "1";
            dgvCredito.Rows[0].Cells[1].Value = "Georgi";
            dgvCredito.Rows[0].Cells[2].Value = "10000";
            DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
            btngrid.Name = "Código";
            btngrid.HeaderText = "Visualizar Producto";
            btngrid.UseColumnTextForButtonValue = true;
            dgvCredito.Columns.Add(btngrid);

            dgvCredito.Rows.Add();
            dgvCredito.Rows[1].Cells[0].Value = "";
            dgvCredito.Rows[1].Cells[1].Value = "Factura";
            dgvCredito.Rows[1].Cells[2].Value = "5000";
            dgvCredito.Rows.Add();
            dgvCredito.Rows[2].Cells[0].Value = "";
            dgvCredito.Rows[2].Cells[1].Value = "Factura";
            dgvCredito.Rows[2].Cells[2].Value = "5000";

            dgvCredito.Rows.Add();
            dgvCredito.Rows[3].DefaultCellStyle.BackColor = Color.LightBlue;
            dgvCredito.Rows[3].Cells[0].Value = "2";
            dgvCredito.Rows[3].Cells[1].Value = "Carlos";
            dgvCredito.Rows[3].Cells[2].Value = "15000";

            dgvCredito.Rows.Add();
            dgvCredito.Rows[4].Cells[0].Value = "";
            dgvCredito.Rows[4].Cells[1].Value = "Factura";
            dgvCredito.Rows[4].Cells[2].Value = "15000";
            dgvCredito.Rows.Add();
        }

        private void dgvCredito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor = dgvCredito.SelectedRows[0].Cells[0].Value.ToString();
            foreach (DataGridViewRow row in dgvCredito.Rows)
            {
                row.Cells["Pago"].Value.ToString();
            }
        }
    }
}
