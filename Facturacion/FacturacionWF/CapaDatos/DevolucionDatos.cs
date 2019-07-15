using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DevolucionDatos
    {
        public string cia { get; set; }
        public string tipo { get; set; }
        public string documento { get; set; }
        public string caja { get; set; }
        public DateTime fecha { get; set; }
        public string codCliente { get; set; }
        public string pago { get; set; }
        public string agente { get; set; }
        public string moneda { get; set; }
        public string cambio { get; set; }
        public string descripcion { get; set; }
        public string factura { get; set; }
        public string estado { get; set; }
        public string facturaDigital { get; set; }
        public float servGravados { get; set; }
        public float servExentos { get; set; }
        public float mercGravadas { get; set; }
        public float mercExentas { get; set; }
        public float totalGravadas { get; set; }
        public float totalExentas { get; set; }
        public float totalVenta { get; set; }
        public float totalDescuento { get; set; }
        public float totalVentaNeta { get; set; }
        public float totalImpuesto { get; set; }
        public float totalComprobante { get; set; }

        public static DataSet SeleccionarTodos(string cia)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarDevoluciones");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "devolucion");
            return ds;
        }
    }
}
