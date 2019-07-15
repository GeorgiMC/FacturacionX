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
    public partial class Articulo : Form
    {
        string cia = Global.GlobalUser.cia;
        CompaniaLogica companialogica = new CompaniaLogica();
        ArticuloLogica articuloLogica = new ArticuloLogica();
        public Articulo()
        {
            InitializeComponent();
        }

        public Articulo(string modo,string codigo)
        {
            InitializeComponent();
            if (modo == "M")
            {
                cargarDatos(codigo);
            }
        }

        public void cargarDatos(string codigo)
        {
            ArticuloDatos articulo = articuloLogica.ObtenerArticulos(cia,codigo)[0];
            txtCodigo.Text = articulo.codArticulo;
            txtDescripcion.Text = articulo.descripcion;
            txtPrecio.Text = articulo.precio.ToString();
        }

        private void Articulo_Load(object sender, EventArgs e)
        {
            cboUnidad.Items.Add(new { Text = "Unidad", Value = "unid" });
            cboUnidad.DisplayMember = "Text";
            cboUnidad.ValueMember = "Value";
            cboUnidad.SelectedIndex = 0;
        }

        private void Articulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ListaArticulo frm = new ListaArticulo();
            MenuPrincipal f1 = Application.OpenForms.OfType<MenuPrincipal>().SingleOrDefault();
            f1.AbrirPantall(frm);
        }
    }
}
