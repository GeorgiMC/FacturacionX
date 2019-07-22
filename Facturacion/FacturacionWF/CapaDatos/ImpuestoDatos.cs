using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ImpuestoDatos
    {
        public string cia { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public double porcentaje { get; set; }
        public string impuestoFe { get; set; }

        public static DataSet ObtenerImpuesto(string cia,string filtro)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_ObtenerImpuesto");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cia", cia);
            if (String.IsNullOrEmpty(filtro))
            {
                comando.Parameters.AddWithValue("@filtro", System.DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@filtro", filtro);
            }
            DataSet ds = db.ExecuteReader(comando, "impuesto");
            return ds;
        }
    }
}
