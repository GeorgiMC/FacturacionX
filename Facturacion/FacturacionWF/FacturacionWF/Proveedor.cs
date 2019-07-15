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
    public partial class Proveedor : Form
    {
        ProveedorLogica proveedorLogica = new ProveedorLogica();
        UbicacionLogica ubicacionLogica = new UbicacionLogica();
        public Proveedor()
        {
            InitializeComponent();
        }

        public Proveedor(string modo, string codigo)
        {
            InitializeComponent();

            cboProvincia.DataSource = ubicacionLogica.SeleccionarProvincia();
            cboProvincia.DisplayMember = "NOMPROVINCIA";
            cboProvincia.ValueMember = "CODPROVINCIA";

            CboPais.DataSource = ubicacionLogica.SeleccionarPais();
            CboPais.DisplayMember = "NOMPAIS";
            CboPais.ValueMember = "CODPAIS";

            cboEstado.Items.Add(new { Text = "Activo", Value = "A" });
            cboEstado.Items.Add(new { Text = "Pendiente", Value = "P" });
            cboEstado.Items.Add(new { Text = "Nulo", Value = "N" });
            cboEstado.DisplayMember = "Text";
            cboEstado.ValueMember = "Value";
            cboEstado.SelectedIndex = 0;

            if (modo == "M")
            {
                cargarDatos(codigo);
            }
        }

        public void cargarDatos(string codigo)
        {
            ProveedorDatos pro = proveedorLogica.ObtenerProveedores(Global.GlobalUser.cia,codigo)[0];
            txtCodigo.Text = pro.codProveedor;
            txtCedula.Text = pro.cedula;
            txtcodActividad.Text = pro.codigoActividad;
            txtCorreo.Text = pro.correo;
            txtDireccion.Text = pro.direccion;
            txtFax.Text = pro.fax;
            txtNombre.Text = pro.nombre;
            txtNombreComer.Text = pro.nombreComercial;
            txtTelefono.Text = pro.telefono;

            cboCanton.DataSource = ubicacionLogica.SeleccionarCanton(pro.provincia);
            cboCanton.DisplayMember = "NOMCANTON";
            cboCanton.ValueMember = "CODCANTON";

            cboDistrito.DataSource = ubicacionLogica.SeleccionarDsitrito(pro.provincia,pro.canton);
            cboDistrito.DisplayMember = "NOMDISTRITO";
            cboDistrito.ValueMember = "CODDISTRITO";

            CboBarrio.DataSource = ubicacionLogica.SeleccionarBarrio(pro.provincia, pro.canton,pro.distrito);
            CboBarrio.DisplayMember = "NOMBARRIO";
            CboBarrio.ValueMember = "CODBARRIO";

            cboProvincia.SelectedValue = pro.provincia;
            CboPais.SelectedValue = pro.pais;
            cboCanton.SelectedValue = pro.canton;
            cboDistrito.SelectedValue = pro.distrito;
            CboBarrio.SelectedValue = pro.barrio;
            cboEstado.SelectedValue = pro.estado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProveedorDatos obj = new ProveedorDatos();
            obj.cia = Global.GlobalUser.cia;
            obj.codProveedor = txtCodigo.Text;
            obj.nombre = txtNombre.Text;
            obj.nombreComercial = txtNombreComer.Text;
            obj.tipoCedula = "02";
            obj.cedula = txtCedula.Text;
            obj.telefono = txtTelefono.Text;
            obj.fax = txtFax.Text;
            obj.direccion = txtDireccion.Text;
            obj.correo = txtCorreo.Text;
            obj.provincia = Convert.ToString(cboProvincia.SelectedValue);
            obj.canton = Convert.ToString(cboCanton.SelectedValue);
            obj.distrito = Convert.ToString(cboDistrito.SelectedValue);
            obj.barrio = Convert.ToString(CboBarrio.SelectedValue);
            obj.pais = Convert.ToString(CboPais.SelectedValue);
            obj.codigoActividad = txtcodActividad.Text;
            obj.estado = Convert.ToString(cboEstado.SelectedValue);
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
            cboDistrito.DataSource = ubicacionLogica.SeleccionarDsitrito(pr,ca);
            cboDistrito.DisplayMember = "NOMDISTRITO";
            cboDistrito.ValueMember = "CODDISTRITO";
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pr = Convert.ToString(cboProvincia.SelectedValue);
            string ca = Convert.ToString(cboCanton.SelectedValue);
            string di = Convert.ToString(cboDistrito.SelectedValue);
            CboBarrio.DataSource = ubicacionLogica.SeleccionarBarrio(pr,ca,di);
            CboBarrio.DisplayMember = "NOMBARRIO";
            CboBarrio.ValueMember = "CODBARRIO";
        }

        private void CboBarrio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
