using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConsecutivosDatos
    {
        public string cia { get; set; }
        public string clase { get; set; }
        public int consecutivo { get; set; }
        public string caja { get; set; }

        public static DataSet ObtenerConsecutivo(string cia, string caja,string clase)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerConsecutivo");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            if (String.IsNullOrEmpty(caja))
            {
                comando.Parameters.AddWithValue("@caja", System.DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@caja", caja);
            }
            if (String.IsNullOrEmpty(clase))
            {
                comando.Parameters.AddWithValue("@clase", System.DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@clase", clase);
            }
            DataSet ds = db.ExecuteReader(comando, "consecutivo");
            return ds;
        }

        public void ActualizarConsecutivo(ConsecutivosDatos consec)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ActualizarConsecutivo");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", consec.cia);
            comando.Parameters.AddWithValue("@caja", consec.caja);
            comando.Parameters.AddWithValue("@clase", consec.clase);
            comando.Parameters.AddWithValue("@consecutivo", consec.consecutivo);
            DataSet ds = db.ExecuteReader(comando, "consecutivo");
        }
    }
}
