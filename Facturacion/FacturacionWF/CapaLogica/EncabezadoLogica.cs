using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class EncabezadoLogica
    {
        public List<FacturaDatos> SeleccionarFacturas(string cia)
        {
            List<FacturaDatos> lista = new List<FacturaDatos>();
            DataSet ds = FacturaDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                FacturaDatos obj = new FacturaDatos();
                obj.cia = row["cia"].ToString();
                obj.tipo = row["tipo"].ToString();
                obj.documento = row["documento"].ToString();
                obj.fecha = Convert.ToDateTime(row["fecha"].ToString());
                obj.codCliente = row["codCliente"].ToString();
                obj.pago = row["pago"].ToString();
                obj.agente = row["agente"].ToString();
                obj.moneda = row["moneda"].ToString();
                obj.cambio = row["cambio"].ToString();
                obj.descripcion = row["descripcion"].ToString();
                obj.referencia = row["referencia"].ToString();
                obj.estado = row["estado"].ToString();
                obj.facturaDigital = row["facturaDigital"].ToString();
                obj.servGravados = float.Parse(row["servGravados"].ToString());
                obj.servExentos = float.Parse(row["servExentos"].ToString());
                obj.mercGravadas = float.Parse(row["mercGravadas"].ToString());
                obj.mercExentas = float.Parse(row["mercExentas"].ToString());
                obj.totalExentas = float.Parse(row["totalExenta"].ToString());
                obj.totalGravadas = float.Parse(row["totalGravadas"].ToString());
                obj.totalVenta = float.Parse(row["totalVenta"].ToString());
                obj.totalDescuento = float.Parse(row["totalDescuento"].ToString());
                obj.totalVentaNeta = float.Parse(row["totalVentaNeta"].ToString());
                obj.totalImpuesto = float.Parse(row["totalImpuesto"].ToString());
                obj.totalComprobante = float.Parse(row["totalComprobante"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public void InsertarFactura(FacturaDatos factura){
            FacturaDatos fac = new FacturaDatos();
            fac.InsertarFactura(factura);
        }
        public List<ConsecutivosDatos> ObtenerConsecutivos(string cia, string caja,string clase)
        {
            List<ConsecutivosDatos> lista = new List<ConsecutivosDatos>();
            DataSet ds = ConsecutivosDatos.ObtenerConsecutivo(cia, caja,clase);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ConsecutivosDatos obj = new ConsecutivosDatos();
                obj.cia = row["cia"].ToString();
                obj.clase = row["clase"].ToString();
                obj.consecutivo = Convert.ToInt32(row["consecutivo"]);
                obj.caja = row["caja"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public void ActualizarConsecutivo(string cia, string caja, string clase)
        {
            ConsecutivosDatos consec = ObtenerConsecutivos(cia, caja, clase)[0];
            consec.consecutivo = consec.consecutivo + 1;
            consec.ActualizarConsecutivo(consec);
        }
    }
}
