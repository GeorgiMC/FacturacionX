using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ProvinciaDatos
    {
        public string codProvincia { get; set; }
        public string nomProvincia { get; set; }
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarProvincia");
            comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("@cia", cia);
            DataSet ds = db.ExecuteReader(comando, "provincia");
            return ds;
        }
    }
}
