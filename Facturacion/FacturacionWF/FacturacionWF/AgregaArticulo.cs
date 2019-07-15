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
    public partial class AgregaArticulo : Form
    {
        ArticuloLogica articuloLogica = new ArticuloLogica();
        string tipoForma = "";
        public AgregaArticulo()
        {
            InitializeComponent();
        }
        public AgregaArticulo(string forma)
        {
            InitializeComponent();
            tipoForma = forma;
        }
        private void AgregaArticulo_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            dgvArticulos.AutoGenerateColumns = false;
            dgvArticulos.DataSource = articuloLogica.SeleccionarArticulos(Global.GlobalUser.cia);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvArticulos.AutoGenerateColumns = false;
            dgvArticulos.DataSource = articuloLogica.ObtenerArticulos(Global.GlobalUser.cia,txtBuscar.Text);
        }

        private void dgvArticulos_DoubleClick(object sender, EventArgs e)
        {
            switch (tipoForma)
            {
                case "F":
                    Factura fac = (Factura)Owner;
                    fac.articuloSeleccionado = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
                    fac.agregarArticulo();
                    this.Close();
                    break;
                case "P":
                    Pedido ped = (Pedido)Owner;
                    ped.articuloSeleccionado = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                    break;
                case "D":
                    Devolucion dev = (Devolucion)Owner;
                    dev.articuloSeleccionado = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                    break;
                case "FP":
                    FacturarPedido fped = (FacturarPedido)Owner;
                    fped.articuloSeleccionado = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                    break;
                case "C":
                    Compra com = (Compra)Owner;
                    com.articuloSeleccionado = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
                    this.Close();
                    break;
            }
        }
    }
}
