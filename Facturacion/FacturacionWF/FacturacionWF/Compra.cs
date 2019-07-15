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
    public partial class Compra : Form
    {
        string cia = Global.GlobalUser.cia;
        CompaniaLogica companialogica = new CompaniaLogica();
        TipoLogica tipoLogica = new TipoLogica();
        CajaLogica cajaLogica = new CajaLogica();
        MonedaLogica monedaLogica = new MonedaLogica();
        public string articuloSeleccionado = "";
        public Compra()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ListaClientes frm = new ListaClientes();
            frm.StartPosition = FormStartPosition.CenterScreen;
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregaArticulo frm = new AgregaArticulo("C");
            frm.StartPosition = FormStartPosition.CenterScreen;
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos()
        {
            cboCompania.DataSource = companialogica.SeleccionarCompanias("001");
            cboCompania.DisplayMember = "nombre";
            cboCompania.ValueMember = "cia";
            cboCompania.SelectedValue = cia;

            cboTipo.DataSource = tipoLogica.SeleccionarTipos(cia,"F");
            cboTipo.DisplayMember = "descripcion";
            cboTipo.ValueMember = "tipo";

            txtCaja.Text = Global.GlobalVend.caja +"-"+cajaLogica.ObtenerCaja(cia, Global.GlobalVend.caja).descripcion;

            txtDocumento.Text = "0";

            cboMoneda.DataSource = monedaLogica.SeleccionarMoneda(cia);
            cboMoneda.DisplayMember = "descripcion";
            cboMoneda.ValueMember = "codigo";

            cboEstado.Items.Add(new { Text = "Activo", Value = "A" });
            cboEstado.Items.Add(new { Text = "Pendiente", Value = "P" });
            cboEstado.Items.Add(new { Text = "Nulo", Value = "N" });
            cboEstado.DisplayMember = "Text";
            cboEstado.ValueMember = "Value";
            cboEstado.SelectedIndex = 0;

            txtVendedor.Text = Global.GlobalVend.nombre;
        }

        private void btnCliente_Click_1(object sender, EventArgs e)
        {
            AgregaCliente frm = new AgregaCliente("C");
            frm.StartPosition = FormStartPosition.CenterScreen;
            AddOwnedForm(frm);
            frm.ShowDialog();
        }
    }
}
