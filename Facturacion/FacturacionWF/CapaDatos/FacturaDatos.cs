using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class FacturaDatos
    {
        public string cia { get; set; }
        public string tipo { get; set; }
        public string documento { get; set; }
        public string caja { get; set; }
        public DateTime fecha { get; set; }
        public string codCliente{ get; set; }
        public string pago{ get; set; }
        public string agente{ get; set; }
        public string moneda{ get; set; }
        public string cambio{ get; set; }
        public string descripcion{ get; set; }
        public string referencia{ get; set; }
        public string estado{ get; set; }
        public string facturaDigital{ get; set; }
        public float servGravados{ get; set; }
        public float servExentos{ get; set; }
        public float mercGravadas{ get; set; }
        public float mercExentas{ get; set; }
        public float totalGravadas{ get; set; }
        public float totalExentas{ get; set; }
        public float totalVenta{ get; set; }
        public float totalDescuento{ get; set; }
        public float totalVentaNeta { get; set; }
        public float totalImpuesto{ get; set; }
        public float totalComprobante{ get; set; }

        public static DataSet SeleccionarTodos(string cia)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarFacturas");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "factura");
            return ds;
        }

        public void InsertarFactura(FacturaDatos factura)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarFactura");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", factura.cia);
            comando.Parameters.AddWithValue("@tipo", factura.tipo);
            comando.Parameters.AddWithValue("@documento", factura.documento);
            comando.Parameters.AddWithValue("@caja", factura.caja);
            comando.Parameters.AddWithValue("@fecha", factura.fecha);
            comando.Parameters.AddWithValue("@codCliente", factura.codCliente);
            comando.Parameters.AddWithValue("@pago", factura.pago);
            comando.Parameters.AddWithValue("@agente", factura.agente);
            comando.Parameters.AddWithValue("@moneda", factura.moneda);
            comando.Parameters.AddWithValue("@cambio", factura.cambio);
            comando.Parameters.AddWithValue("@descripcion", factura.descripcion);
            comando.Parameters.AddWithValue("@referencia", factura.referencia);
            comando.Parameters.AddWithValue("@estado", factura.estado);
            comando.Parameters.AddWithValue("@facturaDigital", factura.facturaDigital);
            comando.Parameters.AddWithValue("@servGravados", factura.servGravados);
            comando.Parameters.AddWithValue("@servExentos", factura.servExentos);
            comando.Parameters.AddWithValue("@mercGravadas", factura.mercGravadas);
            comando.Parameters.AddWithValue("@mercExentas", factura.mercExentas);
            comando.Parameters.AddWithValue("@totalExenta", factura.totalExentas);
            comando.Parameters.AddWithValue("@totalGravadas", factura.totalGravadas);
            comando.Parameters.AddWithValue("@totalVenta", factura.totalVenta);
            comando.Parameters.AddWithValue("@totalDescuento", factura.totalDescuento);
            comando.Parameters.AddWithValue("@totalVentaNeta", factura.totalVentaNeta);
            comando.Parameters.AddWithValue("@totalImpuesto", factura.totalImpuesto);
            comando.Parameters.AddWithValue("@totalComprobante", factura.totalComprobante);
            DataSet ds = db.ExecuteReader(comando, "factura");
        }
    }
}
