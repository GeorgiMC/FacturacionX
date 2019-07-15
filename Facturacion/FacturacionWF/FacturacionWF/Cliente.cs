using CapaDatos;
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
    public partial class Cliente : Form
    {
        ClienteLogica clienteLogica = new ClienteLogica();
        UbicacionLogica ubicacionLogica = new UbicacionLogica();
        public Cliente()
        {
            InitializeComponent();
        }

        public Cliente(string modo,string codigo)
        {
            InitializeComponent();

            cboProvincia.DataSource = ubicacionLogica.SeleccionarProvincia();
            cboProvincia.DisplayMember = "NOMPROVINCIA";
            cboProvincia.ValueMember = "CODPROVINCIA";

            cboPais.DataSource = ubicacionLogica.SeleccionarPais();
            cboPais.DisplayMember = "NOMPAIS";
            cboPais.ValueMember = "CODPAIS";

            cboEstado.Items.Add(new { Text = "Activo", Value = "A" });
            cboEstado.Items.Add(new { Text = "Pendiente", Value = "P" });
            cboEstado.Items.Add(new { Text = "Nulo", Value = "N" });
            cboEstado.DisplayMember = "Text";
            cboEstado.ValueMember = "Value";
            cboEstado.SelectedIndex = 0;

            cboTipoCedula.Items.Add(new { Text = "Fisica", Value = "01" });
            cboTipoCedula.Items.Add(new { Text = "Juridica", Value = "02" });
            cboTipoCedula.Items.Add(new { Text = "Dimex", Value = "03" });
            cboTipoCedula.Items.Add(new { Text = "Nite", Value = "04" });
            cboTipoCedula.DisplayMember = "Text";
            cboTipoCedula.ValueMember = "Value";
            cboTipoCedula.SelectedIndex = 0;

            if (modo == "M")
            {
                cargarDatos(codigo);
            }
        }

        public void cargarDatos(string codigo)
        {
            ClienteDatos clie = clienteLogica.ObtenerCliente(Global.GlobalUser.cia, codigo)[0];
            txtCodigo.Text = clie.codCliente;
            txtCedula.Text = clie.cedula;
            cboTipoCedula.SelectedValue = clie.tipoCedula;
            txtCorreo.Text = clie.correo;
            txtDireccion.Text = clie.direccion;
            txtFax.Text = clie.fax;
            txtNombre.Text = clie.nombre;
            txtNombreComer.Text = clie.nombreComercial;
            txtTelefono.Text = clie.telefono;

            cboCanton.DataSource = ubicacionLogica.SeleccionarCanton(clie.provincia);
            cboCanton.DisplayMember = "NOMCANTON";
            cboCanton.ValueMember = "CODCANTON";

            cboDistrito.DataSource = ubicacionLogica.SeleccionarDsitrito(clie.provincia, clie.canton);
            cboDistrito.DisplayMember = "NOMDISTRITO";
            cboDistrito.ValueMember = "CODDISTRITO";

            cboBarrio.DataSource = ubicacionLogica.SeleccionarBarrio(clie.provincia, clie.canton, clie.distrito);
            cboBarrio.DisplayMember = "NOMBARRIO";
            cboBarrio.ValueMember = "CODBARRIO";

            cboProvincia.SelectedValue = clie.provincia;
            cboPais.SelectedValue = clie.pais;
            cboCanton.SelectedValue = clie.canton;
            cboDistrito.SelectedValue = clie.distrito;
            cboBarrio.SelectedValue = clie.barrio;
            cboEstado.SelectedValue = clie.estado;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pr = Convert.ToString(cboProvincia.SelectedValue);
            cboCanton.DataSource = ubicacionLogica.SeleccionarCanton(pr);
            cboCanton.DisplayMember = "NOMCANTON";
            cboCanton.ValueMember = "CODCANTON";
        }

        private void cboCanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pr = Convert.ToString(cboProvincia.SelectedValue);
            string ca = Convert.ToString(cboCanton.SelectedValue);
            cboDistrito.DataSource = ubicacionLogica.SeleccionarDsitrito(pr, ca);
            cboDistrito.DisplayMember = "NOMDISTRITO";
            cboDistrito.ValueMember = "CODDISTRITO";
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pr = Convert.ToString(cboProvincia.SelectedValue);
            string ca = Convert.ToString(cboCanton.SelectedValue);
            string di = Convert.ToString(cboDistrito.SelectedValue);
            cboBarrio.DataSource = ubicacionLogica.SeleccionarBarrio(pr, ca, di);
            cboBarrio.DisplayMember = "NOMBARRIO";
            cboBarrio.ValueMember = "CODBARRIO";
        }

        private void cboBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
