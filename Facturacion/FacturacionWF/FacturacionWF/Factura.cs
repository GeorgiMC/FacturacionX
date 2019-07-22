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
    public partial class Factura : Form
    {
        string cia = Global.GlobalUser.cia;
        CompaniaLogica companialogica = new CompaniaLogica();
        TipoLogica tipoLogica = new TipoLogica();
        CajaLogica cajaLogica = new CajaLogica();
        MonedaLogica monedaLogica = new MonedaLogica();
        ArticuloLogica articuloLogica = new ArticuloLogica();
        EncabezadoLogica facturaLogica = new EncabezadoLogica();
        DetalleLogica detalleFacturaLogica = new DetalleLogica();
        DetalleFacturaDatos listaDetalle = new DetalleFacturaDatos();
        ClienteLogica clienteLogica = new ClienteLogica();
        public string articuloSeleccionado = "";
        public Factura()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregaArticulo frm = new AgregaArticulo("F");
            frm.StartPosition = FormStartPosition.CenterScreen;
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            string var = Convert.ToString(cboEstado.SelectedValue);
            //AgregaCliente frm = new AgregaCliente("F");
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //AddOwnedForm(frm);
            //frm.ShowDialog();
        }

        private void Factura_Load(object sender, EventArgs e)
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

            DataTable dt = new DataTable();
            dt.Columns.Add("codigo");
            dt.Columns.Add("Nombre");

            DataRow row = dt.NewRow();
            row["codigo"] = "A";
            row["Nombre"] = "Activo";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["codigo"] = "P";
            row["Nombre"] = "Pendiente";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["codigo"] = "N";
            row["Nombre"] = "Nulo";
            dt.Rows.Add(row);

            cboEstado.DataSource = dt;
            cboEstado.DisplayMember = "Nombre";
            cboEstado.ValueMember = "codigo";
            cboEstado.SelectedIndex = 0;

            cboListaPrecio.DataSource = clienteLogica.SeleccionarListaPrecio(cia,"");
            cboListaPrecio.DisplayMember = "descripcion";
            cboListaPrecio.ValueMember = "codigo";

            txtVendedor.Text = Global.GlobalVend.nombre;
        }

        public void agregarArticulo()
        {
            double precioArticulo = 0;
            double porcentajeImp = 0;
            double impuestoArticulo = 0;
            double totalLinea = 0;
            ArticuloDatos art = new ArticuloDatos();
            art = articuloLogica.ObtenerArticulos(cia, articuloSeleccionado)[0];
            precioArticulo = clienteLogica.ObtenerListaPrecio(cia, Convert.ToString(cboListaPrecio.SelectedValue),
            art.codArticulo)[0].precio;
            porcentajeImp = articuloLogica.ObtenerImpuesto(cia, art.impuesto)[0].porcentaje;
            impuestoArticulo = Math.Round(precioArticulo * (porcentajeImp / 100), 2);
            totalLinea = Math.Round(precioArticulo + impuestoArticulo,2);
            dgvDetalle.Rows.Add(art.codArticulo,art.descripcion,1, precioArticulo, 0,impuestoArticulo,totalLinea);
            CalculaTotales();
        }

        public void agegarCliente()
        {
            string codCliente = txtCodCliente.Text;
            ClienteDatos clie = clienteLogica.ObtenerCliente(cia,codCliente)[0];
            cboListaPrecio.SelectedValue = clie.ListaPrecio;
        }

        public void CalculaTotales(){
            double subtotal = 0;
            double porcDescuento = 0;
            double totalImpuesto = 0;
            double totalDescuento = 0;
            double total = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                subtotal += Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[2].Value);
                porcDescuento = Math.Round((Convert.ToDouble(row.Cells[4].Value)/100),2);
                porcDescuento += Math.Round(subtotal * porcDescuento,2);
                totalImpuesto += Convert.ToDouble(row.Cells[5].Value);
                total += Convert.ToDouble(row.Cells[6].Value);
            }
            lblSubtotal.Text = subtotal.ToString("00.00");
            lblDescuento.Text = totalDescuento.ToString("00.00");
            lblImpuesto.Text = totalImpuesto.ToString("00.00");
            lblTotal.Text = total.ToString("00.00");
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double subtotal = 0;
            double subtotalDes = 0;
            double porcentajeImp = 0;
            double Impuesto = 0;
            double porcDescuento = 0;
            double Descuento = 0;
            double totallinea = 0;
            if (e.RowIndex >= 0)
            {
               ArticuloDatos art = articuloLogica.ObtenerArticulos(cia, Convert.ToString(dgvDetalle.Rows[e.RowIndex].Cells[0].Value))[0];
                subtotal = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[2].Value) *
                    Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[3].Value);
                porcentajeImp = articuloLogica.ObtenerImpuesto(cia, art.impuesto)[0].porcentaje;
                porcDescuento = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[4].Value);
                Descuento = subtotal * (porcDescuento / 100);
                subtotalDes = subtotal - Descuento;
                Impuesto = Math.Round(subtotalDes * (porcentajeImp / 100), 2);
                totallinea = subtotalDes + Impuesto;

                dgvDetalle.Rows[e.RowIndex].Cells[5].Value = Impuesto;
                dgvDetalle.Rows[e.RowIndex].Cells[6].Value = totallinea;
            }
            CalculaTotales();
        }

        private void dgvDetalle_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            double subtotal = 0;
            double porcDescuento = 0;
            double Descuento = 0;
            if (e.RowIndex >= 0)
            {
                ArticuloDatos art = articuloLogica.ObtenerArticulos(cia, Convert.ToString(dgvDetalle.Rows[e.RowIndex].Cells[0].Value))[0];
                subtotal = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[2].Value) *
                    Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[3].Value);
                porcDescuento = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[4].Value);
                Descuento = subtotal * (porcDescuento / 100);
                txtMontoDescuento.Text = Descuento.ToString("000.00");
            }
        }

        public void insertarFactura()
        {
            double servGravados = 0;
            double servExentos = 0;
            double mercGravadas = 0;
            double mercExentas = 0;
            double totalExentas = 0;
            double totalGravadas = 0;
            double totalVenta = 0;
            double totalDescuento = 0;
            double totalVentaNeta = 0;
            double totalImpuesto = 0;
            double totalComprobante = 0;

            string documento = Convert.ToString(facturaLogica.ObtenerConsecutivos(cia, Global.GlobalVend.caja, "F")[0].consecutivo);
            facturaLogica.ActualizarConsecutivo(cia, Global.GlobalVend.caja, "F");

            List<DetalleFacturaDatos> listaDetalle = new List<DetalleFacturaDatos>();
            int secuencia = 1;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                double subtotal = 0;
                double subtotalDes = 0;
                double montoDescuento = 0;
                double porcImpuesto = 0;
                double porcDescuento = 0;

                ArticuloDatos art = new ArticuloDatos();
                art = articuloLogica.ObtenerArticulos(cia, Convert.ToString(row.Cells[0].Value))[0];
                subtotal = Math.Round((Convert.ToDouble(row.Cells[2].Value) * Convert.ToDouble(row.Cells[3].Value)), 2);
                porcImpuesto = Math.Round((articuloLogica.ObtenerImpuesto(cia, art.impuesto)[0].porcentaje / 100), 2);

                porcDescuento = Convert.ToDouble(row.Cells[4].Value) / 100;
                montoDescuento = subtotal * porcDescuento;
                subtotalDes = subtotal - montoDescuento;

                TipoArticuloDatos tipoArticulo = articuloLogica.ObtenerTipoArticulo(cia, art.tipo)[0];

                DetalleFacturaDatos detalle = new DetalleFacturaDatos();
                detalle.cia = cia;
                detalle.documento = documento;
                detalle.secuencia = secuencia;
                detalle.articulo = Convert.ToString(row.Cells[0].Value);
                detalle.porcDescuento = (float)Convert.ToDouble(row.Cells[4].Value);
                detalle.porcImpuesto = (float)articuloLogica.ObtenerImpuesto(cia, art.impuesto)[0].porcentaje;
                detalle.unidadMedida = "Unid";
                detalle.cantidad = (float)Convert.ToDouble(row.Cells[2].Value);
                detalle.costo = (float)art.costo;
                detalle.precio = (float)Convert.ToDouble(row.Cells[3].Value);
                detalle.montoImpuesto = (float)Convert.ToDouble(row.Cells[5].Value);
                detalle.montoDescuento = (float)montoDescuento;
                detalle.total = (float)Convert.ToDouble(row.Cells[4].Value);
                detalle.descripcion = "";
                listaDetalle.Add(detalle);
                secuencia++;

                if (tipoArticulo.afecta == "N")
                {
                    if ((Convert.ToDouble(row.Cells[5].Value)) > 0)
                    {
                        servGravados += subtotal;
                    }
                    else
                    {
                        servExentos += subtotal;
                    }
                } else
                {
                    if ((Convert.ToDouble(row.Cells[5].Value)) > 0)
                    {
                        mercGravadas += subtotal;
                    }
                    else
                    {
                        mercExentas += subtotal;
                    }
                }

                totalDescuento += montoDescuento;
                totalImpuesto += Convert.ToDouble(row.Cells[5].Value);
            }

            totalExentas = servExentos + mercExentas;
            totalGravadas = servGravados + mercGravadas;
            totalVenta = totalGravadas + totalExentas;
            totalVentaNeta = totalVenta - totalDescuento;
            totalComprobante = totalVentaNeta + totalImpuesto;

            FacturaDatos facturaI = new FacturaDatos();
            facturaI.cia = cia;
            facturaI.tipo = Convert.ToString(cboTipo.SelectedValue);
            facturaI.documento = documento;
            facturaI.caja = Global.GlobalVend.caja;
            facturaI.fecha = Convert.ToDateTime(txtFecha.Text);
            facturaI.codCliente = txtCodCliente.Text;
            facturaI.pago = "0";
            facturaI.agente = txtVendedor.Text;
            facturaI.moneda = Convert.ToString(cboMoneda.SelectedValue);
            facturaI.cambio = "0";
            facturaI.descripcion = txtDescripcion.Text;
            facturaI.referencia = txtReferencia.Text;
            facturaI.estado = Convert.ToString(cboEstado.SelectedValue);
            facturaI.facturaDigital = "0";
            facturaI.servGravados = (float)servGravados;
            facturaI.servExentos = (float)servExentos;
            facturaI.mercGravadas = (float)mercGravadas;
            facturaI.mercExentas = (float)mercExentas;
            facturaI.totalExentas = (float)totalExentas;
            facturaI.totalGravadas = (float)totalGravadas;
            facturaI.totalVenta = (float)totalVenta;
            facturaI.totalDescuento = (float)totalDescuento;
            facturaI.totalVentaNeta = (float)totalVentaNeta;
            facturaI.totalImpuesto = (float)totalImpuesto;
            facturaI.totalComprobante = (float)totalComprobante;

            facturaLogica.InsertarFactura(facturaI);
            detalleFacturaLogica.InsertarDetalleFactura(listaDetalle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertarFactura();
        }
    }
}
