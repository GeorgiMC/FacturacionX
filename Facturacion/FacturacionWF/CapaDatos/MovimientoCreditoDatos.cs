using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class MovimientoCreditoDatos
    {
        public string cia { get; set; }
        public string tip_doc { get; set; }
        public string num_doc { get; set; }
        public DateTime fec_doc { get; set; }
        public DateTime fec_vence { get; set; }
        public int ano_fiscal { get; set; }
        public int per_proceso { get; set; }
        public string cod_cliente { get; set; }
        public string moneda { get; set; }
        public string cod_agente { get; set; }
        public float tip_cambio { get; set; }
        public float tip_cambio_base { get; set; }
        public string des_observacion { get; set; }
        public string estado { get; set; }
        public float mon_saldo { get; set; }
        public string doc_ref { get; set; }
        public DateTime fec_reg { get; set; }

        public static DataSet ObtenerMovimientoCredito(string cia, string cliente, string estado,string documento)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerCredito");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            if (String.IsNullOrEmpty(cliente))
            {
                comando.Parameters.AddWithValue("@cliente", System.DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@cliente", cliente);
            }
            if (String.IsNullOrEmpty(estado))
            {
                comando.Parameters.AddWithValue("@estado", System.DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@estado", estado);
            }
            if (String.IsNullOrEmpty(estado))
            {
                comando.Parameters.AddWithValue("@documento", System.DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@documento", documento);
            }
            DataSet ds = db.ExecuteReader(comando, "movimientoCredito");
            return ds;
        }
    }
}
