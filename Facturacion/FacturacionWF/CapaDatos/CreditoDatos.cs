using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CreditoDatos
    {
        public string cia { get; set; }
        public string moneda { get; set; }
        public string cod_cliente { get; set; }
        public float dias_credito { get; set; }
        public float limite_credito { get; set; }
        public float interes { get; set; }
        public float saldo { get; set; }
        public string estado { get; set; }

        public static DataSet ObtenerCredito(string cia, string cliente, string estado)
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
            DataSet ds = db.ExecuteReader(comando, "credito");
            return ds;
        }
    }
}
