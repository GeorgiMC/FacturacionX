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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //this.WindowState = FormWindowState.Maximized;
            pnFacturacion.Visible = false;
            pninventuario.Visible = false;
            pnCredito.Visible = false;
            pnReportes.Visible = false;
            pnGeneral.Visible = false;

            if (Global.GlobalUser.tipo == "VN")
            {
                btnGeneral.Visible = false;
            }
        }

        public void AbrirPantall(object Formhijo)
        {
            if (this.panelControl.Controls.Count > 0)
                this.panelControl.Controls.RemoveAt(0);
            Form fh = (Form)Formhijo;
            fh.TopLevel = false;
            fh.Top = 20;
            fh.Left = 20;
            this.panelControl.Controls.Add(fh);
            this.panelControl.Tag = fh;
            fh.Show();

            //Form fh = (Form)Formhijo;
            //fh.BackColor = Color.Red;
            //fh.ControlBox = false;
            //fh.Size = new Size(panelControl.Size.Width / 2, panelControl.Size.Height / 2);
            //fh.Top = (panelControl.Height / 2) - (fh.Height / 2);
            //fh.Left = (panelControl.Width / 2) - (fh.Width / 2);
            //fh.FormBorderStyle = FormBorderStyle.None;
            //fh.TopLevel = false;
            //panelControl.Controls.Add(fh);
            //panelControl.Tag = fh;
            //fh.Show();
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            pnFacturacion.Visible = true;
            pninventuario.Visible = false;
            pnCredito.Visible = false;
            pnReportes.Visible = false;
            pnGeneral.Visible = false;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            pnFacturacion.Visible = false;
            pninventuario.Visible = true;
            pnCredito.Visible = false;
            pnReportes.Visible = false;
            pnGeneral.Visible = false;
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            pnFacturacion.Visible = false;
            pninventuario.Visible = false;
            pnCredito.Visible = true;
            pnReportes.Visible = false;
            pnGeneral.Visible = false;
        }

        private void Reportes_Click(object sender, EventArgs e)
        {
            pnFacturacion.Visible = false;
            pninventuario.Visible = false;
            pnCredito.Visible = false;
            pnReportes.Visible = true;
            pnGeneral.Visible = false;
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            pnFacturacion.Visible = false;
            pninventuario.Visible = false;
            pnCredito.Visible = false;
            pnReportes.Visible = false;
            pnGeneral.Visible = true;
        }

        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            CierreCaja frm = new CierreCaja();
            AbrirPantall(frm);
        }

        private void btnCompanias_Click(object sender, EventArgs e)
        {
            Compania frm = new Compania();
            AbrirPantall(frm);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ListaUsuarios frm = new ListaUsuarios();
            AbrirPantall(frm);
        }

        private void btnReporteCompras_Click(object sender, EventArgs e)
        {
           
        }

        private void btnReporteCredito_Click(object sender, EventArgs e)
        {

        }

        private void btnReporteDevolucion_Click(object sender, EventArgs e)
        {

        }

        private void btnReporteFactura_Click(object sender, EventArgs e)
        {

        }

        private void btnListaCredito_Click(object sender, EventArgs e)
        {
            Credito2 frm = new Credito2();
            AbrirPantall(frm);
        }

        private void btnNuevoPago_Click(object sender, EventArgs e)
        {
            Pago frm = new Pago();
            AbrirPantall(frm);
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            ListaClientes frm = new ListaClientes();
            AbrirPantall(frm);
        }

        private void btnListaArticulo_Click(object sender, EventArgs e)
        {
            ListaArticulo frm = new ListaArticulo();
            AbrirPantall(frm);
        }

        private void btnNuevoCompra_Click(object sender, EventArgs e)
        {
            Compra frm = new Compra();
            AbrirPantall(frm);
        }

        private void btnListaInventario_Click(object sender, EventArgs e)
        {
            Inventario frm = new Inventario();
            AbrirPantall(frm);
        }

        private void btnListaDevolucion_Click(object sender, EventArgs e)
        {
            ListadoDevoluciones frm = new ListadoDevoluciones();
            AbrirPantall(frm);
        }

        private void btnListaFactura_Click(object sender, EventArgs e)
        {
            ListadoFacturas frm = new ListadoFacturas();
            AbrirPantall(frm);
        }

        private void btnListaPedido_Click(object sender, EventArgs e)
        {
            ListadoPedidos frm = new ListadoPedidos();
            AbrirPantall(frm);
        }

        private void btnNuevoDevolucion_Click(object sender, EventArgs e)
        {
            Devolucion frm = new Devolucion();
            AbrirPantall(frm);
        }

        private void btnNuevoFactura_Click(object sender, EventArgs e)
        {
            Factura frm = new Factura();
            AbrirPantall(frm);
        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            Pedido frm = new Pedido();
            AbrirPantall(frm);
        }

        private void btnListaProveedor_Click(object sender, EventArgs e)
        {
            ListaProveedores frm = new ListaProveedores();
            AbrirPantall(frm);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            InicioSesion frm = new InicioSesion();
            frm.Show();
            this.Close();
        }
    }
}
