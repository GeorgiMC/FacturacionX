using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class PedidoLogica
    {
        public List<PedidoDatos> SeleccionarPedidos(string cia)
        {
            List<PedidoDatos> lista = new List<PedidoDatos>();
            DataSet ds = FacturaDatos.SeleccionarTodos(cia);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PedidoDatos obj = new PedidoDatos();
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
    }
}
